﻿using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using MongoDB.Bson;
using System.ComponentModel;
using System.Reflection;
using UITFLIX.Models;
using UITFLIX.Services;
using UITFLIX.Controllers;
using Microsoft.VisualBasic.ApplicationServices;

namespace UITFLIX
{
    public partial class Home : Form
    {
        private IconButton currentbtn;
        private Panel leftborderBtn;
        private ToolTip toolTip;
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private static long size;        // private string content;

        private JObject Userinfo;

        private readonly UserService userService;
        private readonly VideoService videoService;
        private readonly CoopService coopService;
        private readonly MailService chatService;
        private static VideoControl selectedVideoItem;


        private static string selectedvideofile;
        private static string selectedimagefile;


        private string accesstoken;

        public static Point? homeLocation;

        public Home(JObject in4, VideoService video, string token)
        {
            if (homeLocation.HasValue)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = homeLocation.Value;
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            toolTip = new ToolTip();
            userService = new UserService();
            coopService = new CoopService();
            Userinfo = in4;
            videoService = video;
            accesstoken = token;
            chatService = new MailService(token);
            setUserinfo();

            leftborderBtn = new Panel();
            leftborderBtn.Size = new Size(10, 84);
            leftside.Controls.Add(leftborderBtn);
            DrawCircular(Avatar);
            toolTip.SetToolTip(Username, in4["user"]["fullname"].ToString());

            searchtb.Text = " Search";
            searchtb.ForeColor = Color.CadetBlue;
            searchtb.Font = new Font(searchtb.Font.FontFamily, 14);
            searchtb.Font = new Font(searchtb.Font, FontStyle.Italic);
            searchtb.ScrollBars = RichTextBoxScrollBars.None;

            toolTip.SetToolTip(btnSearch, "Search");
            toolTip.SetToolTip(logout, "Exit");
            toolTip.SetToolTip(chat, "Chat to admin");
            toolTip.SetToolTip(pictureBoxDonate, "Donate");
            toolTip.SetToolTip(iconDeleteVideo, "Remove");

            //Mở new videos ngay khi mở form
            this.Load += (s, e) => btnnewvideo.PerformClick();
        }

        //Set info user
        private void setUserinfo()
        {
            Username.Text = Userinfo["user"]["fullname"].ToString();
            Username.Location = new Point((avatarpanel.Width - Username.Width) / 2, Username.Location.Y);
            LoadImageFromUrl(Userinfo["user"]["profilepicture"].ToString());
        }

        //Lấy tên user tối đa =)))
        private string SetLabelText(string text, int max)
        {
            if (text.Length > max) return text.Substring(0, max) + "...";
            else return text;
        }

        //Vẽ avatar
        public void DrawCircular(PictureBox pictureBox)
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(0, 0, width, height);
            pictureBox.Region = new Region(circlePath);
        }

