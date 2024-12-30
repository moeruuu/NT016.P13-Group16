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
                    return Unauthorized("Unable to authenticate the user.");

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
                return BadRequest(ex.Message);
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
                    return Unauthorized("Unable to authenticate the user.");
                if (string.IsNullOrEmpty(userId))
                    return NotFound("User not found!");
 
                var res = await coopService.FindRoom(id, userId);
                if (res)
                    return Ok();
                else
                    return BadRequest("This user is already in the room.");
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
                    return Unauthorized("Unable to authenticate the user.");
                await coopService.UserJoined(userJoinedDTOs.roomid, UserId);

                return Ok(new
                {
                    Message = $"{UserId} joined the room {userJoinedDTOs.roomid}",
                    Roomid = userJoinedDTOs.roomid,
                    Userid = userId,
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to join room [{userJoinedDTOs.roomid}]: {ex.Message}");
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
                    return Ok();
                else
                    return BadRequest("No change");
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
                    return Unauthorized("Unable to authenticate the user.");

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
                return NotFound("Video not found!");
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
                    return Ok($"Room [{roomid}] has been deleted!");
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
            else 
                return NotFound("No rooms found!");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("DeleteVideo")]
        public async Task<IActionResult> DeleteVideo(AddVideoDTOs deletevideo)
        {
            try
            {
                var deleted = await coopService.DeleteVideoFromQueue(deletevideo);
                if (deleted)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("PlayVideo")]
        public async Task<IActionResult> PlayVideo(AddVideoDTOs playvideo)
        {
            try
            {
                var playing = await coopService.PlayVideo(playvideo);
                if (playing != null)
                    return Ok(playing);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetVideoPlaying/{roomid}")]
        public async Task<IActionResult> GetVideoPlaying([FromRoute] string roomid)
        {
            try
            {
                var res = await coopService.GetPlayingVideo(roomid);
                if (res == null)
                {
                    return BadRequest();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
