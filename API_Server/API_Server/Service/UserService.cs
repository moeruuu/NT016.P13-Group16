﻿using MongoDB.Driver;
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
using System;
using API_Server.Service;

namespace API_Server.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly EmailService emailService;
        private readonly VideoService videoService;
        //Dùng static để biến không thay đổi
        private static string currentEmail;
        private static string currentOTP;
        //private bool isSignUp = false;
        //Lưu dữ liệu tạm thời
        private static readonly ConcurrentDictionary<string, User> nguoidung = new ConcurrentDictionary<string, User>();
        private readonly ImgurService imgurService;
        public UserService(IMongoDatabase database, EmailService emailService, ImgurService imgurService, VideoService videoService)
        {
            users = database.GetCollection<User>("Users");
            this.emailService = emailService;
            this.imgurService = imgurService;
            this.videoService = videoService;
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
                throw new Exception("Tên tài khoản hoặc email đã tồn tại.");
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

            await SendOTPMail(currentEmail, otp, 0);
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

        public async Task LogOut(ObjectId userid)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                throw new Exception("Tài khoản này không tồn tại!");
            }
            var update = Builders<User>.Update.Set(u => u.IsOnline, false);
            await users.UpdateOneAsync(filter, update);
        }

        public async Task<bool> UpdateInformation(ObjectId userid, string name, IFormFile avatarfile, string bio)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            //Tạo list để xem có bao nhiu thay đổi
            var updates = new List<UpdateDefinition<User>>();

            if (!string.IsNullOrEmpty(name))
            {
                updates.Add(Builders<User>.Update.Set(u => u.Fullname, name));
            }
            //Thay đổi ava phải cần đường link
            if (avatarfile != null && avatarfile.Length > 0)
            {
                var imageUrl = await imgurService.UploadImgurAsync(new ImageDTOs { file = avatarfile });
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

        public async Task<bool> ChangePassword(Object user, string oldpassword, string newpassword)
        {
            var filter = Builders<User>.Filter.Or(
                    Builders<User>.Filter.Eq(u => u.Username, user),
                    Builders<User>.Filter.Eq(u => u.Email, user));
            var existUser = await users.Find(filter).FirstOrDefaultAsync();

            if (oldpassword != $"k@1 n@y l@ key $iêµ 7uyệ7 mậ7 dµng để 7ạ0 mộ7 k@1 p@$w0rd mớ1 m@ kH0ng cầN p@$w0rd cũ")
            {
                string hashOldPwd = HashPassword(oldpassword);
                if (hashOldPwd != existUser.Password)
                    throw new Exception("Mật khẩu cũ không trùng khớp!");
            }

            string hashNewPwd = HashPassword(newpassword);
            if (hashNewPwd == existUser.Password)
            {
                throw new Exception("Không thể đổi thành mật khẩu cũ");
            }
            var update = Builders<User>.Update.Set(u => u.Password, hashNewPwd);

            var result = await users.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }


        public async Task<string> ForgetPassword(ForgetPassDTOs forgetPassDTOs)
        {
            var Filter = Builders<User>.Filter.Eq(u => u.Email, forgetPassDTOs.Email);
            var existUser = await users.Find(Filter).FirstOrDefaultAsync();

            if (existUser == null)
            {
                throw new Exception("Email này chưa được đăng ký!");
            }
            string hashPwd = HashPassword(forgetPassDTOs.Password);
            if (forgetPassDTOs.Password == existUser.Password)
            {
                throw new Exception("Mật khẩu mới trùng với mật khẩu cũ!");
            }

            if (forgetPassDTOs.statusCode == 0)
            {
                //gửi OTP đến email để confirm
                currentEmail = existUser.Email;
                currentOTP = new Random().Next(0, 100000).ToString("D6"); ;

                await SendOTPMail(currentEmail, currentOTP, 1);
                return "Đã gửi mã OTP";
            }

            return $"k@1 n@y l@ key $iêµ 7uyệ7 mậ7 dµng để 7ạ0 mộ7 k@1 p@$w0rd mớ1 m@ kH0ng cầN p@$w0rd cũ";
        }

        public async Task<bool> DeleteUser(ObjectId userid)
        {
            var delete = await users.DeleteOneAsync(u => u.UserId == userid);
            return delete.DeletedCount > 0;
        }

        public async Task<Object> CheckOTP(VerifyOTPDTOs otpDTOs)
        {
            if (otpDTOs.requestCode == 0)
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
                if (currentOTP != otpDTOs.OTP)
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
                    Bio = "< Người dùng này cạn lời rồi ... >",
                };
                await users.InsertOneAsync(newUser);
                /*nguoidung.TryRemove(currentEmail, out _);
                currentEmail = null;
                currentOTP = null;*/
                return existingUser;
            }
            if (otpDTOs.requestCode == 1)
            {
                if (currentOTP != otpDTOs.OTP)
                    throw new Exception("Mã OTP không trùng khớp");
                return true;
            }
            return null;
        }



        private async Task SendOTPMail(string mail, string otpText, int code)
        {
            string title = "";
            string message = "";
            var mailrequest = new EmailRequest();
            mailrequest.Email = mail;
            if (code == 0) //đăng ký
            {
                title = "Welcome to UITFLIX,";
                message = "Cảm ơn cậu đã trở thành thành viên của UITFLIX!";
                mailrequest.Subject = "CONFIRM YOUR EMAIL ON UITFLIX";
            }
            if (code == 1) //quên mk
            {
                title = "Bạn quên mật khẩu à?";
                message = "Đừng quên mật khẩu nữa nhé!";
                mailrequest.Subject = "RENEW PASSWORD OF YOUR UITFLIX ACCOUNT";
            }
            mailrequest.Body = BodyEmail(otpText, title, message);
            await this.emailService.SendEmail(mailrequest);
        }

        public string BodyEmail(string otp, string title, string message)
        {
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
                  <h1>{title}</h1>
                  <p class='huhu'>Để có những phút giây vui vẻ xem phim với tụi tớ thì cậu hãy nhập OTP nhé!</p>
                  <p class='one-time-password'>{otp}</p>
                </div>
                <div class='footer'>
                  <p>{message}</p>
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
        public async Task<List<object>> GetAllUsers()
        {
            var filter = Builders<User>.Filter.Eq(u => u.Role, 1);
            var usersList =  await users.Find(filter).ToListAsync();

            var newUsersList = new List<object>();
            foreach(var user in usersList)
            {
                var bsonDocument = user.ToBsonDocument();
                var id = bsonDocument["_id"].AsObjectId.ToString();
                var videosCount = await videoService.GetNumOfVideos(user.UserId);
                newUsersList.Add(new
                {
                    Id = id,
                    User = user,
                    VideosCount = videosCount
                });
            }    

            return newUsersList;
        }

    }
}
