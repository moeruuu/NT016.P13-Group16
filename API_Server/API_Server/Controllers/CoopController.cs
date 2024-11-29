using API_Server.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoopController : ControllerBase
    {

        private readonly CoopService coopService;

        public CoopController(CoopService coopService)
        {
            this.coopService = coopService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom() {
            try
            {
                var id = await coopService.CreateIDRoom();
                if (id != null)
                {
                    return Ok(new {
                        roomid = id
                    });
                }
                else
                {
                    return BadRequest("Không thể tạo ID");
                }
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
           
        }
    }
}
