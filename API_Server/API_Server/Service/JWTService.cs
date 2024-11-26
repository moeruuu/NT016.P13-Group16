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
        private readonly UserService userService;

        public JWTService(IMongoDatabase database, MongoDbContext context, IConfiguration configuration, UserService userService)
        {
            JWT = database.GetCollection<Token>("JWTToken");
            users = context.Users;
            secretkey = configuration["JWT:SecretKey"];
            _issuer = configuration["JWT:Issuer"];
            _audience = configuration["JWT:Audience"];
            this.userService = userService;
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

        public async Task<bool> ValidateRefreshToken(string token, ObjectId userid)
        {
            var tokendata = await GetRefreshToken(token);

            if (tokendata == null || tokendata.UserId != userid)
            {
                return false;
            }
            if (tokendata.ExpiryTime <= DateTime.UtcNow)
            {
                return false;
            }
            if (tokendata.UsedToken.Contains(token))
            {
                return false;
            }

            return true;
        }

        public async Task<Token> GetRefreshToken(string token)
        {
            var refreshToken = await JWT.Find(rt => rt.RefreshToken == token).FirstOrDefaultAsync();
            return refreshToken;

        }
        public async Task<Token> GetCurrentTokenForUser(ObjectId id)
        {
            var filter = Builders<Token>.Filter.Eq(t => t.UserId, id);
            return await JWT.Find(filter).FirstOrDefaultAsync();
        }

        public async Task SaveToken(Token token)
        {
            var existedtoken = await JWT.Find(td => td.UserId == token.UserId).FirstOrDefaultAsync();

            if (existedtoken != null)
            {
                existedtoken.RefreshToken = token.RefreshToken;
                existedtoken.UsedToken = token.UsedToken;
                existedtoken.ExpiryTime = token.ExpiryTime;
                existedtoken.Jti = token.Jti;

                await JWT.ReplaceOneAsync(td => td.Id == existedtoken.Id, existedtoken);
            }
            else
            {
                await JWT.InsertOneAsync(token);
            }
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
        public async Task<string> NewGenerateAccessToken(string refreshToken, ObjectId Id)
        {
            var token = await GetRefreshToken(refreshToken);
            var Validated = await ValidateRefreshToken(refreshToken, Id);
            if (!Validated)
            {
                throw new UnauthorizedAccessException("Invalid token!");
            }

            token.UsedToken.Add(refreshToken);

            var user = await userService.GetUserByID(Id);
            var AccessToken = GenerateAccessToken(user);

            var newRefreshToken = GenerateRefreshToken();
            token.RefreshToken = newRefreshToken;
            token.ExpiryTime = DateTime.UtcNow.AddDays(14);

            await SaveToken(token);

            return AccessToken;
        }

        public string GetJtiFromAccessToken(string token)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var JWTToken = tokenhandler.ReadToken(token) as JwtSecurityToken;
            var jti = JWTToken?.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti)?.Value;
            return jti ?? string.Empty;
        }

        public async Task SaveRefreshToken(string refreshToken, ObjectId userid)
        {
            var token = new Token
            {
                Id = ObjectId.GenerateNewId(),
                RefreshToken = refreshToken,
                UserId = userid,
                ExpiryTime = DateTime.UtcNow.AddMinutes(120),
                Jti = Jti
            };
            JWT.InsertOneAsync(token);
        }

    }
}

