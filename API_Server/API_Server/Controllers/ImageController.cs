using API_Server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Server.DTOs;
using API_Server.Service;
using API_Server.Data;
using MongoDB.Bson;
using MongoDB.Driver;
namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImgurService imgurService;
        private readonly IMongoCollection<Video> videos;
        private readonly IMongoCollection<User> users;
        public ImageController(ImgurService _imgurService)
        {
            imgurService = _imgurService;
        }


        [HttpPost("Upload")]
            public async Task<IActionResult> UploadImage([FromForm] ImageDTOs request, [FromQuery] string imageType, [FromQuery] string id)
            {
            try
            {
                var imageUrl = await imgurService.UploadImgurAsync(request);

                if (imageType == "Avatar")
                {
                    var userId = new ObjectId(id); 
                    var filter = Builders<User>.Filter.Eq(u => u.UserId, userId);
                    var update = Builders<User>.Update.Set(u => u.Profilepicture, imageUrl);
                    await users.UpdateOneAsync(filter, update); 
                }
                else if (imageType == "VideoThumbnail")
                {
                    var videoId = new ObjectId(id);
                    var filter = Builders<Video>.Filter.Eq(v => v.VideoId, videoId);
                    var update = Builders<Video>.Update.Set(v => v.UrlImage, imageUrl);
                    await videos.UpdateOneAsync(filter, update); 
                }

                return Ok(new
                {
                    Url = imageUrl
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
        
   }



