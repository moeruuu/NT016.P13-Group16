using API_Server.DTOs;
using API_Server.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using API_Server.SignalRHub;
using MongoDB.Bson;
using System.Security.Claims;
using API_Server.Data;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoopController : ControllerBase
    {

        private readonly CoopService coopService;
        private readonly UserService userService;
        private readonly IHubContext<VideoHub> hub;

        public CoopController(CoopService coopService, IHubContext<VideoHub> hubContext)
        {
            this.coopService = coopService;
            hub = hubContext;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTOs newroom) {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                var user = await userService.GetUserByID(UserId);

                var createroom = await coopService.CreateRoom(newroom, user.UserId);
                return Ok(new
                {
                    Room = new
                    {
                        Id = createroom.Id,
                        RoomId = createroom.RoomId,
                        HostId = createroom.HostId,
                        StartTime = createroom?.StartTime,

                    }
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("JoinRoom")]
        public async Task<IActionResult> JoinRoom([FromBody] UserJoinedDTOs userjoined)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }
            var user = await userService.GetUserByID(UserId);
            await hub.Clients.Group(userjoined.roomid).SendAsync("ReceiveNotification", $"{user.Fullname} has joined.");
            return Ok(new
            {
                Message = $"{user.Fullname} joined the room {userjoined.roomid}"
            }) ;
        }
    }
}
