using MongoDB.Driver;
using API_Server.Data;
using API_Server.DTOs;
using API_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Security.Cryptography;
using System.Text;
using Microsoft.OpenApi.Writers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace API_Server.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        public UserService(IMongoDatabase database)
        {
            users = database.GetCollection<User>("Users");
        }
        public async Task<User> Register(UserSignUpDTOs SignupDTOs)
        {   
            if (SignupDTOs.ConfirmPassword != SignupDTOs.Password)
            {
                throw new Exception("Mật khẩu và mật khẩu xác nhận không đúng!");
            }
            var filter = Builders<User>.Filter.Or(
                    Builders<User>.Filter.Eq(u => u.Username, SignupDTOs.Username),
                    Builders<User>.Filter.Eq(u => u.Email, SignupDTOs.Email));
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                throw new Exception("Tên tài khoản đã tồn tại.");
            }

            //Tạo đối tượng lưu dữ liệu
            var user = new User
            {
                UserId = ObjectId.GenerateNewId(),
                Fullname = SignupDTOs.Fullname,
                Username = SignupDTOs.Username,
                Password = HashPassword(SignupDTOs.Password),
                Email = SignupDTOs.Email,
                Role = 1,

            };

            // Thêm người dùng mới vào collection
            await users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> Login(UserLogInDTOs LoginDTOs)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, LoginDTOs.Username);
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();

            string hash = HashPassword(LoginDTOs.Password);

            if (existingUser == null && hash != existingUser.Password)
            {
                throw new Exception("Tên tài khoản hoặc mật khẩu không trùng khớp!");
            }
            return existingUser;
        }

        public async Task<User> GetUser(string id)
        {
            return await users.Find(u => u.UserId.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateInformation(string id, string name, string avatar, string bio)
        {
            var Filter = Builders<User>.Filter.Eq(u => u.UserId.ToString(), id);
            var update = Builders<User>.Update
                    .Set(u => u.Username, name)
                    .Set(u => u.Profilepicture, avatar)
                    .Set(u => u.Bio, bio);

            var result = await users.UpdateOneAsync(Filter, update);

            return result.ModifiedCount > 0;
        }

        public async Task<User> ForgetPassword(ForgetPassDTOs forgetPassDTOs)
        {
            var Filter = Builders<User>.Filter.Eq(u => u.Username, forgetPassDTOs.Username);
            var existUser = await users.Find(Filter).FirstOrDefaultAsync();
            if (existUser == null)
            {
                throw new Exception("Tài khoản không tồn tại!");
            }
            if (forgetPassDTOs.Password != forgetPassDTOs.ConfirmPassword)
            {
                throw new Exception("Mật khẩu không khớp!");
            }
            string hash = HashPassword(forgetPassDTOs.Password);
            var update = Builders<User>.Update.Set(u => u.Password, hash);
            await users.UpdateOneAsync(Filter, update);

            return existUser;
        }

        public string HashPassword(string pass)
        {
            HashAlgorithm al = SHA256.Create();
            byte[] inputbyte = Encoding.UTF8.GetBytes(pass);
            byte[] hashbyte = al.ComputeHash(inputbyte);
            string hashstring = BitConverter.ToString(hashbyte).Replace("-", "");
            return hashstring;
        }
    }
}
