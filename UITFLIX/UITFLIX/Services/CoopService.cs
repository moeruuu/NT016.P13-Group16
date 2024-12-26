using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UITFLIX.Models;


namespace UITFLIX.Services
{
    public class CoopService
    {
        public CoopService() { }

        private static readonly string huburl = @"https://localhost:7292/videohub";

        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

        public async Task<JObject?> CreateRoom(string accesstoken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.PostAsync("/api/Coop/CreateRoom", null);
                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    JObject jobject = JObject.Parse(res);
                    return jobject;
                }
                else
                {
                    MessageBox.Show(response.ToString());  
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                return null;
            }
        }

        public async Task<bool> FindRoom(string accesstoken, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var res = await httpClient.GetAsync($"/api/Coop/FindRoom/{roomid}");
                return res.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<JObject?> JoinRoom(string roomid, string accesstoken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
            var joinroom = new
            {
                roomid = roomid,
            };
            try
            {
                var json = JsonConvert.SerializeObject(joinroom);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/Coop/JoinRoom", content);
                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return JObject.Parse(res); 
                return null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                return null;
            }

        }

        public async Task<bool> AddVideo(string accesstoken, string videoid, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var ID = new
                {
                    roomid = roomid,
                    videoid = videoid
                };
                var json = JsonConvert.SerializeObject(ID);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/Coop/AddVideo", content);
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> LeaveRoom(string accesstoken, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var room = new
                {
                    roomid = roomid
                };
                var json = JsonConvert.SerializeObject(room);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/Coop/LeaveRoom", content);
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteRoom(string accesstoken, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.DeleteAsync($"/api/Coop/DeleteRoom/{roomid}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<List<string>?> GetVideoQueue(string accesstoken, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.GetAsync($"/api/Coop/GetVideoQueue/{roomid}");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(res);
                    var videolist = (JArray)jobject["getlist"];
                    List<string> videoid = videolist.Select(id => id.ToString().Trim('"')).ToList();
                    return videoid;
                }
                else
                {
                    MessageBox.Show(response.ToString());
                    return null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                return null;
            }
        }

        public async Task<JArray?> GetRooms(string accessToken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync($"/api/Coop/GetAllRooms");
                if (response.IsSuccessStatusCode)
                {
                    var rooms = await response.Content.ReadAsStringAsync();
                    JArray jarray = JArray.Parse(rooms);
                    return jarray;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteVideo(string accesstoken, string roomid, string videoid)
        {
            try
            {
                var delete = new
                {
                    roomid = roomid,
                    videoid = videoid
                };
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var json = JsonConvert.SerializeObject(delete);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PatchAsync("/api/Coop/DeleteVideo", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<string> PlayingVideo(string accesstoken, string roomid, string videoid)
        {
            try
            {
                var video = new
                {
                    roomid = roomid,
                    videoid = videoid
                };
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var json = JsonConvert.SerializeObject(video);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PatchAsync("/api/Coop/PlayVideo", content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<string> GetVideoPlaying(string accesstoken, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.GetAsync($"/api/Coop/GetVideoPlaying/{roomid}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
