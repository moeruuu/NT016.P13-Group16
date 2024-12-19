using AxWMPLib;
using FontAwesome.Sharp;
using Microsoft.AspNetCore.Connections.Features;
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
using System.Windows.Controls;
using System.Windows.Forms;
using UITFLIX.Controllers;
using UITFLIX.Models;
using UITFLIX.Services;
using WMPLib;

namespace UITFLIX
{
    public partial class Room : Form
    {

        private System.Windows.Forms.ToolTip toolTip;
        private readonly string accesstoken;
        private readonly VideoService videoService;
        private readonly string roomid;
        private readonly CoopService coopService;
        private readonly UserService userService;

        private bool leaveroom = false;
        private bool canleave = false;

        private static JToken getvideo;
        private int index = 0;

        private static JObject userinfo;
        private static List<string> videoqueue;

        private System.Windows.Forms.Timer playback;
        private AxWindowsMediaPlayer axWindowsMediaPlayerVideo;

        private HubConnection connection;
        private static readonly string huburl = @"https://localhost:7292/videohub";

        public Room(string token, string roomid, JObject in4)
        {
            InitializeComponent();
            accesstoken = token;
            videoService = new VideoService();
            toolTip = new System.Windows.Forms.ToolTip();
            coopService = new CoopService();
            userService = new UserService();

            userinfo = in4;
            this.roomid = roomid;
            IDRoom.Text = roomid;

            this.axWindowsMediaPlayerVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.Controls.Add(axWindowsMediaPlayerVideo);
            axWindowsMediaPlayerVideo.Size = new Size(1060, 562);
            axWindowsMediaPlayerVideo.Location = new Point(12, 79);

            txtChat.AllowDrop = true;

            IntializeEvent();
            namefilm.Text = "";
            axWindowsMediaPlayerVideo.PlayStateChange += OnPlayStateChange;
            this.FormClosing += LRoom_FormClosing;
        }

        public async Task IntializeEvent()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(huburl)
                .WithAutomaticReconnect()
                .Build();

            connection.Reconnecting += (error) =>
            {
                listchatgroup.Invoke(new Action(() =>
                {
                    listchatgroup.Text += "\nReconnecting...";
                }));
                return Task.CompletedTask;
            };

            connection.Reconnected += (connectionId) =>
            {
                listchatgroup.Invoke(new Action(() =>
                {
                    listchatgroup.Text += "\nReconnected.";
                }));
                return Task.CompletedTask;
            };

