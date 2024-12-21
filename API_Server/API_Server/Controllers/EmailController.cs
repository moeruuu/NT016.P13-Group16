using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.Models;
using API_Server.Service;
using API_Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Mail;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Generators;
using System.Diagnostics;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService emailService;
        private readonly UserService userService;
        private readonly EncryptionService encryptionService;

        public EmailController(EmailService emailService, UserService userService)
        {
            this.emailService = emailService;
            this.userService = userService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Contact")]
        public async Task<IActionResult> Contact([FromBody] EmailRequest emailRequest)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                    return Unauthorized("Unable to authenticate the user.");
                var user = await userService.GetUserByID(UserId);
                if (user == null)
                    return Unauthorized("User not found.");
                if (string.IsNullOrEmpty(user.EncryptedEmailPassword))
                    return BadRequest("No email password saved.");

                // Giải mã mật khẩu
                var encryptionService = new EncryptionService();
                var plaintextPassword = encryptionService.Decrypt(user.EncryptedEmailPassword);
                if (!string.IsNullOrEmpty(emailRequest.EmailPassword) &&
                    !emailRequest.EmailPassword.Equals(plaintextPassword))
                {
                    return BadRequest("Invalid email password.");
                }
                emailRequest.EmailPassword = plaintextPassword;
                //string hashedEmailPassword = userService.HashPassword(emailRequest.EmailPassword);
                //if (string.IsNullOrEmpty(user.HashedEmailPassword))
                //{
                //    // Lưu mật khẩu mới nếu chưa có
                //    user.HashedEmailPassword = userService.HashPassword(emailRequest.EmailPassword);
                //    await userService.UpdateUser(user);
                //}
                //else
                //{
                //// So sánh mật khẩu đã lưu với mật khẩu nhận từ client
                //if (emailRequest.EmailPassword.Length < 50)
                //    {
                //        if (!userService.VerifyPassword(user.HashedEmailPassword, emailRequest.EmailPassword))
                //        {
                //            return BadRequest("Invalid email password.");
                //        }
                //    }
                //    else // Nếu nhận được mật khẩu đã mã hóa
                //    {
                //        if (emailRequest.EmailPassword != user.HashedEmailPassword)
                //        {
                //            return BadRequest("Invalid email password.");
                //        }
                //    }
                //}
                    //else
                    //{
                    //    user.HashedEmailPassword = userService.HashPassword(emailRequest.EmailPassword);
                    //    await userService.UpdateUser(user);
                    //}


                    if (string.IsNullOrEmpty(userEmail) || !emailRequest.IsValidEmail(userEmail))
                    return Unauthorized("Unable to authenticate the email.");
                //if (string.IsNullOrEmpty(emailRequest.EmailPassword))
                //{
                //    user.HashedEmailPassword = hashedEmailPassword;
                //    await userService.UpdateUser(user);
                //}
                //else
                //{
                //    if (!userService.VerifyPassword(user.HashedEmailPassword, emailRequest.EmailPassword))
                //    {
                //        return BadRequest("Invalid email password.");
                //    }
                //}
                if (!emailRequest.IsValid())
                    return BadRequest("The email information is incomplete or invalid.");

                emailRequest.Email = userEmail;
                await emailService.SendContactEmail(emailRequest, userService);
                return Ok("Email sent successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetEmails")]
        public async Task<IActionResult> GetEmails()
        {
            try
            {
                var emails = await emailService.GetEmails();
                return Ok(emails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("SaveEmailPassword")]
        public async Task<IActionResult> SaveEmailPassword([FromBody] EmailRequest request)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                    return Unauthorized("Unable to authenticate the user.");

                var user = await userService.GetUserByID(UserId);
                if (user == null)
                {
                    return Unauthorized("User not found.");
                }

                if (!string.IsNullOrEmpty(user.EncryptedEmailPassword))
                {
                    return Ok("Password already exists.");
                }
                //var encrytionService = new EncryptionService();
                //user.EncryptedEmailPassword = encrytionService.Encrypt(request.EmailPassword);
                //Debug.WriteLine(user.EncryptedEmailPassword);
                ////Console.ReadKey (true);
                //await userService.UpdateUser(user);
                await userService.SaveEncryptedPasswordAsync(request.EmailPassword, UserId);

                return Ok("Email password saved successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to save email password: {ex.Message}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetEmailPassword")]

        public async Task<IActionResult> GetEmailPassword()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                    return Unauthorized("Unable to authenticate the user.");

                var user = await userService.GetUserByID(UserId);
                if (user == null)
                    return Unauthorized("User not found.");
                //if (includePlaintextPassword && !string.IsNullOrEmpty(user.EncryptedEmailPassword))
                //{
                //    var encryptionService = new EncryptionService();
                //    var plaintextPassword = encryptionService.Decrypt(user.EncryptedEmailPassword);
                //    return Ok(plaintextPassword);
                // bool includeDecryptedPassword = false
                //}
                //if (includeDecryptedPassword)
                //{
                    // Giải mã mật khẩu được lưu
                    var decryptedPassword = await userService.GetDecryptedPasswordAsync(UserId);
                    if (decryptedPassword != null)
                        return Ok(decryptedPassword);

                    return Ok(string.Empty);
                //}

                //return Ok(!string.IsNullOrEmpty(user.EncryptedEmailPassword) ? "*****" : string.Empty);

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve email password: {ex.Message}");
            }
        }




    }
}