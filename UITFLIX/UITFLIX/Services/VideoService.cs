using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Policy;

namespace UITFLIX.Services
{
    public class VideoService
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };
        public VideoService()
        {
            
        }

        public async Task UploadVideoAsync(string videoFilePath, string imageFilePath, string tittle, string des, string size, string accesstoken)
        {
            /* var json = JsonConvert.SerializeObject(uploadvideo);
             var content = new StringContent(json, Encoding.UTF8, "application/json");
             var response = await httpClient.PostAsync("api/Video/Upload", content);
             return await response.Content.ReadAsStringAsync();*/
            try
            {
                if (!string.IsNullOrEmpty(accesstoken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accesstoken);
                }
                using var client = new HttpClient();
                using var form = new MultipartFormDataContent();

                // Thêm các trường thông tin video vào form
                form.Add(new StringContent(tittle), "Title");
                form.Add(new StringContent(des), "Description");
                form.Add(new StringContent(size), "Size");

                // Thêm file video vào form
                using var videoStream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);
                var videoContent = new StreamContent(videoStream);
                var extension = Path.GetExtension(videoFilePath).ToLower();
                var mimeType = extension switch
                {
                    ".mp4" => "video/mp4",
                    ".avi" => "video/x-msvideo",
                    ".mov" => "video/quicktime",
                    ".wmv" => "video/x-ms-wmv",
                    ".mkv" => "video/x-matroska",
                    _ => "application/octet-stream"
                };
                videoContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                form.Add(videoContent, "videoFile", Path.GetFileName(videoFilePath));

                // Thêm file ảnh thumbnail vào form
                using var imageStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                var imageContent = new StreamContent(imageStream);
                imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg"); // thay đổi nếu cần
                form.Add(imageContent, "imagefilm", Path.GetFileName(imageFilePath));

                // Gửi yêu cầu POST lên server
                var response = await client.PostAsync("api/Video/Upload", form);
                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode} - {errorMessage}");
                }
                //return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                //return false;
            }

        }
    }
}
