using API_Server.DTOs;
using Newtonsoft.Json.Linq;
namespace API_Server.Service
{
    public class ImgurService
    {
        private readonly IConfiguration configuration;

        public ImgurService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<string> UploadImgurAsync(ImageDTOs image)
        {
            if (image.file == null || image.file.Length==0)
            {
                throw new ArgumentException("File ảnh không tồn tại.");
            }
            var clientId = configuration["ImgurSettings:ClientId"];
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Client-ID", clientId);
                using (var content = new MultipartFormDataContent())
                {
                    var memorystream = new MemoryStream();
                    await image.file.CopyToAsync(memorystream);
                    memorystream.Seek(0, SeekOrigin.Begin);
                    var imagecontent = new StreamContent(memorystream);
                    imagecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(image.file.ContentType);
                    content.Add(imagecontent, "image", image.file.FileName);
                    var response = await client.PostAsync("https://api.imgur.com/3/upload", content);
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseData);
                    if (json["success"]?.Value<bool>() == true)
                    {
                        return json["data"]["link"].ToString();
                    }
                    else
                    {
                        throw new Exception("Imgur upload failed: " + json["data"]["error"].ToString());
                    }
                    json = JObject.Parse(responseData);
                    if (json["success"]?.Value<bool>() == true)
                    {
                        return json["data"]["link"].ToString();
                    }
                    else
                    {
                        throw new Exception("Imgur upload failed: " + json["data"]["error"].ToString());
                    }
                }
            }
        }

    }
}
