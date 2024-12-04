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

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService emailService;
        private readonly UserService userService;
        private readonly EmailLogService emailLogService;


        public EmailController(EmailService emailService, UserService userService, EmailLogService emailLogService)
        {
            this.emailService = emailService;
            this.userService = userService;
            this.emailLogService = emailLogService;
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
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                if (string.IsNullOrEmpty(userEmail) || !emailRequest.IsValidEmail(userEmail))
                {
                    return Unauthorized("Không thể xác thực email người dùng.");
                }
                if (!emailRequest.IsValid())
                {
                    return BadRequest("Thông tin email không đầy đủ hoặc không hợp lệ.");
                }
                //emailRequest.Email = userEmail;
                await emailService.SendContactEmail(emailRequest);
                var log = new SentEmail
                {
                    SenderEmail = userEmail,
                    RecipientEmail = emailRequest.Email,
                    Subject = emailRequest.Subject,
                    Body = emailRequest.Body,
                    SentAt = DateTime.UtcNow
                };
                await emailLogService.LogSentEmail(log);
                return Ok("Email đã được gửi thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetSentEmailsBySender")]
        public async Task<IActionResult> GetSentEmailsBySender([FromQuery] string senderEmail)
        {
            try
            {
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRole == null || !userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    return Forbid("Bạn không có quyền truy cập tài nguyên này.");
                }
                if (string.IsNullOrEmpty(senderEmail))
                {
                    return BadRequest("Email của người gửi không được trống.");
                }
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(userEmail))
                {
                    return Unauthorized("Không thể xác thực email người dùng.");
                }
                var emails = await emailLogService.GetSentEmailsBySender(senderEmail);
                if (emails == null || emails.Count == 0)
                {
                    return NotFound($"Không tìm thấy email nào cho người gửi: {senderEmail}");
                }
                return Ok(emails);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }


    }
}