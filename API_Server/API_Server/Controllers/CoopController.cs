﻿using API_Server.DTOs;
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
        public async Task<IActionResult> LeaveRoom([FromBody] string roomid)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                await coopService.UserLeft(roomid, UserId);
                //await hub.Clients.Group(roomid).SendAsync("ReceiveNotification", $"{UserId} has left room");
                return Ok(new
                {
                    Message = $"{UserId} has left room [{roomid}]",
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
