using MongoDB.Driver;
using API_Server.Data;
using API_Server.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using System.IdentityModel.Tokens.Jwt;

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

        public string GenerateAccessToken(string username)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var TokenInfor = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: Credentials
                );
            string token = "Bearer";
            string temp = new JwtSecurityTokenHandler().WriteToken(TokenInfor);
            token += temp;
            return token;
        }
    }
}
