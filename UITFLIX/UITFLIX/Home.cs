﻿using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using UITFLIX.Models;
using UITFLIX.Services;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using MongoDB.Bson;
using System.ComponentModel;
using System.Reflection;
using UITFLIX.Controllers;

namespace UITFLIX
{
    public partial class Home : Form
    {
        private IconButton currentbtn;
        private Panel leftborderBtn;
        private bool MainVisible = true;
        private bool OtherVisible = false;
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private static long size;        // private string content;

        private JObject Userinfo;

        private readonly UserService userService;
        private readonly VideoService videoService;

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
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            InitializeComponent();
            userService = new UserService();
            Userinfo = in4;
            videoService = video;
            accesstoken = token;
            setUserinfo();

            leftborderBtn = new Panel();
            leftborderBtn.Size = new Size(10, 105);
            leftside.Controls.Add(leftborderBtn);
            DrawCircular(Avatar);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Mở new videos ngay khi mở form
            btnnewvideo_Click(btnnewvideo, EventArgs.Empty);
        }

        //set info user
        private void setUserinfo()
        {
            Username.Text = Userinfo["user"]["fullname"].ToString();
            LoadImageFromUrl(Userinfo["user"]["profilepicture"].ToString());

        }

        //lấy tên user tối đa =)))
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

        //chọn option tabbar
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

        //clear video trên một form tabbar để mở form tabbar mới
        private void ClearAllVideoControls()
        {
            for (int i = 1; i <= 6; i++)
            {
                PictureBox pic = (PictureBox)this.Controls.Find($"picfilm{i}", true).FirstOrDefault();
                Label name = (Label)this.Controls.Find($"filmname{i}", true).FirstOrDefault();
                Label eventLabel = (Label)this.Controls.Find($"event{i}", true).FirstOrDefault();

                if (pic != null)
                {
                    pic.Visible = false;
                    pic.Image = null;
                    ResetClickEvent(pic);
                }
                if (name != null)
                {
                    name.Visible = false;
                    name.Text = string.Empty;
                    ResetClickEvent(name);
                }
                if (eventLabel != null)
                {
                    eventLabel.Visible = false;
                    eventLabel.Text = string.Empty;
                }
            }
        }

        //Mở form play video
        private void OpenNewForm(JToken video)
        {
            MessageBox.Show(video.ToString());
            PVideo videos = new PVideo(video, accesstoken, videoService, Userinfo);
            videos.ShowDialog();
        }

        private void ResetClickEvent(Control control)
        {
            if (control == null) return;

            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1?.GetValue(control);
            if (obj != null)
            {
                PropertyInfo pi = control.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
                EventHandlerList list = (EventHandlerList)pi?.GetValue(control, null);
                list?.RemoveHandler(obj, list[obj]);
            }
        }

        //tab New Video
        private async void btnnewvideo_Click(object sender, EventArgs e)
        {
            ClearAllVideoControls();
            ActiveButton(sender, RGBColors.color1);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            bottompanel.Visible = true;
            progressupload.Visible = true;
            cbpage.Visible = false;
            information.Visible = false;

            fpnVideos.Controls.Clear();
            fpnVideos.Visible = true;

            try
            {
                this.Enabled = false;
                progressupload.Minimum = 0;

                var jarray = await videoService.GetNewestVideosAsync(accesstoken);
                if (jarray != null)
                {
                    progressupload.Maximum = jarray.Count;
                }
                else
                {
                    progressupload.Maximum = 1;
                }
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

                        item.Click += (sender, e) => OpenNewForm(video);
                        fpnVideos.Controls.Add(item);
                    }
                }
                else
                {
                    information.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {

                progressupload.Visible = false;
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }

        }

