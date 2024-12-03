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
using MongoDB.Driver;

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
        public async Task<IActionResult> CreateRoom()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
               /* var user = await userService.GetUserByID(UserId);
                if (user == null)
                {
                    return NotFound("Không tìm thấy");
                }*/

                var createroom = await coopService.CreateRoom(UserId);
                return Ok(new
                {
                    Room = new
                    {
                        Id = createroom.Id,
                        RoomId = createroom.RoomId,
                        HostId = createroom.HostId,
                        StartTime = createroom?.StartTime,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "\n" + ex.StackTrace);
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("JoinRoom")]
        public async Task<IActionResult> JoinRoom([FromBody] string roomid)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                var user = await userService.GetUserByID(UserId);
                await coopService.UserJoined(roomid, user.UserId);
                await hub.Clients.Group(roomid).SendAsync("ReceiveNotification", $"{user.Fullname} has joined.");

                return Ok(new
                {
                    Message = $"{user.Fullname} joined the room {roomid}",
                    Roomid = roomid,
                    UserId = userId,
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to join room [{roomid}]");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("LeaveRoom")]
        public async Task<IActionResult> LeaveRoom([FromBody] string roomid)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                var user = await userService.GetUserByID(UserId);
                await coopService.UserLeft(roomid, UserId);
                await hub.Clients.Group(roomid).SendAsync("ReceiveNotification", $"{user.Fullname} has left room");
                return Ok(new
                {
                    Message = $"{user.Fullname} has left room [{roomid}]",
                    Roomid = roomid,
                    UserId = userId,
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to leave room [{roomid}]");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(string roomid)
        {
            try
            {
                var checkroom = await coopService.DeleteRoom(roomid);
                if (checkroom)
                {
                    return Ok($"Phòng [{roomid}] đã bị xóa!");
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
