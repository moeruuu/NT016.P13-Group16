using MongoDB.Driver;
using API_Server.Data;
using API_Server.DTOs;
using API_Server.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
namespace API_Server.Service
{
    public class FilmService
    {
        private readonly IMongoCollection<Video> videos;
        private readonly User user;
        private readonly ImgurService imgurService;
        public FilmService(IMongoDatabase database)
        {
            videos = database.GetCollection<Video>("Videos");
        }

        public async Task<Video> AddVideo(UploadVideoDTOs uploadVideo, ObjectId id, IFormFile imagefilm)
        {
            //long size = await GetVideoSize(uploadVideo.Url);
            var imageUrl = await imgurService.UploadImgurAsync(new ImageDTOs { file = imagefilm });
            var newvideo = new Video
            {
                VideoId = ObjectId.GenerateNewId(),
                Title = uploadVideo.Title,
                Description = uploadVideo.Description,
                Url = uploadVideo.Url,
                UrlImage = imageUrl,
                UploaderID = id,
                UploadedDate = DateTime.UtcNow,
                Size = uploadVideo.Size,

            };
            await videos.InsertOneAsync(newvideo);
            return newvideo;
        }

        /*private async Task<long> GetVideoSize(string videoUrl)
        {
            using (var httpClient = new HttpClient())
            {
                
                var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, videoUrl));

                //Xem resquest oke chưa
                if (response.IsSuccessStatusCode)
                {
                    
                    if (response.Content.Headers.ContentLength.HasValue)
                    {
                        return response.Content.Headers.ContentLength.Value; 
                    }
                }
            }
            //Nếu ko lấy được thì return 0
            return 0;
        }*/

        public async Task<List<Video>> SearchVideos(string title)
        {
            var filter = Builders<Video>.Filter.Regex(v => v.Title, new MongoDB.Bson.BsonRegularExpression(title, "i"));
            return await videos.Find(filter).ToListAsync();
        }
        public async Task<bool> DeleteVideo(string id)
        {
            var filter = Builders<Video>.Filter.Eq(v => v.VideoId, ObjectId.Parse(id));
            var result = await videos.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }

      
    }
}
