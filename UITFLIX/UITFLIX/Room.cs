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
using System.Windows.Forms;
using UITFLIX.Controllers;
using UITFLIX.Models;
using UITFLIX.Services;
using WMPLib;

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
            toolTip = new ToolTip();
            coopService = new CoopService();
            userService = new UserService();

            userinfo = in4;

            this.roomid = roomid;
            IDRoom.Text = roomid;
            //this.Controls.Remove(axWindowsMediaPlayer);
            this.axWindowsMediaPlayerVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.Controls.Add(axWindowsMediaPlayerVideo);
            axWindowsMediaPlayerVideo.Size = new Size(1060, 562);
            axWindowsMediaPlayerVideo.Location = new Point(12, 79);
            IntializeEvent();
            namefilm.Text = "";
            axWindowsMediaPlayerVideo.PlayStateChange += OnPlayStateChange;

        }

        public async Task IntializeEvent()
        {
            connection = new HubConnectionBuilder()
                    .WithUrl(huburl)
                    .Build();
            await StartConnection();
            await UserJoined(roomid);
            if (!axWindowsMediaPlayerVideo.IsHandleCreated)
            {
                var handle = axWindowsMediaPlayerVideo.Handle; 
            }
            lbname.Text = userinfo["user"]["fullname"].ToString();
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
                listchatgroup.ForeColor = Color.Red;
                listchatgroup.Items.Add("Connection Started");
            }
            catch (Exception ex)
            {
                listchatgroup.Items.Add($"{ex.Message}");
            }
        }
        private async Task RegisterEvent()
        {

            connection.On<string, string>("ReceivedMessage", (user, message) =>
            {
                string messages = $"{user}: {message}";
                listchatgroup.Invoke(new Action(() =>
                {
                    listchatgroup.ForeColor = Color.MidnightBlue;
                    listchatgroup.Items.Add(messages);

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
                        dgvQueue.Rows.Clear();
                        for (int i = 0; i < movies.Count(); i++)
                        {
                            var getmovie = await videoService.GetVideoByID(accesstoken, movies[i]);
                            if (getmovie != null && getmovie.ContainsKey("title") && getmovie.ContainsKey("tag"))
                            {
                                dgvQueue.RowsDefaultCellStyle.ForeColor = Color.MidnightBlue;
                                //MessageBox.Show(getmovie.ToString());
                                dgvQueue.Invoke(new Action(() =>
                                {
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
                        MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
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
                            axWindowsMediaPlayerVideo.Ctlcontrols.stop();
                            axWindowsMediaPlayerVideo.URL = null;
                            axWindowsMediaPlayerVideo.URL = stream;
                            axWindowsMediaPlayerVideo.Ctlcontrols.play();
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Test");
                    }
                    this.Cursor= Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
                }
            });

            connection.On<double>("ReceivePlaybackPosition", position =>
            {
                if (Math.Abs(axWindowsMediaPlayerVideo.Ctlcontrols.currentPosition - position) > 1)
                {
                    axWindowsMediaPlayerVideo.Ctlcontrols.currentPosition = position;
                }
            });
        }
        private void OnPlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //MessageBox.Show("check");
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded || axWindowsMediaPlayerVideo.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                // MessageBox.Show("Video ended or stopped. Playing next video...");
                PlayVideo();
            }
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                StartSyncTimer();
            }
            else if (e.newState == (int)WMPLib.WMPPlayState.wmppsStopped || e.newState == (int)WMPLib.WMPPlayState.wmppsPaused)
            {
                StopSyncTimer();
            }
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
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
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
                    {
                        PlayVideo();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể thêm video");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }
        }

        private async void linkleaveroom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var res = MessageBox.Show("Do you wanna leave room?", "Question", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                var response = await coopService.LeaveRoom(accesstoken, roomid);
                if (response)
                {
                    await connection.InvokeAsync("SendMessage", userinfo["user"]["fullname"].ToString(), roomid, "has left room");
                    await connection.InvokeAsync("LeaveRoom", roomid);
                    /*this.Hide();
                    new Home(userinfo, null, accesstoken).ShowDialog();*/
                    this.Close();
                    var checkroom = await coopService.DeleteRoom(accesstoken, roomid);
                    if (checkroom)
                    {
                        await connection.InvokeAsync("DeleteRoom", roomid);
                    }
                }
            }
        }

        private void StartSyncTimer()
        {
            playback = new System.Windows.Forms.Timer { Interval = 1000 }; //Gui video moi 1s
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
        private async Task PlayVideo()
        {
            videoqueue = await coopService.GetVideoQueue(accesstoken, roomid);
            if (videoqueue == null)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            await PlayNextVideo();
        }

        private async Task PlayNextVideo()
        {
            if (videoqueue == null || videoqueue.Count == 0)
            {
                return;
            }

            try
            {
                var videoid = videoqueue[index].ToString();
                //MessageBox.Show(videoid);
                if (videoid != null)
                {
                    await connection.InvokeAsync("PlayVideo", roomid, videoid);
                    var getmovie = await videoService.GetVideoByID(accesstoken, videoid);

                    if (getmovie != null)
                    {
                        await connection.InvokeAsync("SendMessage", getmovie["title"].ToString(), roomid, $"is playing.");
                    }
                }
                index++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể phát video! \n" + ex.Message);
            }
        }
    }
}
