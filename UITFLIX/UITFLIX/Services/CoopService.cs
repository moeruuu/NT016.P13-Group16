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
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

        private static readonly string huburl = @"https://localhost:7292/videohub";


        public event Action<string>? RoomCreated;
        public event Action<string>? RoomDeleted;
        public event Action<string>? UserJoined;
        public event Action<string>? UserLeft;
        public event Action<string>? VideoPlayed;
        public event Action<string>? VideoPaused;
        public event Action<string, string>? ChatReceived;
        public event Action<string, string, string>? VideoAddedToQueue;
        public CoopService()
        {
        }

        public async Task<JObject> CreateRoom(string accesstoken)
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
                //MessageBox.Show(res.ToString());
                return res.IsSuccessStatusCode;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<JObject> JoinRoom(string roomid, string accesstoken)
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
                {
                    return JObject.Parse(res); 
                }
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
               // MessageBox.Show(response.ToString());
                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                //MessageBox.Show(response.ToString());
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

        public async Task<JArray> GetVideoQueue(string accesstoken, string roomid)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.DeleteAsync($"/api/Coop/GetVideoQueue/{roomid}");
                var res = await response.Content.ReadAsStringAsync();
                JObject jobject = JObject.Parse(res);
                return JArray.Parse(jobject.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
