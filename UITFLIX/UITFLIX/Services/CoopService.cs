﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
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

        private event Action<string>? RoomCreate;
        private event Action<string>? RoomDelete;
        private event Action<string>? UserJoin;
        private event Action<string>? UserLeave;
        public event Action<string>? PlayVideo;  
        public event Action<string>? PauseVideo;
        public CoopService()
        {

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

        private async void InitializeSignalR()
        {

        }
    }
}
