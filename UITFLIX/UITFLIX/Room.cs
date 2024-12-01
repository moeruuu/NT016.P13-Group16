using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private static JToken getvideo;
        private static string temp;
        public Room(string token, string roomid)
        {
            InitializeComponent();
            accesstoken = token;
            videoService = new VideoService();
            toolTip = new ToolTip();
            coopService = new CoopService();
            this.roomid = roomid;

            ShowRCMVideo();

            IDRoom.Text = roomid;
            HookUpEvent();

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
                            Size = new Size(200, 200)
                        };
                        getvideo = video;
                        item.Click += (sender, e) => item.Click += async (sender, e) =>
                        {
                            try
                            {

                                string videoid = video["id"].ToString();
                                var title = await AddToQueue(videoid);
                                if (!string.IsNullOrEmpty(title))
                                {
                                    coopService.OnVideoAddedToQueue(roomid, videoid, title);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi thêm video vào hàng đợi: {ex.Message}");
                            }
                        };
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
        public async Task HookUpEvent()
        {
            coopService.RoomCreated += roomid => MessageBox.Show("Phòng đã được tạo!");
            coopService.RoomDeleted += roomid => MessageBox.Show("Phòng đã bị xóa!");
            coopService.UserJoined += userid =>
            {
                if (listusers.InvokeRequired)
                {
                    listusers.Invoke((MethodInvoker)(() => listusers.Items.Add(userid)));
                }
                else
                {
                    listusers.Items.Add(userid);
                }
            };
            coopService.UserLeft += userid =>
            {
                if (listusers.InvokeRequired)
                {
                    listusers.Invoke((MethodInvoker)(() => listusers.Items.Remove(userid)));
                }
                else
                {
                    listusers.Items.Remove(userid);
                }
            };
            coopService.ChatReceived += (user, message) => listchatgroup.Items.Add($"{user}: {message}");
            coopService.VideoAddedToQueue += (roomid, videoid, title) =>
            {
                if (this.roomid == roomid)
                {
                    listqueuevideo.Items.Add(title);
                }
            };
            coopService.VideoPlayed += videoid => PlayVideo();
            coopService.VideoPaused += videoid => PauseVideo();

            await coopService.StartConnection();
        }

        public async Task PlayVideo()
        {
            try
            {
                axWindowsMediaPlayer.Ctlcontrols.stop();
                axWindowsMediaPlayer.URL = null;
                var id = getvideo["id"].ToString();
                var stream = await videoService.PlayVideo(id, accesstoken);
                if (stream != null)
                {
                    temp = stream;
                    axWindowsMediaPlayer.URL = stream;
                    axWindowsMediaPlayer.Ctlcontrols.play();
                    //MessageBox.Show(temp.ToString());
                }

                await videoService.SaveWatchedVideo(getvideo["id"].ToString(), accesstoken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<string> AddToQueue(string id)
        {
            try
            {
                var videoinfo = await videoService.GetVideoByID(accesstoken, id);
                return videoinfo["title"].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task PauseVideo()
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
        }

        private void linkleaveroom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
