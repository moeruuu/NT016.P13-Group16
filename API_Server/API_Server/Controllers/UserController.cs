using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.Data;
using API_Server.Service;
using API_Server.DTOs;
using API_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly JWTService jwtService;


        public UserController(UserService _userService, JWTService jwt)
        {
            userService = _userService;
            jwtService = jwt;
            //Tokencollection = database.GetCollection<Token>("JWTToken");
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
                var accessToken = jwtService.GenerateAccessToken(userLogin);
                
                var refreshtoken = jwtService.GenerateRefreshToken();

                jwtService.SaveRefreshToken(refreshtoken, userLogin.UserId);

                var Cookie = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddMinutes(120),
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                };

                Response.Cookies.Append("accessToken", accessToken, Cookie);

                return Ok(new
                {
                    Access_token = accessToken,
                    Token_type = "bearer",
                    User = new
                    {
                        Fullname = userLogin.Fullname,
                        Username = userLogin.Username,
                        Email = userLogin.Email,
                        Profilepicture = userLogin.Profilepicture,
                        Bio = userLogin.Bio,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi {ex.Message} \n {ex.StackTrace}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("Update-Information")]
        public async Task<IActionResult> UpdateInformation([FromBody] UpdateUserRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }
            if (request == null)
            {
                return BadRequest("Không có thông tin nào được cập nhập.");
            }
            var userUpdate = await userService.UpdateInformation(UserId, request.FullName, request.Avatar, request.Bio);
            if (userUpdate)
            {
                var getuser = await userService.GetUserByID(UserId);
                return Ok(new {
                    User = new {
                        UserId = getuser.UserId,
                        Username = getuser.Username,
                        Email = getuser.Email,
                        Profilepicture = getuser.Profilepicture,
                        Bio = getuser.Bio,
                    }
                });
            }
            else
            {
                return BadRequest("Không tìm thấy thông tin.");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetInformation/me")]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }
            try
            {
                var CurrentUser = await userService.GetUserByID(UserId);
                return Ok(new
                {
                    User = new
                    {
                        UserId = CurrentUser.UserId,
                        Username = CurrentUser.Username,
                        Email = CurrentUser.Email,
                        Profilepicture = CurrentUser.Profilepicture,
                        Bio = CurrentUser.Bio,

                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            if (users != null || users.Count != 0)
                return Ok(users);
            else return NotFound("Không có người dùng nào!");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("UserID/{UserId}")]
        public async Task<IActionResult> DeleteUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }
            var DeleteUser = await userService.DeleteUser(UserId);
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
