using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;

namespace UITFLIX.Services
{
    public class VideoService
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromMinutes(5)
        };
        public VideoService()
        {
            
        }

        public async Task UploadVideoAsync(string videofile, string imagefile, string title, string description, string size, string accessToken)
        {
            try
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    MessageBox.Show("Yêu cầu access token!");
                    return;
                }

                //authorize bằng token qua header
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                using var form = new MultipartFormDataContent();

                form.Add(new StringContent(title), "Title");
                form.Add(new StringContent(description), "Description");

                //Thêm video đến form bằng binary
                using var videostream = new FileStream(videofile, FileMode.Open, FileAccess.Read);
                var videocontent = new StreamContent(videostream);
                var videoextension = Path.GetExtension(videofile).ToLower();
                var videoMimeType = videoextension switch
                {
                    ".mp4" => "video/mp4",
                    ".avi" => "video/x-msvideo",
                    ".mov" => "video/quicktime",
                    ".wmv" => "video/x-ms-wmv",
                    ".mkv" => "video/x-matroska",
                    _ => "application/octet-stream"
                };

                videocontent.Headers.ContentType = new MediaTypeHeaderValue(videoMimeType);
                form.Add(videocontent, "UrlVideo", Path.GetFileName(videofile));

                //anhr cumx z
                using var imagestream = new FileStream(imagefile, FileMode.Open, FileAccess.Read);
                var imagecontent = new StreamContent(imagestream);
                imagecontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); 
                form.Add(imagecontent, "UrlImage", Path.GetFileName(imagefile));
                var response = await httpClient.PostAsync("api/Video/Upload", form); 

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}: {errorMessage}");
                }
                else
                {
                    MessageBox.Show("Upload video thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
        }

        public async Task<JArray> GetNewestVideosAsync(string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(accesstoken))
                {
                    return null;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                HttpResponseMessage response = await httpClient.GetAsync("/api/Video/GetNewestVideos");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JArray jarray = JArray.Parse(res);
                    return jarray;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }

        public async Task<string> PlayVideo(string accesstoken, string id)
        {
            if (string.IsNullOrEmpty(accesstoken))
            {
                MessageBox.Show("Yêu cầu access token!");
                return null;
            }
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Yêu cầu id video");
                return null;
            }
            //authorize bằng token qua header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
            var response = await httpClient.GetAsync($"api/Video/GetVideo/{id}");
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    string temp = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.mp4");
                    using (var filestream = new FileStream(temp, FileMode.Create, FileAccess.Write))
                    {
                        await stream.CopyToAsync(filestream);
                    }
                    return temp;
                }
            }
            else
            {
                MessageBox.Show("Không thể tải video!");
                return null;
            }
        }

        public async Task<string> Rating(string id, int num, string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(accesstoken))
                {
                    MessageBox.Show("Yêu cầu access token!");
                    return null;
                }
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Yêu cầu id video");
                    return null;
                }
                var rating = new
                {
                    VideoID = id,
                    Rating = num
                };
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var json = JsonConvert.SerializeObject(rating);
                var content = new StringContent(json);
                var response = await httpClient.PatchAsync("api/Video/Rating", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
