using FontAwesome.Sharp;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UITFLIX.Controllers;
using UITFLIX.Services;

namespace UITFLIX
{
    public partial class Room : Form
    {

        private ToolTip toolTip;
        private readonly string accesstoken;
        private readonly VideoService videoService;
        private readonly string roomid;
        private readonly CoopService coopService;
        private readonly UserService userService;

        private static JToken getvideo;
        private static string temp;

        private static JObject userinfo;

        private HubConnection connection;
        private static readonly string huburl = @"https://localhost:7292/videohub";

        public Room(string token, string roomid)
        {
            InitializeComponent();
            accesstoken = token;
            videoService = new VideoService();
            toolTip = new ToolTip();
            coopService = new CoopService();
            userService = new UserService();
            this.roomid = roomid;
            IDRoom.Text = roomid;
            IntializeEvent();
        }

        public async Task IntializeEvent()
        {
            connection = new HubConnectionBuilder()
                    .WithUrl(huburl)
                    .Build();
            await StartConnection();
            await UserJoined(roomid);
            await RegisterEvent();
            //connection.Closed += Connection_Closed;
            await ShowRCMVideo();
            await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, "has joined room!");
        }
        private async Task StartConnection()
        {
            try
            {
                await connection.StartAsync();
                listchatgroup.Items.Add("Connection Started");
            }
            catch (Exception ex)
            {
                listchatgroup.Items.Add($"{ex.Message}");
            }
        }

        public async Task Connection_Closed(Exception? arg)
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await connection.StartAsync();
        }
        private async Task RegisterEvent()
        {

            connection.On<string, string>("ReceivedMessage", (user, message) =>
            {
                string messages = $"{user}: {message}";
                listchatgroup.Items.Add(messages);

            });
            
        }


        public async Task ShowRCMVideo()
        {
            try
            {
                if (rcmvideopanel is FlowLayoutPanel panel)
                {
                    panel.WrapContents = false;
                    panel.AutoScroll = true;
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.WrapContents = false;
                }

                var jarray = await videoService.GetNewestVideosAsync(accesstoken);
                if (jarray != null && jarray.Count > 0)
                {
                    foreach (JToken video in jarray)
                    {
                        VideoControl item = new VideoControl()
                        {
                            Title = SetLabelText(video["title"].ToString(), 12),
                            Sub = video["uploadedDate"].ToObject<DateTime>().ToUniversalTime().ToString("dd/MM/yyyy"),
                            ImageUrl = video["urlImage"].ToString(),
                            Size = new Size(215, 200)
                        };
                        getvideo = video;
                        toolTip.SetToolTip(item, video["title"].ToString());
                        rcmvideopanel.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task UserJoined(string roomid)
        {
            try
            {
                await connection.InvokeAsync("JoinRoom", roomid);
                var jobject = await coopService.JoinRoom(roomid, accesstoken);
                userinfo = await userService.GetUserByID(jobject["userid"].ToString(), accesstoken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string SetLabelText(string text, int max)
        {
            if (text.Length > max)
            {
                return text.Substring(0, max) + "...";
            }
            else
            {
                return text;
            }
        }

        private async void btnsendmessage_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, txtChat.Text);
            txtChat.Clear();
        }
    }
}
