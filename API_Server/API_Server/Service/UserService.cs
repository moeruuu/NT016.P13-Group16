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
using System;
using API_Server.Service;
using Org.BouncyCastle.Crypto.Generators;

namespace API_Server.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;
        private readonly EmailService emailService;
        private readonly VideoService videoService;

        //Lưu dữ liệu tạm thời
        private static Dictionary<string, TempUserData> otpStorage = new Dictionary<string, TempUserData>();
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
            var filter = Builders<User>.Filter.Or(
                        Builders<User>.Filter.Eq(u => u.Username, SignupDTOs.Username),
                        Builders<User>.Filter.Eq(u => u.Email, SignupDTOs.Email));
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();

            if (existingUser != null)
                throw new Exception("This username or email already exists.");

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
            var otp = new Random().Next(0, 100000).ToString("D6");

            //Thêm, cập nhật thông tin otp của user vào dictionary
            otpStorage[SignupDTOs.Email] = new TempUserData
            {
                User = user,
                OTP = otp,
                Expiration = DateTime.UtcNow.AddMinutes(5),
            };

            await SendOTPMail(SignupDTOs.Email, otp, 0);
            return user;
        }

        public async Task<User> Login(UserLogInDTOs LoginDTOs)
        {
            try
            {
                var filter = Builders<User>.Filter.Or(
                            Builders<User>.Filter.Eq(u => u.Username, LoginDTOs.Username),
                            Builders<User>.Filter.Eq(u => u.Email, LoginDTOs.Username)
                );
                var existingUser = await users.Find(filter).FirstOrDefaultAsync();

                if (existingUser == null)
                    return null;
                string hash = HashPassword(LoginDTOs.Password);
                if (!VerifyPassword(existingUser.Password, LoginDTOs.Password))
                    return null;

                var update = Builders<User>.Update.Set(u => u.IsOnline, true);
                await users.UpdateOneAsync(filter, update);
                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task LogOut(ObjectId userid)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            var existingUser = await users.Find(filter).FirstOrDefaultAsync();
            if (existingUser == null)
                throw new Exception("This account does not exist!");

            var update = Builders<User>.Update.Set(u => u.IsOnline, false);
            await users.UpdateOneAsync(filter, update);
        }

        public async Task<bool> UpdateInformation(ObjectId userid, string name, IFormFile avatarfile, string bio)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            //Tạo list để xem có bao nhiu thay đổi
            var updates = new List<UpdateDefinition<User>>();

            if (!string.IsNullOrEmpty(name))
                updates.Add(Builders<User>.Update.Set(u => u.Fullname, name));
            //Thay đổi ava phải cần đường link
            if (avatarfile != null && avatarfile.Length > 0)
            {
                var imageUrl = await imgurService.UploadImgurAsync(new ImageDTOs { file = avatarfile });
                updates.Add(Builders<User>.Update.Set(u => u.Profilepicture, imageUrl));
            }

            if (!string.IsNullOrEmpty(bio))
                updates.Add(Builders<User>.Update.Set(u => u.Bio, bio));
            if (updates.Count == 0)
                return false;

            var updateDefinition = Builders<User>.Update.Combine(updates);

            var result = await users.UpdateOneAsync(filter, updateDefinition);

            return result.ModifiedCount > 0;
        }

        public async Task<bool> ChangePassword(Object user, string oldpassword, string newpassword)
        {
            var filter = Builders<User>.Filter.Or(
                    Builders<User>.Filter.Eq(u => u.UserId, user),
                    Builders<User>.Filter.Eq(u => u.Email, user));
            var existUser = await users.Find(filter).FirstOrDefaultAsync();

            // oldpassword được thay bằng forgetstring dùng để đổi pass mà không cần pass cũ
            if (oldpassword != $"k@1 n@y l@ key $iêµ 7uyệ7 mậ7 dµng để 7ạ0 mộ7 k@1 p@$w0rd mớ1 m@ kH0ng cầN p@$w0rd cũ")
            {
                //nếu không phải đổi pass do quên pass cũ thì phải kiểm tra pass cũ có đúng không
                string hashOldPwd = HashPassword(oldpassword);
                if (hashOldPwd != existUser.Password)
                    throw new Exception("The old password does not match!");
            }

            string hashNewPwd = HashPassword(newpassword);
            if (hashNewPwd == existUser.Password)
                throw new Exception("The new password is the same as the old password!");

            var update = Builders<User>.Update.Set(u => u.Password, hashNewPwd);
            var result = await users.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }


        public async Task<string> ForgetPassword(ForgetPassDTOs forgetPassDTOs)
        {
            var Filter = Builders<User>.Filter.Eq(u => u.Email, forgetPassDTOs.Email);
            var existUser = await users.Find(Filter).FirstOrDefaultAsync();

            if (existUser == null)
                throw new Exception("This email has not been registered!");
            string hashPwd = HashPassword(forgetPassDTOs.Password);
            if (forgetPassDTOs.Password == existUser.Password)
                throw new Exception("The new password is the same as the old password!");

            if (forgetPassDTOs.statusCode == 0)
            {
                var otp = new Random().Next(0, 100000).ToString("D6");
                var tempData = new TempUserData
                {
                    User = existUser,
                    OTP = otp,
                    Expiration = DateTime.UtcNow.AddMinutes(5)
                };

                // Lưu vào otpStorage
                otpStorage[forgetPassDTOs.Email] = tempData;

                await SendOTPMail(forgetPassDTOs.Email, otp, 1);
                return "OTP sent";
            }

            // User đã xác nhận otp thành công
            otpStorage.Remove(forgetPassDTOs.Email);
            return $"k@1 n@y l@ key $iêµ 7uyệ7 mậ7 dµng để 7ạ0 mộ7 k@1 p@$w0rd mớ1 m@ kH0ng cầN p@$w0rd cũ"; // Key này response về cho user cùng otp, sau khi user xác nhận otp thì key này sẽ được gửi ngược lại lên server
        }

        public async Task<bool> DeleteUser(ObjectId userid)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, userid);
            var existUser = await users.Find(filter).FirstOrDefaultAsync();
            if (existUser == null)
                return false;

            var delete = await users.DeleteOneAsync(filter);
            return delete.DeletedCount > 0;
        }

        public async Task<Object?> CheckOTP(VerifyOTPDTOs otpDTOs)
        {
            if (otpDTOs.requestCode == 0)
            {
                if (!otpStorage.TryGetValue(otpDTOs.Email, out var tempData))
                    throw new Exception("This email has not been used for registration!");

                //Check OTP còn hạn không
                if (tempData.Expiration < DateTime.UtcNow)
                {
                    otpStorage.Remove(otpDTOs.Email); // Xóa dữ liệu tạm
                    throw new Exception("The OTP has expired!");
                }

                // Kiểm tra OTP có khớp không
                if (tempData.OTP != otpDTOs.OTP)
                    throw new Exception("The OTP does not match!");

                var Filter = Builders<User>.Filter.Eq(u => u.Email, tempData.User.Email);
                var existingUser = await users.Find(Filter).FirstOrDefaultAsync();
                if (existingUser != null)
                    throw new Exception("This email already exists!");

                var newUser = new User
                {
                    UserId = tempData.User.UserId,
                    Fullname = tempData.User.Fullname,
                    Username = tempData.User.Username,
                    Password = tempData.User.Password,
                    Email = tempData.User.Email,
                    Role = 1,
                    Bio = "< This user is speechless ... >",
                };
                await users.InsertOneAsync(newUser);

                // Xóa dữ liệu tạm sau khi thành công
                otpStorage.Remove(otpDTOs.Email);

                return existingUser;
            }
            if (otpDTOs.requestCode == 1)
            {
                if (!otpStorage.TryGetValue(otpDTOs.Email, out var tempData))
                    throw new Exception("This email has not been used for registration!");

                if (tempData.Expiration < DateTime.UtcNow)
                {
                    otpStorage.Remove(otpDTOs.Email);
                    throw new Exception("The OTP has expired!");
                }

                if (tempData.OTP != otpDTOs.OTP)
                    throw new Exception("The OTP does not match!");

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
                message = "Thank you for becoming a member of UITflix!";
                mailrequest.Subject = "CONFIRM YOUR EMAIL ON UITFLIX";
            }
            if (code == 1) //quên mk
            {
                title = "Did you forget your password?";
                message = "Don't forget your password again!";
                mailrequest.Subject = "RENEW PASSWORD OF YOUR UITFLIX ACCOUNT";
            }
            mailrequest.Body = BodyEmail(otpText, title, message);
            await this.emailService.SendEmail(mailrequest);
        }

        public string BodyEmail(string otp, string title, string message)
        {
            string email = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>OTP Email</title>
                <style>
                    body {{
                        font-family: Arial, Helvetica, sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 0;
                        color: #333;
                    }}

                    .container {{
                        background-color: #5f9ea0;
                        padding: 30px;
                        border-radius: 10px;
                        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                        text-align: center;
                        width: 100%;
                        max-width: 600px;
                        margin: 40px auto;
                    }}

                    .header {{
                        background-color: #5f9ea0;
                        padding: 20px;
                        border-radius: 10px 10px 0 0;
                        color: #fff;
                    }}

                    .header img {{
                        width: 100px;
                        height: auto;
                        margin-bottom: 10px;
                    }}

                    .header h2 {{
                        font-size: 24px;
                        margin: 0;
                        color: #fff;
                    }}

                    .middle {{
                        background-color: #add8e6;
                        padding: 30px;
                        border-radius: 10px;
                        margin-top: 20px;
                    }}

                    .middle h1 {{
                        font-size: 28px;
                        color: #445ca2;
                        margin-bottom: 15px;
                    }}

                    .middle p {{
                        font-size: 16px;
                        color: #445ca2;
                    }}

                    .one-time-password {{
                        font-size: 32px;
                        font-weight: bold;
                        color: #445ca2;
                        margin: 20px 0;
                        letter-spacing: 3px;
                    }}

                    .footer {{
                        margin-top: 30px;
                        font-size: 14px;
                        color: #fff;
                        border-top: 1px solid #fff;
                        padding-top: 10px;
                    }}

                    .footer p {{
                        margin: 5px 0;
                    }}

                    .footer a {{
                        color: #fff;
                        text-decoration: none;
                    }}

                    /* Responsive Design */
                    @media (max-width: 600px) {{
                        .container {{
                            padding: 15px;
                            width: 100%;
                        }}

                        .header h2 {{
                            font-size: 22px;
                        }}

                        .middle h1 {{
                            font-size: 24px;
                        }}

                        .one-time-password {{
                            font-size: 28px;
                        }}
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <img src='https://i.imgur.com/DjYrvRL.png' alt='UITFLIX Logo'>
                        <h2>UITFlix - NT106.P13</h2>
                    </div>
                    <div class='middle'>
                        <h1>{title}</h1>
                        <p>To enjoy great movies time with us, please enter the OTP below!</p>
                        <p class='one-time-password'>{otp}</p>
                    </div>
                    <div class='footer'>
                        <p>{message}</p>
                        <p>Please do not reply to this email.</p>
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
                throw new Exception("User not found!");
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
        public async Task SaveEncryptedPasswordAsync(string plaintextPassword, ObjectId userId)
        {
            var encryptionService = new EncryptionService();
            var encryptedPassword = encryptionService.Encrypt(plaintextPassword);

            var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
            var update = Builders<User>.Update.Set(u => u.EmailPassword, encryptedPassword);

            await users.UpdateOneAsync(filter, update);
        }
        public async Task<string?> GetDecryptedPasswordAsync(ObjectId userId)
        {
            var encryptionService = new EncryptionService();

            var user = await GetUserByID(userId);
            if (user == null || string.IsNullOrEmpty(user.EmailPassword))
                return null;

            return encryptionService.Decrypt(user.EmailPassword);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            return await users.Find(filter).FirstOrDefaultAsync();
        }
        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.UserId, user.UserId);
            await users.ReplaceOneAsync(filter, user);
        }
        public bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            string computedHash = HashPassword(plainPassword);
            return string.Equals(hashedPassword, computedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
