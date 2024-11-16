using MongoDB.Driver;
using API_Server.Data;
using API_Server.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Net.WebSockets;
using System.Security.Claims;
using API_Server.DTOs;
using Org.BouncyCastle.Asn1.Esf;

namespace API_Server.Service
{
    public class JWTService
    {
        private readonly IMongoCollection<Token> JWT;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string secretkey;
        private readonly IMongoCollection<User> users;
        private static string Jti;

        public JWTService(IMongoDatabase database, MongoDbContext context, IConfiguration configuration)
        {
            JWT = database.GetCollection<Token>("JWTToken");
            users = context.Users;
            secretkey = configuration["JWT:SecretKey"];
            _issuer = configuration["JWT:Issuer"];
            _audience = configuration["JWT:Audience"];
        }

        public string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Fullname),
                new Claim(ClaimTypes.Role, user.Role == 0 ? "Admin" : "User"),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(120),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = Credentials,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32]; 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber); 
            }
        }



        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretkey);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> ValidateRefreshToken(string token, ObjectId userId, ObjectId id)
        {
            var getToken = await GetCurrentTokenForUser(userId);

            if (getToken.RefreshToken == null || getToken.ExpiryTime < DateTime.UtcNow || getToken.IsRevoked != null || getToken.Id != id)
                return false;

            return true;
        }


        public async Task<Token> GetCurrentTokenForUser(ObjectId id)
        {
            var filter = Builders<Token>.Filter.Eq(t => t.UserId, id);
            return await JWT.Find(filter).FirstOrDefaultAsync();
        }
        public async Task IncrementUsedToken(string refreshToken)
        {
            var filter = Builders<Token>.Filter.Eq(t => t.RefreshToken, refreshToken);
            var update = Builders<Token>.Update.Set(t => t.UsedToken, true);
            await JWT.UpdateOneAsync(filter, update);
        }

        //Vô hiệu hóa token
        
        public async Task<bool> DeleteTokenById(ObjectId userid)
        {
            try
            {
                var res = await JWT.DeleteOneAsync(token => token.UserId == userid);
                return res.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task SaveRefreshToken(string refreshToken, ObjectId userid)
        {
            var token = new Token
            {
                Id = ObjectId.GenerateNewId(),
                RefreshToken = refreshToken,
                UserId = userid,
                ExpiryTime = DateTime.UtcNow.AddMinutes(120),
                UsedToken = false,
                IsRevoked = false,
                Jti = Jti
            };
            JWT.InsertOneAsync(token);
        }

    }
}

