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
        private readonly VideoService videoService;
        private readonly UserService userService;
        public VideoController(VideoService videoService, UserService user)
        {
            this.videoService = videoService;
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
                //ObjectId UserId = ObjectId.Parse("67337f1bc5297b798496ced9");
                var addedVideo = await videoService.AddVideo(uploadVideo, UserId);

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

                var videos = await videoService.SearchVideos(title);
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
            var videos = await videoService.GetNewestVideos();
            return Ok(videos);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetTopVideos")]
        public async Task<IActionResult> GetTopVideo()
        {
            var videos = await videoService.GetTopVideos();
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

                var res = await videoService.SaveWatchedVideo(UserId, watchedVideoDetailsModel);
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
                var videos = await videoService.GetWatchedVideos(UserId);
                return Ok(videos);
            }
            catch
            {
                return BadRequest("Không thể load danh sách videos đã xem");
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("GetAllVideos")]
        public async Task<IActionResult> GetAllVideos()
        {
            var videos = await videoService.GetAllVideos();
            if (videos != null || videos.Count != 0)
                return Ok(videos);
            else return NotFound("Không tìm thấy video nào cả");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("PlayVideo/{id}")]
        public async Task<IActionResult> PlayVideo(string id)
        {
            try
            {
                var video = await videoService.GetVideoByID(id);
                var extension = Path.GetExtension(video.Url).ToLower();
                var mime = videoService.GetMimeType(extension);
                var stream = await videoService.GetStreamByIDVideo(id);
                return File(stream, mime);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetVideo/{id}")]
        public async Task<IActionResult> GetVideo([FromRoute]string id)
        {
            try
            {
                var video = await videoService.GetVideoByID(id);
                if (video != null)
                {
                    return Ok(video);
                }
                else
                {
                    return NotFound();
                }
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
            var videos = await videoService.GetRelatedVideos(tag);
            return Ok(videos);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("Rating")]
        public async Task<IActionResult> Rating([FromBody] Rating rating)
        {
            var getvideorate = await videoService.Rating(rating);
            return Ok(getvideorate);

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("Delete-Video/{id}")]
        public async Task<IActionResult> DeleteVideo([FromRoute]string id)
        {
            try
            {
                var Delete = await videoService.DeleteVideo(id);
                if (Delete)
                {
                    return Ok("Thành công");
                }
                else
                {
                    return NotFound("Không tìm thấy video");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
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
                var (stream, video) = await videoService.DownloadVideo(id);
                var mimeType = videoService.GetMimeType(Path.GetExtension(video.Url));
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
