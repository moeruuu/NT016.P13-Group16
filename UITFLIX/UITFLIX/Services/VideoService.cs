using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

        public async Task<string> UploadVideoAsync(dynamic uploadvideo)
        {
            var json = JsonConvert.SerializeObject(uploadvideo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Video/Upload", content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