        //tab Top Video
        private async void btntopvideo_Click(object sender, EventArgs e)
        {
            ClearAllVideoControls();
            ActiveButton(sender, RGBColors.color2);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            bottompanel.Visible = true;
            progressupload.Visible = true;
            cbpage.Visible = false;
            information.Visible = false;

            fpnVideos.Controls.Clear();
            fpnVideos.Visible = true;

            try
            {
                this.Enabled = false;
                progressupload.Minimum = 0;

                var jarray = await videoService.GetTopVideos(accesstoken);
                if (jarray != null)
                {
                    progressupload.Maximum = jarray.Count;
                }
                else
                {
                    progressupload.Maximum = 1;
                }
                progressupload.Value = 0;

                if (jarray != null && jarray.Count > 0)
                {
                    foreach (JToken video in jarray)
                    {
                        progressupload.Value++;

                        VideoControl item = new VideoControl()
                        {
                            Title = SetLabelText(video["title"].ToString(), 14),
                            Sub = Math.Round(double.Parse(video["rating"].ToString()), 1).ToString() + " ★",
                            ImageUrl = video["urlImage"].ToString()
                        };

                        item.Click += (sender, e) => OpenNewForm(video);
                        fpnVideos.Controls.Add(item);
                    }
                }
                else
                {
                    information.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
            finally
            {

                progressupload.Visible = false;
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }

        }

        //tab Watched Video
        private void btnwatchedvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            bottompanel.Visible = true;
            cbpage.Visible = false;
            waiting.Visible = false;
            information.Visible = false;
        }

        //tab Upload Video
        private void btnupload_Click(object sender, EventArgs e)
        {
            information.Visible = false;
            ActiveButton(sender, RGBColors.color4);
            VisibleUpload(MainVisible);
            VisibleCoop(OtherVisible);
            VisibleTopPanel(OtherVisible);
            filevideo.Text = "";
            fileimage.Text = "";
            bottompanel.Visible = true;
            progressupload.Visible = false;
            cbpage.Visible = false;

            fpnVideos.Visible = false;
            fpnVideos.Controls.Clear();
        }

        //Tab Coop 
        private void btncoop_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            VisibleCoop(MainVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(OtherVisible);
            bottompanel.Visible = false;
            information.Visible = false;
            cbpage.Visible = false;

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
                MessageBox.Show("Tên phim không thể chứa quá 100 kí tự");
                return;
            }
            if (tbdescription.Text.Length > 1000)
            {
                MessageBox.Show("Mô tả không thể chứa quá 1000 kí tự");
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
                    MessageBox.Show("Vui lòng ghi tên phim hoặc mô tả hoặc thể loại!");
                    btnupload.Enabled = true;
                    btnchoosefile.Enabled = true;
                    return;
                }
                if (selectedimagefile == null || selectedvideofile == null)
                {
                    MessageBox.Show("Vui lòng chọn file!");
                    btnupload.Enabled = true;
                    btnchoosefile.Enabled = true;
                    return;
                }
                FileInfo fileInfo = new FileInfo(selectedvideofile);
                var size = fileInfo.Length;
                if (size > 100000000)
                {
                    MessageBox.Show("Dung lượng video quá lớn!");
                    btnupload.Enabled = true;
                    btnchoosefile.Enabled = true;
                    return;
                }
                progressupload.Value = 0;

                if (await videoService.UploadVideoAsync(selectedvideofile, selectedimagefile, tbnamefilm.Text.Trim(), tbdescription.Text.Trim(), cbtag.SelectedItem.ToString(), Userinfo["access_token"].ToString()))
                {

                    MessageBox.Show("Upload video thành công!");
                    tbdescription.Clear();
                    tbnamefilm.Clear();
                    fileimage.Text = "";
                    filevideo.Text = "";
                    selectedvideofile = "";
                    selectedimagefile = "";
                    cbtag.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }
            finally
            {
                waiting.Visible = false;
                this.Enabled = true;
            }

        }

        //button search
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            cbpage.Visible = true;
            progressupload.Visible = true;
            DisableButton();
            leftborderBtn.Visible = false;
            VisibleCoop(false);
            VisibleUpload(false);
            information.Visible = false;

            cbpage.Items.Clear();

