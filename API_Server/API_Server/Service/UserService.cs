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
using System.Collections.Concurrent;
namespace API_Server.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly EmailService emailService;
        //Dùng static để biến không thay đổi
        private static string currentEmail;
        private static string currentOTP;
        //Lưu dữ liệu tạm thời
        private static readonly ConcurrentDictionary<string, User> nguoidung = new ConcurrentDictionary<string, User>();
        public UserService(IMongoDatabase database, EmailService emailService)
        {
            users = database.GetCollection<User>("Users");
            this.emailService = emailService;
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

            var otp = new Random().Next(0, 100000).ToString("D6");

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

            //Lưu tạm user thui
            nguoidung[SignupDTOs.Email] = user;
            currentEmail = user.Email;
            currentOTP = otp;

            await SendOTPMail(currentEmail, otp);
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

        public async Task<User> CheckOTP(VerifyOTPDTOs otp)
        {
            if (String.IsNullOrEmpty(currentEmail))
            {
                throw new Exception("Email này chưa được dùng để đăng ký!");
            }
            var tempUser = nguoidung[currentEmail];

            var Filter = Builders<User>.Filter.Eq(u=>u.Email, tempUser.Email);
            var existingUser = await users.Find(Filter).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                throw new Exception("Email đã tồn tại!");
            }
            if (currentOTP != otp.OTP)
            {
                throw new Exception("Email không trùng khớp!");
            }

            var newUser = new User
            {
                UserId = tempUser.UserId,
                Fullname = tempUser.Fullname,
                Username = tempUser.Username,
                Password = tempUser.Password,
                Email = tempUser.Email,
                Role = 1,
            };
            await users.InsertOneAsync(newUser);
            /*nguoidung.TryRemove(currentEmail, out _);
            currentEmail = null;
            currentOTP = null;*/
            return existingUser;
        }
        
        private async Task SendOTPMail(string mail, string otpText)
        {
            var mailrequest = new EmailRequest();
            mailrequest.Email = mail;
            mailrequest.Subject = "CONFIRM YOUR EMAIL ON UITFLIX";
            mailrequest.Body = BodyEmail(otpText);
            await this.emailService.SendEmail(mailrequest);

        }

        public string BodyEmail(string otp)
        {
            //html viết mail 
            //Đang thiết kế ảnh để làm email đẹp =)))))
            string email = "Mã OTP: " + otp;
            return email;
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
