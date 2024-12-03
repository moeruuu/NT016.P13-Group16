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
        private readonly UserService userService;

        private static JToken getvideo;
        private static string temp;

        
        public Room(string token, string roomid)
        {
            InitializeComponent();
            accesstoken = token;
            videoService = new VideoService();
            toolTip = new ToolTip();
            coopService = new CoopService();
            userService = new UserService();
            this.roomid = roomid;

            ShowRCMVideo();



            IDRoom.Text = roomid;

        }

        public async Task CreateRoom()
        {
            coopService.RoomCreated += roomId =>
            {
                MessageBox.Show($"Room {roomId} has been created!");
            };

            coopService.UserJoined += fullname =>
            {
                listusers.Items.Add( fullname );
            };

            await coopService.StartConnection();
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
                        //item.Click += (sender, e) =>
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
                var jobject = await coopService.JoinRoom(roomid, accesstoken);
               // var user = await userService.GetUse
                if (jobject != null)
                {
                    listchatgroup.Items.Add($"đã tham gia phòng");
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
       
    }
}
