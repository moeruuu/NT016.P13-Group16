using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UITFLIX.Models;


namespace UITFLIX.Services
{
    public class CoopService
    {
        private HubConnection connection;
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

        private static readonly string huburl = @"https://localhost:7292/videohub";

        private readonly string token;

        public event Action<string>? RoomCreated;
        public event Action<string>? RoomDeleted;
        public event Action<string>? UserJoined;
        public event Action<string>? UserLeft;
        public event Action<string>? VideoPlayed;
        public event Action<string>? VideoPaused;
        public event Action<string, string>? ChatReceived;
        public event Action<string, string, string>? VideoAddedToQueue;
        public CoopService(string gettoken)
        {
            token = gettoken;
            //MessageBox.Show(token.accesstoken);
            connection = new HubConnectionBuilder()
            .WithUrl(huburl, options =>
            {
                options.AccessTokenProvider = () => Task.FromResult(token);
            }).Build();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            connection.On<string>("RoomCreated", roomid =>
            {
                MessageBox.Show($"RoomCreated event triggered for room: {roomid}");
                RoomCreated?.Invoke(roomid);

            });

            connection.On<string>("ReceiveNotification", message =>
            {
                MessageBox.Show(message); 
            });

        }

        public async Task<JObject> CreateRoom(string accesstoken)
        {
            try
            {
                if (connection.State != HubConnectionState.Connected)
                {
                    await StartConnection(); 
                }
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

        public async Task StartConnection()
        {
            try
            {
                if (connection.State == HubConnectionState.Disconnected)
                {
                    await connection.StartAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }
        }

        public async Task StopConnection()
        {
            try
            {
                await connection.StopAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
