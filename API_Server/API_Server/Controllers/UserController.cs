using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.Data;
using API_Server.Service;
using API_Server.DTOs;
using API_Server.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDTOs signUpDTOs)
        {
            try
            {
                var userSignUp = await userService.Register(signUpDTOs);
                return Ok("Đăng ký thành công! Vui lòng kiểm tra OTP.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("Verify-OTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPDTOs OTP)
        {
            try
            {
                var userOTP = await userService.CheckOTP(OTP);
                return Ok("Xác thực OTP thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] UserLogInDTOs logInDTOs)
        {
            try
            {
                var userLogin = await userService.Login(logInDTOs);
                return Ok(new
                {
                    Token = userLogin.Token.Replace("Bearer",""),
                    User = new
                    {
                        Username = userLogin.Username,
                        Email = userLogin.Email,
                        Profilepicture = userLogin.Profilepicture,
                        Bio = userLogin.Bio,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi {ex.Message}");
            }
        }

        [HttpPatch("Update-Information")]
        public async Task<IActionResult> UpdateInformation(string id, [FromBody] UpdateUserRequest request)
        {
            if (string.IsNullOrEmpty(id) || request == null)
            {
                return BadRequest("Không có thông tin nào được cập nhập.");
            }
            var userUpdate = await userService.UpdateInformation(id, request.FullName, request.Avatar, request.Bio);
            if (userUpdate)
            {
                return Ok("Cập nhập thông tin thành công.");
            }
            else
            {
                return BadRequest("Không tìm thấy thông tin.");
            }
        }

        [HttpDelete("Username/{Username}")]
        public async Task<IActionResult> DeleteUser(string Username)
        {
            var DeleteUser = await userService.DeleteUser(Username);
            if (DeleteUser)
            {
                return Ok("Xóa người dùng thành công!");
            }
            else
            {
                return NotFound("Không tìm thấy người dùng");
            }
        }
    }
}
