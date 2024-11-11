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
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role == 0 ? "Admin" : "User"),
                new Claim("Fullname", user.Fullname ?? ""),
                new Claim("Bio", user.Bio ?? "")
            };

            var TokenInfor = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: Credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(TokenInfor);
            
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

      

        public string VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretkey);
            try
            {
                tokenHandler.ValidateToken(token,
                   new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidIssuer = _issuer,
                       ValidAudience = _audience,
                       ClockSkew = TimeSpan.Zero
                   },
                   out SecurityToken validatedToken);
                return "Hợp lệ";
            }
            catch (Exception ex)
            {
                return "Không hợp lệ";
            }
        }

        public async Task<bool> ValidateAccessToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretkey);
            try
            {
                tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = _issuer,
                        ValidAudience = _audience,
                        ClockSkew = TimeSpan.Zero
                    },
                    out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ValidateRefreshToken(string refreshtoken)
        {
            var filter = Builders<Token>.Filter.Eq(t => t.RefreshToken, refreshtoken);
            var token = await JWT.Find(filter).FirstOrDefaultAsync();
            if (token != null)
            {
                if (token.UsedToken > 0 || token.ExpiryTime < DateTime.UtcNow)
                {
                    return false;
                }
                return true;
            }
            return false;
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

        // Lưu token mới vào cơ sở dữ liệu
        public async Task SaveToken(string refreshToken, ObjectId userid)
        {
            var tokenData = new Token
            {
                RefreshToken = refreshToken,
                UserId = userid,
                ExpiryTime = DateTime.UtcNow.AddDays(14),
                IsRevoked = false,
                UsedToken = false
            };

            await JWT.InsertOneAsync(tokenData);
        }
        //Vô hiệu hóa token
        public async Task InvalidateToken(string token)
        {
            var filter = Builders<Token>.Filter.Eq(t => t.RefreshToken, token);
            var update = Builders<Token>.Update.Set(t => t.ExpiryTime, DateTime.UtcNow);

            await JWT.UpdateOneAsync(filter, update);
        }
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
    }
}

