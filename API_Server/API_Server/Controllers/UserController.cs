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
                return Ok("Đăng ký thành công!");
            }
            catch (Exception ex) 
            {
                return BadRequest($"Lỗi {ex.Message}");
            }
        }


    }
}