            await StartConnection();
            await UserJoined(roomid);
            if (!axWindowsMediaPlayerVideo.IsHandleCreated)
            {
                var handle = axWindowsMediaPlayerVideo.Handle;
            }
            lbname.Text = userinfo["user"]["fullname"].ToString();
            await RegisterEvent();
            await ShowRCMVideo();
            await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, "has joined room!");
        }

        private async Task StartConnection()
        {
            try
            {
                await connection.StartAsync();
                listchatgroup.Invoke(new Action(() =>
                {
                    listchatgroup.Text = "Connection Started";
                }));
            }
            catch (Exception ex)
            {
                listchatgroup.Invoke(new Action(() =>
                {
                    listchatgroup.Text = $"Connection error: {ex.Message}";
                }));
            }
        }

        private async Task RegisterEvent()
        {

            connection.On<string, string>("ReceivedMessage", (user, message) =>
            {
                string messages = $"{user}: {message}";
                listchatgroup.Invoke(new Action(() =>
                {
                    listchatgroup.Text += "\n" + messages;

                }));
                if (message == "is playing.")
                {
                    namefilm.Invoke(new Action(() =>
                    {
                        namefilm.Text = user;
                    }));
                }
            });

            connection.On<List<string>>("ReceiveMovies", async movies =>
                {
                    try
                    {
                        dgvQueue.Invoke(new Action(() => dgvQueue.Rows.Clear()));
                        foreach (var movieId in movies)
                        {
                            var getmovie = await videoService.GetVideoByID(accesstoken, movieId);
                            if (getmovie != null)
                            {
                                dgvQueue.Invoke(new Action(() =>
                                {

                                    dgvQueue.ForeColor = Color.MidnightBlue;
                                    dgvQueue.Rows.Add(
                                        dgvQueue.Rows.Count,
                                        getmovie["title"].ToString(),
                                        getmovie["tag"].ToString()
                                    );
                                }));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + '\n' + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });

            connection.On<string>("ReceivedPlayVideo", async videoid =>
            {
                try
                {
                    var stream = await videoService.PlayVideo(videoid, accesstoken);
                    if (stream != null)
                    {
                        axWindowsMediaPlayerVideo.Invoke(new Action(() =>
                        {
                            axWindowsMediaPlayerVideo.uiMode = "none";
                            axWindowsMediaPlayerVideo.Ctlcontrols.stop();
                            //axWindowsMediaPlayerVideo.URL = null;
                            axWindowsMediaPlayerVideo.URL = stream;
                            axWindowsMediaPlayerVideo.Ctlcontrols.play();
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Error when playing video", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + '\n' + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            connection.On<double>("ReceivePlaybackPosition", position =>
            {
                if (Math.Abs(axWindowsMediaPlayerVideo.Ctlcontrols.currentPosition - position) > 0.5)
                {
                    axWindowsMediaPlayerVideo.Ctlcontrols.currentPosition = position;
                }
            });
        }

        private void OnPlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded || e.newState == (int)WMPLib.WMPPlayState.wmppsStopped)
                PlayVideo();
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsPlaying)
                StartSyncTimer();
            else if (e.newState == (int)WMPLib.WMPPlayState.wmppsStopped)
                StopSyncTimer();
        }

        private void StopSyncTimer()
        {
            playback?.Stop();
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
                            Size = new Size(175, 220)
                        };
                        getvideo = video;
                        item.Click += (sender, e) => AddVideo(video["id"].ToString());
                        toolTip.SetToolTip(item, video["title"].ToString());
                        rcmvideopanel.Controls.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UserJoined(string roomid)
        {
            try
            {
                var jobject = await coopService.JoinRoom(roomid, accesstoken);
                userinfo = await userService.GetUserByID(jobject["userid"].ToString(), accesstoken);
                await connection.InvokeAsync("JoinRoom", roomid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string SetLabelText(string text, int max)
        {
            if (text.Length > max)
                return text.Substring(0, max) + "...";
            else
                return text;
        }


        private async void AddVideo(string videoid)
        {
            try
            {
                this.Enabled = false;
                var res = await coopService.AddVideo(accesstoken, videoid, roomid);
                this.Enabled = true;
                if (res)
                {
                    await connection.InvokeAsync("AddMovie", roomid, videoid);
                    await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, "has added a video!");
                    if (dgvQueue.Rows.Count == 1)
                        await PlayVideo();
                }
                else
                    MessageBox.Show("Can't add video", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }
        }

        private void StartSyncTimer()
        {
            if (!leaveroom)
            {
                playback = new System.Windows.Forms.Timer { Interval = 500 }; //Gửi video mới 0.5s
                playback.Tick += async (sender, e) =>
                {
                    if (connection.State == HubConnectionState.Connected)
                    {
                        double currentposition = axWindowsMediaPlayerVideo.Ctlcontrols.currentPosition;
                        await connection.InvokeAsync("SyncPlaybackPosition", roomid, currentposition);
                    }
                };
                playback.Start();
            }
        }

        private async Task PlayVideo()
        {
            videoqueue = await coopService.GetVideoQueue(accesstoken, roomid);
            if (videoqueue == null || videoqueue.Count <= index) return;
            await PlayNextVideo();
        }

        private async Task PlayNextVideo()
        {
            if (videoqueue == null || videoqueue.Count == 0) return;

            try
            {
                while (videoqueue.Count > index)
                {
                    var videoid = videoqueue[index].ToString();

                    if (videoid != null)
                    {
                        await connection.InvokeAsync("PlayVideo", roomid, videoid);
                        var getmovie = await videoService.GetVideoByID(accesstoken, videoid);

                        if (getmovie != null)
                            await connection.InvokeAsync("SendMessage", getmovie["title"].ToString(), roomid, $"is playing.");
                        /*
                                                while (axWindowsMediaPlayerVideo.playState != WMPPlayState.wmppsMediaEnded)
                                                {
                                                    await Task.Delay(1000); 
                                                }*/

                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to play the video!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task SendMesssage()
        {
            if (!string.IsNullOrEmpty(txtChat.Text))
            {
                await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, txtChat.Text);
                txtChat.Clear();
            }
            else
            {
                MessageBox.Show("Please fill a message!", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void iconSend_Click(object sender, EventArgs e)
        {
            SendMesssage();
        }

        private async void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMesssage();
            }
        }

        private async void LRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Ngan cho form dong bang alt + f4 hoac dong cach kahc
            if (!leaveroom)
            {
                MessageBox.Show("Please click leave room!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }

        }

        private async void iconleaveroom_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do you wanna leave room?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                leaveroom = true;
                canleave = true;
                var response = await coopService.LeaveRoom(accesstoken, roomid);
                if (response)
                {
                    await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, "has left room");
                    await connection.InvokeAsync("LeaveRoom", roomid);
                    this.Close();
                    var checkroom = await coopService.DeleteRoom(accesstoken, roomid);
                    if (checkroom)
                        await connection.InvokeAsync("DeleteRoom", roomid);

                    axWindowsMediaPlayerVideo.Ctlcontrols.pause();
                }
            }
        }
    }
}
