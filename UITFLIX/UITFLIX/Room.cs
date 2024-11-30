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
        public Room(string token, VideoService video)
        {
            InitializeComponent();
            accesstoken = token;
            videoService = video;
            toolTip = new ToolTip();
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
                        //item.Click += (sender, e) => OpenNewForm(video);
                        toolTip.SetToolTip(item, video["title"].ToString());
                        rcmvideopanel.Controls.Add(item);
                    }
                }
            }
            catch(Exception ex) 
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
            coopService.UserJoined += userid => listusers.Items.Add(userid);
            coopService.UserLeft += userid => listusers.Items.Remove(userid);
            coopService.ChatReceived += (user, message) => listchatgroup.Items.Add($"{user}: {message}");
            coopService.VideoAddedToQueue += (roomid, videoid) => listqueuevideo.Items.Add(videoid);

            coopService.StartConnection();
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

    }
}