        //Lấy url để setava
        private async void LoadImageFromUrl(string imageUrl)
        {
            using (var client = new HttpClient())
            {
                // Kiểm tra URL hợp lệ không
                if (Uri.TryCreate(imageUrl, UriKind.Absolute, out var uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        if (ms != null && ms.CanRead)
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            Image image = Image.FromStream(ms);
                            Avatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    Avatar.Image = LoadDefaultImage();
                }
            }
        }

        private Image LoadDefaultImage()
        {
            string defaulturl = "https://i.pinimg.com/736x/62/ee/b3/62eeb37155f0df95a708586aed9165c5.jpg";
            using (var client = new HttpClient())
            {
                var bytes = client.GetByteArrayAsync(defaulturl).Result;
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }

        //Mở form Update Info
        private void Username_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            homeLocation = this.Location;
            new UpdateInformation(Userinfo, accesstoken).ShowDialog();
            this.Close();
        }

        //Màu thanh tabbar
        public struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 255, 153);
            public static Color color2 = Color.FromArgb(153, 204, 255);
            public static Color color3 = Color.FromArgb(255, 153, 204);
            public static Color color4 = Color.FromArgb(153, 255, 204);
            public static Color color5 = Color.FromArgb(255, 153, 153);
        }

        //Chọn option tabbar
        private void ActiveButton(object senderBtn, Color color)
        {
            DisableButton();
            if (senderBtn != null)
            {
                currentbtn = (IconButton)senderBtn;
                currentbtn.BackColor = Color.FromArgb(0, 51, 51);
                currentbtn.ForeColor = color;
                currentbtn.TextAlign = ContentAlignment.MiddleCenter;
                currentbtn.IconColor = color;
                currentbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentbtn.TextAlign = ContentAlignment.MiddleRight;

                leftborderBtn.BackColor = color;
                leftborderBtn.Location = new Point(0, currentbtn.Location.Y);
                leftborderBtn.Visible = true;
                leftborderBtn.BringToFront();
            }
        }

        //hủy chọn option tabbar
        private void DisableButton()
        {
            if (currentbtn != null)
            {
                currentbtn.BackColor = Color.CadetBlue;
                currentbtn.ForeColor = Color.White;
                currentbtn.TextAlign = ContentAlignment.MiddleLeft;
                currentbtn.IconColor = Color.White;
                currentbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentbtn.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        //Mở form play video
        private async void OpenPlayVIdeoForm(JToken video)
        {
            //MessageBox.Show(video.ToString());
            PVideo videos = new PVideo(video, accesstoken, videoService, Userinfo);
            videos.ShowDialog();
        }

        //Tab New Video
        private async void btnnewvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            VisibleCoop(false);
            VisibleUpload(false);
            VisibleTopPanel(true);
            bottompanel.Visible = true;
            progressupload.Visible = true;
            information.Visible = false;
            iconDeleteVideo.Visible = false;

            fpnVideos.Controls.Clear();
            fpnVideos.Visible = true;

            try
            {
                this.Enabled = false;
                progressupload.Minimum = 0;
                var jarray = await videoService.GetNewestVideosAsync(accesstoken);
                if (jarray != null)
                    progressupload.Maximum = jarray.Count;
                else
                    progressupload.Maximum = 1;
                progressupload.Value = 0;

                if (jarray != null && jarray.Count > 0)
                {
                    foreach (JToken video in jarray)
                    {
                        progressupload.Value++;

                        VideoControl item = new VideoControl()
                        {
                            Title = SetLabelText(video["title"].ToString(), 14),
                            Sub = video["uploadedDate"].ToObject<DateTime>().ToUniversalTime().ToString("dd/MM/yyyy"),
                            ImageUrl = video["urlImage"].ToString()
                        };

                        item.Click += (sender, e) => OpenPlayVIdeoForm(video);
                        toolTip.SetToolTip(item, $"[{video["tag"].ToString()}] {video["title"].ToString()}");
                        fpnVideos.Controls.Add(item);
                    }
                }
                else
                    information.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressupload.Visible = false;
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }

        }

        //Tab Top Video
        private async void btntopvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            VisibleCoop(false);
            VisibleUpload(false);
            VisibleTopPanel(true);
            bottompanel.Visible = true;
            progressupload.Visible = true;
            information.Visible = false;
            iconDeleteVideo.Visible = false;

            fpnVideos.Controls.Clear();
            fpnVideos.Visible = true;

            try
            {
                this.Enabled = false;
                progressupload.Minimum = 0;

                var jarray = await videoService.GetTopVideos(accesstoken);
                if (jarray != null)
                    progressupload.Maximum = jarray.Count;
                else
                    progressupload.Maximum = 1;
                progressupload.Value = 0;

                if (jarray != null && jarray.Count > 0)
                {
                    foreach (JToken video in jarray)
                    {
                        progressupload.Value++;
                        if (video["rating"].ToString() == "0") continue;

                        VideoControl item = new VideoControl()
                        {
                            Title = SetLabelText(video["title"].ToString(), 14),
                            Sub = Math.Round(double.Parse(video["rating"].ToString()), 1).ToString() + " ★",
                            ImageUrl = video["urlImage"].ToString()
                        };

                        item.Click += (sender, e) => OpenPlayVIdeoForm(video);
                        toolTip.SetToolTip(item, $"[{video["tag"].ToString()}] {video["title"].ToString()}");
                        fpnVideos.Controls.Add(item);
                    }
                }
                else
                    information.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                progressupload.Visible = false;
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        //Tab Watched Video
        private async void btnwatchedvideo_Click(object sender, EventArgs e)
        {
            await RefreshWatchedVideos();
        }

        private async Task RefreshWatchedVideos()
        {
            ActiveButton(btnwatchedvideo, RGBColors.color3);
            VisibleCoop(false);
            VisibleUpload(false);
            VisibleTopPanel(true);
            bottompanel.Visible = true;
            waiting.Visible = false;
            information.Visible = false;
            iconDeleteVideo.Visible = true;

            fpnVideos.Controls.Clear();
            fpnVideos.Visible = true;

            try
            {
                this.Enabled = false;
                progressupload.Minimum = 0;

                var jarray = await videoService.GetWatchedVideos(accesstoken);
                if (jarray != null)
                    progressupload.Maximum = jarray.Count;
                else
                    progressupload.Maximum = 1;
                progressupload.Value = 0;

                if (jarray != null && jarray.Count > 0)
                {
                    foreach (JToken video in jarray)
                    {
                        progressupload.Value++;

                        VideoControl item = new VideoControl()
                        {
                            Title = SetLabelText(video["video"]["title"].ToString(), 14),
                            Sub = "Watched on: " + video["watchedTime"].ToObject<DateTime>().ToUniversalTime().ToString("dd/MM/yyyy"),
                            ImageUrl = video["video"]["urlImage"].ToString(),
                            Tag = video["id"]
                        };

                        JToken reVid = video["video"];
                        item.DoubleClick += (sender, e) => OpenPlayVIdeoForm(reVid);
                        toolTip.SetToolTip(item, $"[{video["video"]["tag"].ToString()}] {video["video"]["title"].ToString()}");
                        selectedVideoItem = null;
                        item.Click += (sender, e) => HighlightVideo(item, reVid);
                        fpnVideos.Controls.Add(item);
                    }
                }
                else
                    information.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressupload.Visible = false;
                this.Enabled = true;
            }
        }

        private void HighlightVideo(VideoControl item, JToken video)
        {
            if (selectedVideoItem != null)
            {
                selectedVideoItem.BackColor = Color.LightBlue;
                selectedVideoItem.BorderStyle = BorderStyle.None;
                selectedVideoItem.Padding = new Padding(0);
            }
            selectedVideoItem = item;
            item.BackColor = Color.Teal;
            item.ForeColor = Color.LightBlue;
            item.BorderStyle = BorderStyle.FixedSingle;
            item.Padding = new Padding(5);
            Color paddingColor = Color.LightBlue;
            if (item.Tag == null)
                item.Tag = video["id"]?.ToString();
        }

        //Xóa watched video
        private async void iconDeleteVideo_Click(object sender, EventArgs e)
        {
            if (selectedVideoItem != null && selectedVideoItem.Tag != null)
            {
                var res = MessageBox.Show("Would you like to remove this video from your watched videos?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string videoId = selectedVideoItem.Tag.ToString();
                    await DeleteWatchedVideo(videoId);
                }
            }
            else
                MessageBox.Show("Unable to find the video to remove!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async Task DeleteWatchedVideo(string videoId)
        {
            try
            {
                var result = await videoService.RemoveWatchedVideo(videoId, accesstoken);
                if (result)
                {
                    await RefreshWatchedVideos();
                    MessageBox.Show("The selected video was removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Unable to remove the selected video!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tab Upload Video
        private void btnupload_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            VisibleUpload(true);
            VisibleCoop(false);
            VisibleTopPanel(false);

            iconDeleteVideo.Visible = false;
            filevideo.Text = "";
            fileimage.Text = "";
            bottompanel.Visible = false;
            progressupload.Visible = false;
            information.Visible = false;

            fpnVideos.Visible = false;
            fpnVideos.Controls.Clear();
        }

        //Tab Coop 
        private void btncoop_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            VisibleCoop(true);
            VisibleUpload(false);
            VisibleTopPanel(false);

            iconDeleteVideo.Visible = false;
            bottompanel.Visible = false;
            information.Visible = false;

            fpnVideos.Visible = false;
            fpnVideos.Controls.Clear();

        }

        //Hiện các nút Upload
        private void VisibleUpload(bool Visible)
        {
            btnchoosefile.Visible = Visible;
            btnchooseimage.Visible = Visible;
            filevideo.Visible = Visible;
            fileimage.Visible = Visible;
            tbdescription.Visible = Visible;
            tbnamefilm.Visible = Visible;
            tenphim.Visible = Visible;
            noidung.Visible = Visible;
            btnuploadvideo.Visible = Visible;
            cbtag.Visible = Visible;
            tag.Visible = Visible;
        }

        //Hiện các nút Coop
        public void VisibleCoop(bool Visible)
        {
            idroom.Visible = Visible;
            tbidroom.Visible = Visible;
            btnidroom.Visible = Visible;
            linkcreateroom.Visible = Visible;
        }

        //Hiện thanh search
        public void VisibleTopPanel(bool Visible)
        {
            chat.Visible = Visible;
            toppanel.Visible = Visible;
        }

        //Upload video
        private void btnchoosefile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv;*.flv;*.webm";
            openFileDialog.Title = "Select a Video File";
            openFileDialog.ShowDialog();
            selectedvideofile = openFileDialog.FileName;

            string getname = Path.GetFileNameWithoutExtension(selectedvideofile);
            string getextensions = Path.GetExtension(selectedvideofile);
            filevideo.Text = SetLabelText(getname, 15) + getextensions;
        }

        private void btnchooseimage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.webp;*.svg";
            openFileDialog.Title = "Select an Image File";
            openFileDialog.ShowDialog();
            selectedimagefile = openFileDialog.FileName;
            string getname = Path.GetFileNameWithoutExtension(selectedimagefile);
            string getextensions = Path.GetExtension(selectedimagefile);
            FileInfo info = new FileInfo(selectedimagefile);
            size = info.Length;
            fileimage.Text = SetLabelText(getname, 15) + getextensions;
        }

        private async void btnuploadvideo_Click(object sender, EventArgs e)
        {
            if (tbnamefilm.Text.Length > 100)
            {
                MessageBox.Show("The movie title cannot exceed 100 characters.");
                return;
            }
            if (tbdescription.Text.Length > 1000)
            {
                MessageBox.Show("The description cannot exceed 1000 characters.");
                return;
            }
            this.Enabled = false;
            waiting.Visible = false;
            information.Visible = false;

            try
            {
                waiting.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                if (tbnamefilm.Text == null || tbdescription.Text == null || cbtag.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the movie title, description, or genre!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnupload.Enabled = true;
                    btnchoosefile.Enabled = true;
                    return;
                }
                if (selectedimagefile == null || selectedvideofile == null)
                {
                    MessageBox.Show("Please selete a file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnupload.Enabled = true;
                    btnchoosefile.Enabled = true;
                    return;
                }
                FileInfo fileInfo = new FileInfo(selectedvideofile);
                var size = fileInfo.Length;
                if (size > 100000000)
                {
                    MessageBox.Show("The video size is too large!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnupload.Enabled = true;
                    btnchoosefile.Enabled = true;
                    return;
                }
                progressupload.Value = 0;

                if (await videoService.UploadVideoAsync(selectedvideofile, selectedimagefile, tbnamefilm.Text.Trim(), tbdescription.Text.Trim(), cbtag.SelectedItem.ToString(), Userinfo["access_token"].ToString()))
                {

                    MessageBox.Show("Uploaded video successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbdescription.Clear();
                    tbnamefilm.Clear();
                    fileimage.Text = "";
                    filevideo.Text = "";
                    selectedvideofile = "";
                    selectedimagefile = "";
                    cbtag.SelectedIndex = 0;
                }
                else
                    MessageBox.Show("An error has occurred!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                waiting.Visible = false;
                this.Enabled = true;
            }

        }

        //Button search
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            if (String.IsNullOrEmpty(searchtb.Text) || searchtb.Text == " Search")
            {
                searchtb.Text = " Search";
                searchtb.ForeColor = Color.CadetBlue;
                searchtb.Font = new Font(searchtb.Font, FontStyle.Italic);
                information.Visible = true;
                progressupload.Visible = false;
                return;
            }

            progressupload.Visible = true;
            DisableButton();
            leftborderBtn.Visible = false;
            VisibleCoop(false);
            VisibleUpload(false);
            information.Visible = false;

            fpnVideos.Controls.Clear();
            fpnVideos.Visible = true;

            try
            {
                this.Enabled = false;
                var findvideos = await videoService.SearchVideos(searchtb.Text.Trim(), accesstoken);

                if (findvideos != null)
                    progressupload.Maximum = findvideos.Count;
                else
                    progressupload.Maximum = 1;
                progressupload.Value = 0;

                if (findvideos != null && findvideos.Count > 0)
                {
                    foreach (JToken video in findvideos)
                    {
                        progressupload.Value++;

                        VideoControl item = new VideoControl()
                        {
                            Title = SetLabelText(video["title"].ToString(), 14),
                            Sub = video["uploadedDate"].ToObject<DateTime>().ToUniversalTime().ToString("dd/MM/yyyy"),
                            ImageUrl = video["urlImage"].ToString()
                        };

                        item.Click += (sender, e) => OpenPlayVIdeoForm(video);
                        toolTip.SetToolTip(item, video["title"].ToString());
                        fpnVideos.Controls.Add(item);
                    }
                }
                else
                    information.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressupload.Visible = false;
                this.Enabled = true;
            }
        }
        private void searchtb_Enter(object sender, EventArgs e)
        {
            searchtb.Text = string.Empty;
            searchtb.ForeColor = Color.MidnightBlue;
            searchtb.Font = new Font(searchtb.Font, FontStyle.Regular);
        }

        private void searchtb_Leave(object sender, EventArgs e)
        {
            if (searchtb.Text == string.Empty)
            {
                searchtb.Text = " Search";
                searchtb.ForeColor = Color.CadetBlue;
                searchtb.Font = new Font(searchtb.Font, FontStyle.Italic);
            }
        }

        private void searchtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;
                e.SuppressKeyPress = true;
                btnSearch_Click(btnSearch, EventArgs.Empty);
            }
        }

        //Logout
        private async void logout_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Do you want to exit?", "LogOut", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                var LogOutModel = new
                {
                    Id = Userinfo["user"]["id"].ToString()
                };
                var response = await userService.LogOut(LogOutModel, accesstoken);
                if (response.Contains("successfully!", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    LogIn login = new LogIn();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        //Tạo room xem coop
        private async void linkcreateroom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var roomid = await coopService.CreateRoom(accesstoken);
            if (roomid != null)
                new Room(accesstoken, roomid["room"]["roomId"].ToString(), Userinfo).ShowDialog();
            else
                MessageBox.Show("Unable to create a coop room");
        }

        //Chat với admin
        private void chat_Click(object sender, EventArgs e)
        {
            string token = accesstoken.ToString();
            Chat chat = new Chat(Userinfo, token);
            chat.Show();
        }

        private async void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            var LogOutModel = new
            {
                Id = Userinfo["user"]["id"].ToString()
            };
            var response = await userService.LogOut(LogOutModel, accesstoken);
        }

        //Nhập id room coop
        private async void btnidroom_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbidroom.Text == null)
                {
                    MessageBox.Show("Please enter the room ID!");
                    return;
                }

                var res = await coopService.FindRoom(accesstoken, tbidroom.Text.Trim());
                if (res)
                {
                    new Room(accesstoken, tbidroom.Text.Trim(), Userinfo).ShowDialog();
                    tbidroom.Text = null;
                }
                else
                    MessageBox.Show("This room does not exist!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Donate
        private void pictureBoxDonate_Click(object sender, EventArgs e)
        {
            Donate donate = new Donate(accesstoken);
            donate.ShowDialog();
        }
    }

}
