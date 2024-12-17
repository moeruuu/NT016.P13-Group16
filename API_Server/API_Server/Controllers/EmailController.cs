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
                if (string.IsNullOrEmpty(userEmail) || !emailRequest.IsValidEmail(userEmail))
                    return Unauthorized("Unable to authenticate the email.");
                if (!emailRequest.IsValid())
                    return BadRequest("The email information is incomplete or invalid.");
                emailRequest.Email = userEmail;
                await emailService.SendContactEmail(emailRequest);
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


    }
}