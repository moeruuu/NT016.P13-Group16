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
        public VideoService() { }

        public async Task<bool> UploadVideoAsync(string videofile, string imagefile, string title, string description, string tag, string accessToken)
        {
            try
            {
                if (string.IsNullOrEmpty(accessToken))
                {
                    MessageBox.Show("Yêu cầu access token!");
                    return false;
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
                form.Add(new StringContent(tag), "Tag");
                var response = await httpClient.PostAsync("api/Video/Upload", form);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}: {errorMessage}");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
                return false;
            }
        }

        public async Task<string> PlayVideo( string id, string accesstoken)
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
            var response = await httpClient.GetAsync($"api/Video/PlayVideo/{id}");
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

        public async Task<JArray> SearchVideos(string title, string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(accesstoken))
                    return null;

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                //dung EscapeDataString de ma hoa du lieu chua ki tu dac biet khong bi loi
                string url = $"api/Video/Search?title={Uri.EscapeDataString(title)}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JArray jarray = JArray.Parse(res);
                    return jarray;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
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

        public async Task<JArray> GetTopVideos(string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(accesstoken))
                {
                    return null;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                HttpResponseMessage response = await httpClient.GetAsync("/api/Video/GetTopVideos");
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
                return null;
            }
        }

        public async Task<bool> SaveWatchedVideo(string videoid, string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(videoid) || string.IsNullOrEmpty(accesstoken))
                    return false;

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var payload = new { VideoID = videoid };
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = $"api/Video/SaveWatchedVideo";
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<JArray> GetWatchedVideos(string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(accesstoken))
                {
                    return null;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                HttpResponseMessage response = await httpClient.GetAsync("/api/Video/GetWatchedVideos");
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
                return null;
            }
        }

        public async Task<JArray> GetRelatedVideos(string tag, string accesstoken)
        {
            try
            {
                if (string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(accesstoken))
                {
                    return null;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                string url = $"api/Video/GetRelatedVideos?tag={tag}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

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
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<string> Rating(string id, int num, string accesstoken)
        {
            try
            {
                //MessageBox.Show(id);
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
                    Id = id,
                    Rating = num
                };
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var json = JsonConvert.SerializeObject(rating);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PatchAsync("api/Video/Rating", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DownloadVideo(string id, string accesstoken)
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
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.GetAsync($"api/Video/DownloadVideo/{id}", HttpCompletionOption.ResponseHeadersRead);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Lỗi khi tải video: {response.StatusCode}");
                    return null;
                }
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    string tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.mp4");

                    using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await stream.CopyToAsync(fileStream);
                    }

                    return tempFilePath;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Đã xảy ra lỗi khi tải video: {ex.Message}");
            }
        }



    }
}