            if (String.IsNullOrEmpty(searchtb.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung tìm kiếm!");
                return;
            }
            try
            {
                this.Enabled = false;
                var findvideos = await videoService.SearchVideos(searchtb.Text.Trim(), 1, accesstoken);
                /*MessageBox.Show(searchtb.Text.ToString().Trim());
                MessageBox.Show(findvideos.ToString());*/
                if (findvideos != null)
                {
                    int totalpage = int.Parse(findvideos["totalpage"].ToString());
                    for (int i = 1; i <= totalpage; i++)
                    {
                        cbpage.Items.Add(i.ToString());
                    }
                    cbpage.SelectedIndex = 0;

                    JArray jarray = (JArray)findvideos["videos"];
                    progressupload.Minimum = 0;
                    progressupload.Maximum = jarray.Count;

                    progressupload.Value = 0;
                    for (int i = 0; i < jarray.Count; i++)
                    {
                        progressupload.Value++;
                        JToken video = jarray[i];
                        //MessageBox.Show(video.ToString());
                        PictureBox currentPicBox = (PictureBox)this.Controls.Find($"picfilm{i + 1}", true).FirstOrDefault();

                        if (currentPicBox != null)
                        {
                            currentPicBox.Visible = true;

                            string imageurl = video["urlImage"].ToString();

                            using (var client = new HttpClient())
                            {
                                if (Uri.TryCreate(imageurl, UriKind.Absolute, out var uriResult)
                                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                                {
                                    var bytes = await client.GetByteArrayAsync(imageurl);
                                    using (var ms = new MemoryStream(bytes))
                                    {
                                        if (ms != null && ms.CanRead)
                                        {
                                            ms.Seek(0, SeekOrigin.Begin);

                                            Image image = Image.FromStream(ms);
                                            currentPicBox.Image = Image.FromStream(ms);
                                        }
                                    }
                                }
                                else
                                {
                                    currentPicBox.Image = null;
                                }
                            }
                            currentPicBox.Click += (sender, e) => OpenNewForm(video);
                        }

                        Label currentname = (Label)this.Controls.Find($"filmname{i + 1}", true).FirstOrDefault();
                        if (currentname != null)
                        {
                            currentname.Visible = true;
                            currentname.Text = SetLabelText(video["title"].ToString(), 14);
                            currentname.Click += (sender, e) => OpenNewForm(video);
                        }

                    }
                }
                else
                {
                    cbpage.Items.Add(1);
                    cbpage.SelectedIndex = 0;
                    information.Visible = true;
                }
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

        private async void cbpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = cbpage.SelectedItem;
            int page = int.Parse(cbpage.Text);
            try
            {
                this.Enabled = false;
                var findvideos = await videoService.SearchVideos(searchtb.Text.Trim(), page, accesstoken);
                if (findvideos != null)
                {
                    JArray jarray = (JArray)findvideos["videos"];
                    progressupload.Minimum = 0;
                    progressupload.Maximum = jarray.Count;

                    progressupload.Value = 0;

                    for (int i = 0; i < jarray.Count; i++)
                    {
                        progressupload.Value++;
                        JToken video = jarray[i];
                        PictureBox currentPicBox = (PictureBox)this.Controls.Find($"picfilm{i + 1}", true).FirstOrDefault();

                        if (currentPicBox != null)
                        {
                            currentPicBox.Visible = true;

                            string imageurl = video["urlImage"].ToString();

                            using (var client = new HttpClient())
                            {
                                if (Uri.TryCreate(imageurl, UriKind.Absolute, out var uriResult)
                                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                                {
                                    var bytes = await client.GetByteArrayAsync(imageurl);
                                    using (var ms = new MemoryStream(bytes))
                                    {
                                        if (ms != null && ms.CanRead)
                                        {
                                            ms.Seek(0, SeekOrigin.Begin);

                                            Image image = Image.FromStream(ms);
                                            currentPicBox.Image = Image.FromStream(ms);
                                        }
                                    }
                                }
                                else
                                {
                                    currentPicBox.Image = null;
                                }
                            }
                            currentPicBox.Click += (sender, e) => OpenNewForm(video);
                        }

                        Label currentname = (Label)this.Controls.Find($"filmname{i + 1}", true).FirstOrDefault();
                        if (currentname != null)
                        {
                            currentname.Visible = true;
                            currentname.Text = SetLabelText(video["title"].ToString(), 14);
                            currentname.Click += (sender, e) => OpenNewForm(video);
                        }
                    }
                }
                else
                {
                    cbpage.Items.Add(1);
                    cbpage.SelectedIndex = 0;
                    information.Visible = true;
                }
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

        //LogOut
        private async void logout_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                var LogOutModel = new
                {
                    Id = Userinfo["user"]["id"].ToString()
                };
                var response = await userService.LogOut(LogOutModel, accesstoken);
                if (response.Contains("thành công!", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    MessageBox.Show("Đăng xuất thành công!", "Thành công", MessageBoxButtons.OK);
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

    }

}
