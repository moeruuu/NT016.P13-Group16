using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

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
            connection = new HubConnectionBuilder().WithUrl(huburl).Build();
            RegisterEvent();
        }

        private void RegisterEvent()
        {
           connection.On<string>("RoomCreated", roomid =>
            {
                RoomCreated?.Invoke(roomid);
            });

            connection.On<string>("RoomDeleted", roomid =>
            {
                RoomDeleted?.Invoke(roomid);
            });

            connection.On<string>("UserJoined", userid =>
            {
                UserJoined?.Invoke(userid);
            });

            connection.On<string>("UserLeft", userid =>
            {
                UserLeft?.Invoke(userid);
            });

            connection.On<string>("PlayVideo", videoid =>
            {
                VideoPlayed?.Invoke(videoid);
            });

            connection.On<string>("PauseVideo", videoid =>
            {
                VideoPaused?.Invoke(videoid);
            });

            connection.On<string, string>("Chat", (user, message) =>
            {
                ChatReceived?.Invoke(user, message);
            });

           connection.On<string, string, string>("AddVideoToQueue", (roomid, videoid, title) =>
            {
                VideoAddedToQueue?.Invoke(roomid, videoid, title);
            });
        }

        public async Task<string> CreateRoom(string accesstoken)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                var response = await httpClient.PostAsync("api/Coop/CreateRoom", null);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(res);
                   // MessageBox.Show(res.ToString());
                    return jobject["roomid"].ToString();
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

        public async Task StartConnection()
        {
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public async Task SendMessageToRoom(string roomid, string user, string message)
        {
            await connection.SendAsync("SendMessage", roomid, user, message);
        }

        public async Task PlayNextVideo(string roomid)
        {
            await connection.SendAsync("PlayNextVideoFromQueue", roomid);
        }

        public async Task PauseVideo(string roomid, string videoid)
        {
            await connection.SendAsync("PauseVideo", roomid, videoid);
        }

        public void OnVideoAddedToQueue(string roomid, string videoid, string title)
        {
            VideoAddedToQueue?.Invoke(roomid, videoid, title);
        }

    }
}
