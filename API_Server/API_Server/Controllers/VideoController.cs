﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.DTOs;
using API_Server.Models;
using API_Server.Service;
using API_Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;
using System.Security.Claims;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly FilmService filmService;
        private readonly UserService userService;
        public VideoController(FilmService filmService, UserService user)
        {
            this.filmService = filmService;
            userService = user;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadVideo([FromForm] UploadVideoDTOs uploadVideo)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                //var user = await userService.GetUserByID(UserId);
                //ObjectId UserId = ObjectId.Parse("67337f1bc5297b798496ced9");
                var addedVideo = await filmService.AddVideo(uploadVideo, UserId);

                return Ok(new
                {
                    Video = new
                    {
                        VideoId = addedVideo.VideoId,
                        Title = addedVideo.Title,
                        Description = addedVideo.Description,
                        Url = addedVideo.Url,
                        UrlImage = addedVideo.UrlImage,
                        UploaderID = addedVideo.UploaderID,
                        UploadedDate = addedVideo.UploadedDate,
                        Size = addedVideo.Size,
                        Rating = addedVideo.Rating,
                    }
                }); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}"); 
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Search")]
        public async Task<ActionResult<List<Video>>> SearchVideos(string title)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest("Vui lòng ghi tên phim tìm kiếm.");
            }

            var videos = await filmService.SearchVideos(title);
            if (videos == null || videos.Count == 0)
            {
                return NotFound("Không tìm thấy video.");
            }

            return Ok(videos);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetAllVideos")]
        public async Task<ActionResult<List<Video>>> GetAllVideos()
        {
            var videos = await filmService.GetAllVideos();
            if (videos != null || videos.Count != 0)
                return Ok(videos);
            else return NotFound("Không có người dùng nào!");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("Delete-Video/{IDVideo}")]
        public async Task<IActionResult> DeleteVideo(string IDVideo)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
            {
                return Unauthorized("Không thể xác thực người dùng.");
            }
            var Delete = await filmService.DeleteVideo(IDVideo);
            if (Delete)
            {
                return Ok("Xóa video thành công!");
            }
            else
            {
                return NotFound("Không tìm thấy video");
            }
        }
    }
}
