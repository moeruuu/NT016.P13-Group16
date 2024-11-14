using MongoDB.Driver;
using API_Server.Data;
using API_Server.DTOs;
using API_Server.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.GridFS;
namespace API_Server.Service
{
    public class FilmService
    {
        private readonly IMongoCollection<Video> videos;
        private readonly User user;
        private readonly ImgurService imgurService;
        private readonly IGridFSBucket gridFS;

        public FilmService(IConfiguration configuration, ImgurService imgurService)
        {
            var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            var database = client.GetDatabase("DOAN");
            videos = database.GetCollection<Video>("Videos");
            gridFS = new GridFSBucket(database);

            this.imgurService = imgurService;
        }

        public async Task<Video> AddVideo(UploadVideoDTOs uploadVideo, ObjectId id)
        {

            var imageUrl = await imgurService.UploadImgurAsync(new ImageDTOs { file = uploadVideo.UrlImage });

            //Upload video vào GridFS
            ObjectId videoFileId;
            using (var stream = uploadVideo.UrlVideo.OpenReadStream())
            {
                var options = new GridFSUploadOptions { Metadata = new BsonDocument { { "contentType", uploadVideo.UrlVideo.ContentType } } };
                videoFileId = await gridFS.UploadFromStreamAsync(uploadVideo.UrlVideo.FileName, stream, options);
            }

            var newvideo = new Video
            {
                VideoId = ObjectId.GenerateNewId(),
                Title = uploadVideo.Title,
                Description = uploadVideo.Description,
                Url = videoFileId.ToString(),  //lưu GridFS ID của video làm url
                UrlImage = imageUrl,
                UploaderID = id,
                UploadedDate = DateTime.UtcNow,
                Size = uploadVideo.Size,
            };

            await videos.InsertOneAsync(newvideo);
            return newvideo;
        }


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

        public async Task<List<Video>> GetAllVideos()
        {
            return await videos.Find(new BsonDocument()).ToListAsync();
        }

    }
}
