using MongoDB.Driver;
using API_Server.Data;
using API_Server.DTOs;
using API_Server.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.GridFS;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Http.HttpResults;
namespace API_Server.Service
{
    public class VideoService
    {
        private readonly IMongoCollection<WatchedVideo> watchedList;
        private readonly IMongoCollection<Video> videos;
        private readonly IMongoCollection<User> users;
        private readonly ImgurService imgurService;
        private readonly IGridFSBucket gridFS;

        public VideoService(IConfiguration configuration, ImgurService imgurService)
        {
            var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            var database = client.GetDatabase("DOAN");
            videos = database.GetCollection<Video>("Videos");
            gridFS = new GridFSBucket(database);
            watchedList = database.GetCollection<WatchedVideo>("WatchedVideos");
            users = database.GetCollection<User>("Users");
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
                Views = 0,
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

        public async Task<bool> SaveWatchedVideo(ObjectId userId, WatchedVideoDetail watchedVideoDetailsModel)
        {
            var filter = Builders<WatchedVideo>.Filter.Eq(u => u.UserId, userId);
            var user = await watchedList.Find(filter).FirstOrDefaultAsync();
            if (user == null)
            {
                // Nếu chưa tồn tại, tạo mới tài liệu
                var newWatchedList = new WatchedVideo
                {
                    IDWatchedVideo = ObjectId.GenerateNewId(),
                    UserId = userId,
                    WatchedVideosList = new List<WatchedVideoDetail> { watchedVideoDetailsModel }
                };
                await watchedList.InsertOneAsync(newWatchedList);
                return true;
            }
            else
            {
                //Tìm xem có video nào trùng không
                var existingVideo = user.WatchedVideosList.FirstOrDefault(v => v.VideoID == watchedVideoDetailsModel.VideoID);

                if (existingVideo != null)
                {
                    // Xóa video cũ
                    var removeUpdate = Builders<WatchedVideo>.Update.PullFilter(
                        u => u.WatchedVideosList,
                        v => v.VideoID == watchedVideoDetailsModel.VideoID
                    );
                    await watchedList.UpdateOneAsync(filter, removeUpdate);
                }

                var addUpdate = Builders<WatchedVideo>.Update.Push(u => u.WatchedVideosList, watchedVideoDetailsModel);
                var result = await watchedList.UpdateOneAsync(filter, addUpdate);
                return result.ModifiedCount > 0;
            }
        }

        public async Task<List<object>> GetWatchedVideos(ObjectId userId)
        {
            var filter = Builders<WatchedVideo>.Filter.Eq(u => u.UserId, userId);
            var user = await watchedList.Find(filter).FirstOrDefaultAsync();

            // Kiểm tra nếu người dùng không tồn tại hoặc chưa xem video nào
            if (user == null || user.WatchedVideosList == null || !user.WatchedVideosList.Any())
                return new List<object>();

            var watchedVideos = new List<object>();
            //lấy video từ cuối danh sách lên
            foreach (var watchedVideo in user.WatchedVideosList.AsEnumerable().Reverse())
            {
                try
                {
                    var video = await GetVideoByID(watchedVideo.VideoID);
                    watchedVideos.Add(new
                    {
                        Video = video,
                        WatchedTime = watchedVideo.WatchedTime
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return watchedVideos;
        }

        public async Task<List<Video>> GetRelatedVideos(string tag)
        {
            var sort = Builders<Video>.Sort
                .Descending(v => v.Rating)
                .Descending(v => v.UploadedDate);
            var relatedVideosByTag = await videos.Find(Builders<Video>.Filter.Eq(v => v.Tag, tag)).Sort(sort).ToListAsync();
            var relatedVideosWithoutTag = await videos.Find(Builders<Video>.Filter.Ne(v => v.Tag, tag)).Sort(sort).ToListAsync();
            return relatedVideosByTag.Concat(relatedVideosWithoutTag).Take(12).ToList();
        }

        public async Task<bool> DeleteVideo(string id)
        {
            var filter = Builders<Video>.Filter.Eq(v => v.id, id);
            var getVideo = await GetVideoByID(id);

            if (getVideo == null)
                return false;

            var filefilter = Builders<GridFSFileInfo>.Filter.Eq(info => info.Length, getVideo.Size);
            var file = await gridFS.Find(filefilter).FirstOrDefaultAsync();

            if (file == null)
                return false; 
            await gridFS.DeleteAsync(file.Id);
            var result = await videos.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }

        public async Task<List<object>> GetAllVideos()
        {
            var videosList = await videos.Find(new BsonDocument()).ToListAsync();

            var newVideosList = new List<object>();
            foreach (var video in videosList)
            {
                var filter = Builders<User>.Filter.Eq(u => u.UserId, video.UploaderID);
                var user = await users.Find(filter).FirstOrDefaultAsync();

                newVideosList.Add(new
                {
                    Video = video,
                    Uploader = (user!=null)?user.Username:"Not found",
                });
            }
            return newVideosList;
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
                throw new Exception("Video not found!");
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
                throw new Exception("Video not found!");

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
                rating = Math.Round((double)((video.Rating * video.NumRate) + modelrating.rating) / numrate, 1);
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
                throw new FileNotFoundException("Video not found!");

            var videoFileId = new ObjectId(video.Url);
            var stream = new MemoryStream();
            try
            {
                await gridFS.DownloadToStreamAsync(videoFileId, stream);

                if (stream.Length == 0)
                    throw new FileNotFoundException("Empty file stream");

                stream.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return (stream, video);
        }

        public async Task<object> GetNumOfVideos(ObjectId userID)
        {
            var filter = Builders<Video>.Filter.Eq(v => v.UploaderID, userID);
            return videos.CountDocuments(filter);
        }

        public async Task<bool> RemoveWatchedVideo (ObjectId userID, string videoId)
        {
            var filter = Builders<WatchedVideo>.Filter.Eq (u => u.UserId, userID);
            var update = Builders<WatchedVideo>.Update.PullFilter(
                u => u.WatchedVideosList,
                v => v.VideoID == videoId);

            var result = await watchedList.UpdateOneAsync (filter, update);
            return result.ModifiedCount > 0;
        }

    }
}
