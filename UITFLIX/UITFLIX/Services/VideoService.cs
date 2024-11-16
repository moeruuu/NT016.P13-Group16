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

        public async Task UploadVideoAsync(string videoFilePath, string imageFilePath, string title, string description, string size, string accessToken, IProgress<int> progress)
        {
            try
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    MessageBox.Show("Access token is required.");
                    return;
                }

                //authorize bằng token qua header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                using var form = new MultipartFormDataContent();

                form.Add(new StringContent(title), "Title");
                form.Add(new StringContent(description), "Description");

                //Thêm video đến form bằng binary
                using var videoStream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);
                var videoContent = new StreamContent(videoStream);
                var videoExtension = Path.GetExtension(videoFilePath).ToLower();
                var videoMimeType = videoExtension switch
                {
                    ".mp4" => "video/mp4",
                    ".avi" => "video/x-msvideo",
                    ".mov" => "video/quicktime",
                    ".wmv" => "video/x-ms-wmv",
                    ".mkv" => "video/x-matroska",
                    _ => "application/octet-stream"
                };

                videoContent.Headers.ContentType = new MediaTypeHeaderValue(videoMimeType);
                form.Add(videoContent, "UrlVideo", Path.GetFileName(videoFilePath));

                //anhr cumx z
                using var imageStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                var imageContent = new StreamContent(imageStream);
                imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); 
                form.Add(imageContent, "UrlImage", Path.GetFileName(imageFilePath));

                var response = await httpClient.PostAsync("api/Video/Upload", form); 
                httpClient.Timeout = TimeSpan.FromMinutes(5);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}: {errorMessage}");
                }
                else
                {
                    MessageBox.Show("Video uploaded successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
        }

    }
}
