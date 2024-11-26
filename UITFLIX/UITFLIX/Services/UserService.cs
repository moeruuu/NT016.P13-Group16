using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using MongoDB.Bson;
using System.Windows.Documents;
using System.Windows.Forms;

namespace UITFLIX.Services
{
    public class UserService
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

        public UserService()
        {

        }

        public async Task<string> Register(dynamic ModelRegister)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ModelRegister);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/User/Register", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> VerifyOTP(dynamic OTP)
        {
            try
            {
                var json = JsonConvert.SerializeObject(OTP);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/User/Verify-OTP", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<object> UpdateInformation(string fullname, string bio, string file, string accesstoken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                using (var form = new MultipartFormDataContent())
                {
                    if (!string.IsNullOrEmpty(fullname))
                        form.Add(new StringContent(fullname), "Fullname");

                    if (!string.IsNullOrEmpty(bio))
                        form.Add(new StringContent(bio), "bio");

                    if (!string.IsNullOrEmpty(file) && System.IO.File.Exists(file))
                    {
                        var stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                        var content = new StreamContent(stream);
                        content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                        form.Add(content, "avatar", Path.GetFileName(file));
                    }
                    else
                        form.Add(new StreamContent(Stream.Null), "avatar", "current image");

                    var response = await httpClient.PatchAsync("api/User/Update-Information", form);
                    var info = await response.Content.ReadAsStringAsync();
                    JObject res = JObject.Parse(info);
                    if (response.IsSuccessStatusCode)
                    {
                        return res;
                    }
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(error);
                    return false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }

    }
}
