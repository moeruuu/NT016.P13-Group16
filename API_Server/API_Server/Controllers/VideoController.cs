using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.DTOs;
using API_Server.Models;
using API_Server.Service;
using API_Server.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                var user = await userService.GetUserByID(UserId);
                ObjectId UserId = ObjectId.Parse("67337f1bc5297b798496ced9");
                var addedVideo = await filmService.AddVideo(uploadVideo, UserId);

                return Ok(new
                {
                    Video = new
                    {
                        VideoId = addedVideo.VideoId,
                        ID = addedVideo.id,
                        Title = addedVideo.Title,
                        Description = addedVideo.Description,
                        Url = addedVideo.Url,
                        UrlImage = addedVideo.UrlImage,
                        UploaderID = addedVideo.UploaderID.ToString(),
                        UploadedDate = addedVideo.UploadedDate,
                        Size = addedVideo.Size,
                        Rating = addedVideo.Rating,
                        Tag = addedVideo.Tag,
                        Views = addedVideo.Views,
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
        public async Task<ActionResult<List<Video>>> SearchVideos([FromQuery] string title)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    return BadRequest("Vui lòng ghi tên video cần tìm kiếm.");
                }

                var videos = await filmService.SearchVideos(title);
                if (videos == null || videos.Count == 0)
                {
                    return NotFound("Không tìm thấy video.");
                }
                return Ok(videos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetNewestVideos")]
        public async Task<ActionResult<List<Video>>> GetNewestVideo()
        {
            var videos = await filmService.GetNewestVideos();
            return Ok(videos);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetTopVideos")]
        public async Task<IActionResult> GetTopVideo()
        {
            var videos = await filmService.GetTopVideos();
            return Ok(videos);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("SaveWatchedVideo")]
        public async Task<IActionResult> SaveWatchedVideo([FromBody] WatchedVideoDetail watchedVideoDetailsModel)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }

                var res = await filmService.SaveWatchedVideo(UserId, watchedVideoDetailsModel);
                if (res == true)
                    return Ok();
                else
                    return BadRequest("Không thể lưu");
            }
            catch
            {
                return BadRequest("Không thể lưu video đã xem");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetWatchedVideos")]
        public async Task<IActionResult> GetWatchedVideo()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                var videos = await filmService.GetWatchedVideos(UserId);
                return Ok(videos);
            }
            catch
            {
                return BadRequest("Không thể load danh sách videos đã xem");
            }
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

        [HttpGet("GetVideo/{id}")]
        public async Task<IActionResult> GetVideo(string id)
        {
            try
            {
                var video = await filmService.GetVideoByID(id);
                var extension = Path.GetExtension(video.Url).ToLower();
                var mime = filmService.GetMimeType(extension);
                var stream = await filmService.GetStreamByIDVideo(id);
                return File(stream, mime);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetRelatedVideos")]
        public async Task<IActionResult> GetRelatedVideos([FromQuery] string tag)
        {
            var videos = await filmService.GetRelatedVideos(tag);
            return Ok(videos);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("Rating")]
        public async Task<IActionResult> Rating([FromBody] Rating rating)
        {
            var getvideorate = await filmService.Rating(rating);
            return Ok(getvideorate);

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("DownloadVideo/{id}")]
        public async Task<IActionResult> DownloadVideo(string id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId) || !ObjectId.TryParse(userId, out ObjectId UserId))
                {
                    return Unauthorized("Không thể xác thực người dùng.");
                }
                var (stream, video) = await filmService.DownloadVideo(id);
                var mimeType = filmService.GetMimeType(Path.GetExtension(video.Url));
                return File(stream, mimeType, $"{video.Title}.mp4");

            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Không tìm thấy video." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi trong quá trình tải video.", error = ex.Message });
            }
        }

    }
}
