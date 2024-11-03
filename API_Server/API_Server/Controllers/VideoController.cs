using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.DTOs;
using API_Server.Models;
using API_Server.Service;
using API_Server.Data;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly FilmService filmService;
        public VideoController(FilmService filmService)
        {
            this.filmService = filmService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadVideo([FromBody] UploadVideoDTOs uploadVideo)
        {
            try
            {
                //var username = User.Identity.Name; Khi nào có JWT thì add vào
                //var user = await GetUserByUsername(username); 

                //var addedVideo = await filmService.AddVideo(uploadVideo, user);

                return Ok("Thêm video thành công."); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}"); 
            }
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<Video>>> SearchVideos(string title)
        {
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

        [HttpDelete("Delete-Video/{IDVideo}")]
        public async Task<IActionResult> DeleteVideo(string IDVideo)
        {
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
