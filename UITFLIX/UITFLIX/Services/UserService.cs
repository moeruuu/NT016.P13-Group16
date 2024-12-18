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
        public UserService() { }

        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

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
                        form.Add(new StringContent(fullname), "fullname");

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

                    var response = await httpClient.PatchAsync("/api/User/Update-Information", form);
                    var info = await response.Content.ReadAsStringAsync();
                    JObject res = JObject.Parse(info);

                    if (response.IsSuccessStatusCode)
                        return res;
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

        public async Task<string> ChangePassword(dynamic ChangePass, string accesstoken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

                var json = JsonConvert.SerializeObject(ChangePass);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PatchAsync("/api/User/Change-Password", content);
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> ForgetPassword(dynamic ForgetPwd)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ForgetPwd);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PatchAsync("/api/User/Forget-Password", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> LogOut(dynamic LogOutModel, string accesstoken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

                var json = JsonConvert.SerializeObject(LogOutModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/User/LogOut", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<JObject?> GetUserByID(string id, string accesstoken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

                var response = await httpClient.GetAsync($"/api/User/GetUserByID/{id}");
                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JObject.Parse(res);
                MessageBox.Show(response.ToString());
                return null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public async Task<JArray?> GetUsers(string accessToken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync($"/api/User/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadAsStringAsync();
                    JArray jarray = JArray.Parse(users);
                    return jarray;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<string?> DeleteUser(string userID, string accessToken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.DeleteAsync($"/api/User/Delete-User/{userID}");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
