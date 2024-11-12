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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace API_Server.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly EmailService emailService;
        //Dùng static để biến không thay đổi
        private static string currentEmail;
        private static string currentOTP;
        //private bool isSignUp = false;
        //Lưu dữ liệu tạm thời
        private static readonly ConcurrentDictionary<string, User> nguoidung = new ConcurrentDictionary<string, User>();
        private readonly ImgurService imgurService;
        private readonly JWTService token;
        public UserService(IMongoDatabase database, EmailService emailService, JWTService token, ImgurService imgurService)
        {
            users = database.GetCollection<User>("Users");
            this.emailService = emailService;
            this.token = token;  
            this.imgurService = imgurService;  
        }

        public async Task<User> Register(UserSignUpDTOs SignupDTOs)
        {   
            /*if (SignupDTOs.ConfirmPassword != SignupDTOs.Password)
            {
                throw new Exception("Mật khẩu và mật khẩu xác nhận không đúng!");
            }*/
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
                IsOnline = false,

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
            if (existingUser == null)
            {
                throw new Exception("Tên tài khoản hoặc mật khẩu không trùng khớp!");
            }
            string hash = HashPassword(LoginDTOs.Password);
            if (hash != existingUser.Password)
            {
                throw new Exception("Tên tài khoản hoặc mật khẩu không trùng khớp!");
            }
            var update = Builders<User>.Update.Set(u => u.IsOnline, true);
            await users.UpdateOneAsync(filter, update);
            //existingUser = GenerateAccessToken(existingUser);
            return existingUser;
        }


        public async Task<bool> UpdateInformation(ObjectId userid, string name, IFormFile avatarFile, string bio)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            //Tạo list để xem có bao nhiu thay đổi
            var updates = new List<UpdateDefinition<User>>();

            if (!string.IsNullOrEmpty(name))
            {
                updates.Add(Builders<User>.Update.Set(u => u.Fullname, name));
            }
            //Thay đổi ava phải cần đường link
            if (avatarFile != null && avatarFile.Length > 0)
            {
                var imageUrl = await imgurService.UploadImgurAsync(new ImageDTOs { file = avatarFile });
                updates.Add(Builders<User>.Update.Set(u => u.Profilepicture, imageUrl));
            }

            if (!string.IsNullOrEmpty(bio))
            {
                updates.Add(Builders<User>.Update.Set(u => u.Bio, bio));
            }
            if (updates.Count == 0)
            {
                return false;
            }

            var updateDefinition = Builders<User>.Update.Combine(updates);

            var result = await users.UpdateOneAsync(filter, updateDefinition);

            return result.ModifiedCount > 0;
        }


        /*public async Task<User> ForgetPassword(ForgetPassDTOs forgetPassDTOs)
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
        }*/
        
        public async Task<bool> DeleteUser(ObjectId userid)
        {
            /*var Filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var checkuser = await users.Find(Filter).FirstOrDefaultAsync();*/
            var delete = await users.DeleteOneAsync(u=>u.UserId == userid);
            if (delete.DeletedCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<User> CheckOTP(VerifyOTPDTOs otp)
        {
            if (String.IsNullOrEmpty(currentEmail))
            {
                throw new Exception("Email này chưa được dùng để đăng ký!");
            }
            //Lấy người dùng tạm ra nè
            var tempUser = nguoidung[currentEmail];

            var Filter = Builders<User>.Filter.Eq(u => u.Email, tempUser.Email);
            var existingUser = await users.Find(Filter).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                throw new Exception("Email đã tồn tại!");
            }
            if (currentOTP != otp.OTP)
            {
                throw new Exception("Mã OTP không trùng khớp!");
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
            //html viết mail tại tôi ngựa 
            string email = $@"
            <!DOCTYPE html>
            <html>
            <head>
            <style>
            body {{
              font-family: Arial, Helvetica, sans-serif;
              background-color: #f4f4f4; 
              margin: 0;
              padding: 0;
            }}

            .container {{
              background-color: #5f9ea0;
              padding: 30px;
              border-radius: 5px;
              box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
              text-align: center; 
              width: 400px;
              position: relative;
            }}

            .header {{
              background-color: #5f9ea0; 
              padding: 20px; 
              display: flex; 
              flex-direction: column;
              align-items: center; 
              color: #fff; 
              justify-content: space-between;
            }}

            .header img {{
              margin-right: 10px;
            }}
            h1 {{
              margin: 0; 
              font-size: 24px;
              color: #2c4386
            }}
            h2 {{
              margin: 0;
              font-size: 20px;
              margin-bottom: 20px;
            }}
            .middle {{
              background-color: #add8e6;
              padding: 20px; 
              border-radius: 5px; 
            }}

            p {{
              margin-bottom: 10px;
            }}

            .one-time-password {{
              font-weight: bold;
              margin-bottom: 20px;
              color: #445ca2;
            }}
            .huhu{{
              color: #445ca2;
            }}
            .footer {{
              margin-top: 20px;
              font-size: 14px;
              color: #fff;
            }}
            </style>
            </head>
            <body>
              <div class='container'>
                <div class='header'>
                  <img src='https://i.imgur.com/DjYrvRL.png' alt='UITFLIX Logo' width='100'>
                    <h2>NT106.P13</h2>
                </div>
                <div class='middle'>
                  <h1>Welcome to UITFLIX,</h1>
                  <p class='huhu'>Để có những phút giây vui vẻ xem phim với tụi tớ thì cậu hãy nhập OTP nhé!</p>
                  <p class='one-time-password'>{otp}</p>
                </div>
                <div class='footer'>
                  <p>Cảm ơn cậu đã trở thành thành viên của UITFLIX!</p>
                  <p>Vui lòng không trả lời email này!</p>
                </div>
              </div>
            </body>
            </html>";



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
        //Lấy user
        public async Task<User> GetUserByID(ObjectId userid)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                throw new Exception("Không tìm thấy user");
            }
            return existingUser;
        }
    }
}
