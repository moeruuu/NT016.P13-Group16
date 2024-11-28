using MongoDB.Driver;
using API_Server.Data;
using API_Server.DTOs;
using API_Server.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.GridFS;
using System.Net.WebSockets;
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

            long videosize;
            using (var stream = uploadVideo.UrlVideo.OpenReadStream())
            {
                videosize = stream.Length;
            }

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
                id = Guid.NewGuid().ToString(),
                Title = uploadVideo.Title,
                Description = uploadVideo.Description,
                Url = videoFileId.ToString(),  //lưu GridFS ID của video làm url
                UrlImage = imageUrl,
                UploaderID = id,
                UploadedDate = DateTime.UtcNow,
                Size = videosize,
                Tag = uploadVideo.Tag,
            };

            await videos.InsertOneAsync(newvideo);
            return newvideo;
        }


        public async Task<List<Video>> SearchVideos(string title)
        {
            var searchvideos = await videos.Find(Builders<Video>.Filter.Regex("Title", new MongoDB.Bson.BsonRegularExpression(title, "i"))).ToListAsync();
            return searchvideos;
        }

        public async Task<List<Video>> GetNewestVideos()
        {
            var newvideos = await videos.Find(new BsonDocument()).Sort(Builders<Video>.Sort.Descending(v => v.UploadedDate)).ToListAsync();
            return newvideos;
        }

        public async Task<List<Video>> GetTopVideos()
        {
            var topvideos = await videos.Find(new BsonDocument()).Sort(Builders<Video>.Sort.Descending(v => v.Rating)).ToListAsync();
            return topvideos;
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

        public async Task<Video> GetVideoByID(string id)
        {
            var filter = Builders<Video>.Filter.Eq(v => v.id, id);
            var video = await videos.Find(filter).FirstOrDefaultAsync();
            if (video == null)
                throw new Exception("Không tồn tại video");
            return video;
        }
        public async Task<Stream> GetStreamByIDVideo(string id)
        {
            var find = Builders<Video>.Filter.Eq(v => v.id, id);
            var video = await videos.Find(find).FirstOrDefaultAsync();
            if (video == null)
                throw new Exception("Không tồn tại video");
            var videofile = new ObjectId(video.Url);
            var stream = new MemoryStream();
            await gridFS.DownloadToStreamAsync(videofile, stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public string GetMimeType(string extension)
        {
            switch (extension.ToLower())
            {
                case ".mp4":
                    return "video/mp4";
                case ".avi":
                    return "video/x-msvideo";
                case ".mkv":
                    return "video/x-matroska";
                case ".mov":
                    return "video/quicktime";
                case ".flv":
                    return "video/x-flv";
                case ".webm":
                    return "video/webm";
                default:
                    return "application/octet-stream";
            }
        }

        public async Task<Video> Rating(Rating modelrating)
        {
            var filter = Builders<Video>.Filter.Eq(v => v.id, modelrating.Id);
            var video = await videos.Find(filter).FirstOrDefaultAsync();
            if (video == null)
            {
                throw new Exception("Không tìm thấy video");
            }
            double rating;
            int numrate;
            if (video.NumRate == 0)
            {
                rating = modelrating.rating;
                numrate = 1;
            }
            else
            {
                numrate = video.NumRate + 1;
                rating = (double)((video.Rating * video.NumRate) + modelrating.rating) / numrate;

            }

            var update = Builders<Video>.Update.Set(v => v.Rating, rating).Set(v => v.NumRate, numrate);
            await videos.UpdateOneAsync(filter, update);

            //Goi lai de no cap nhap update
            return await videos.Find(filter).FirstOrDefaultAsync();

        }
        public async Task<(Stream Stream, Video Video)> DownloadVideo(string id)
        {
            var filter = Builders<Video>.Filter.Eq(v => v.id, id);
            var video = await videos.Find(filter).FirstOrDefaultAsync();

            if (video == null)
                throw new FileNotFoundException("Không tìm thấy video.");

            var videoFileId = new ObjectId(video.Url);
            var stream = new MemoryStream();

            await gridFS.DownloadToStreamAsync(videoFileId, stream);
            stream.Seek(0, SeekOrigin.Begin);

            return (stream, video);
        }


    }
}
