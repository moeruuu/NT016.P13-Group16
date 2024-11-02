using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.Data;
using API_Server.Service;
using API_Server.DTOs;

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
        [HttpPost ("Register")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDTOs signUpDTOs)
        {
            try
            {
                var user = await userService.Register(signUpDTOs);
                return Ok("Đăng ký thành công! Vui lòng kiểm tra OTP.");
            }
            catch (Exception ex) 
            {
                return BadRequest($"Lỗi {ex.Message}");
            }
        }

        [HttpPost ("Verify-OTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPDTOs OTP)
        {
            try
            {
                var user = await userService.CheckOTP(OTP);
                return Ok("Xác thực OTP thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");  
            }
        }
    }
}
