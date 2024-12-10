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

        public CoopController(CoopService coopService)
        {
            this.coopService = coopService;
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
                // await hub.Clients.All.SendAsync("RoomCreated", createroom.RoomId);
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
        [HttpGet("FindRoom/{id}")]
        public async Task<IActionResult> FindRoom([FromRoute] string id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                if (string.IsNullOrEmpty(userId))
                {
                    return NotFound("Không tìm thấy user");
                }
                var res = await coopService.FindRoom(id, userId);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Người dùng đã ở trong phòng");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("JoinRoom")]
        public async Task<IActionResult> JoinRoom([FromBody] UserJoinedDTOs userJoinedDTOs)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                await coopService.UserJoined(userJoinedDTOs.roomid, UserId);
               // await hub.Clients.Group(userJoinedDTOs.roomid).SendAsync("ReceiveNotification", $"{UserId} has joined.");

                return Ok(new
                {
                    Message = $"{UserId} joined the room {userJoinedDTOs.roomid}",
                    Roomid = userJoinedDTOs.roomid,
                    Userid = userId,
                });
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                return BadRequest($"Failed to join room [{userJoinedDTOs.roomid}] {ex.Message} \n {ex.StackTrace}");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("AddVideo")]
        public async Task<IActionResult> AddVideo(AddVideoDTOs videoDTOs)
        {
            try
            {
                var result = await coopService.AddVideo(videoDTOs);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Không có thay đổi nào");
                }

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("LeaveRoom")]
        public async Task<IActionResult> LeaveRoom([FromBody] UserJoinedDTOs leftDTOs)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                await coopService.UserLeft(leftDTOs.roomid, userId);
                return Ok(new
                {
                    Message = $"{UserId} has left room [{leftDTOs.roomid}]",
                    Roomid = leftDTOs.roomid,
                    UserId = userId,
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to leave room [{leftDTOs.roomid}]");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetVideoQueue/{roomid}")]
        public async Task<IActionResult> GetVideoQueue([FromRoute] string roomid)
        {
            try
            {
                var getlist = await coopService.GetListVideo(roomid);
                if (getlist != null)
                {
                    return Ok(new
                    {
                        getlist
                    });

                }
                return NotFound("Không tìm thấy video");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("DeleteRoom/{roomid}")]
        public async Task<IActionResult> DeleteRoom([FromRoute]string roomid)
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await coopService.GetAllRooms();
            if (rooms != null || rooms.Count != 0)
                return Ok(rooms);
            else return NotFound("Không tìm thấy phòng nào cả");
        }
    }
}
