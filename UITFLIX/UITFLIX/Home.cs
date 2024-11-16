﻿using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using UITFLIX.Models;
using UITFLIX.Services;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;

namespace UITFLIX
{
    public partial class Home : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };
        private IconButton currentbtn;
        private Panel leftborderBtn;
        private bool MainVisible = true;
        private bool OtherVisible = false;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        // private string content;
        private static long size;
        //List<Video> videos = GetUploadedVideos();
        private JObject Userinfo;

        private readonly VideoService videoService;

        private static string selectedvideofile;
        private static string selectedimagefile;
        public Home(JObject in4, VideoService video)
        {
            InitializeComponent();
            leftborderBtn = new Panel();
            leftborderBtn.Size = new Size(10, 105);
            leftside.Controls.Add(leftborderBtn);
            DrawCircular(Avatar);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Mở new videos ngay khi mở form
            btnnewvideo_Click(btnnewvideo, EventArgs.Empty);

            Userinfo = in4;
            videoService = video;
            setUserinfo();
        }

        public struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 255, 153);
            public static Color color2 = Color.FromArgb(153, 204, 255);
            public static Color color3 = Color.FromArgb(255, 153, 204);
            public static Color color4 = Color.FromArgb(153, 255, 204);
            public static Color color5 = Color.FromArgb(255, 153, 153);
        }
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

        private async void btnnewvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            try
            {
                var json = await videoService.GetNewestVideosAsync(Userinfo["access_token"].ToString());
                JArray videos = JArray.Parse(json.ToString());
                if (videos != null && videos.Count > 0)
                {
                    for (int i = 0; i < videos.Count; i++)
                    {
                        var video = videos[i];
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
                                    var imageBytes = await client.GetByteArrayAsync(imageurl);
                                    using (var ms = new MemoryStream(imageBytes))
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
                        }

                        Label currentname = (Label)this.Controls.Find($"filmname{i + 1}", true).FirstOrDefault();
                        if (currentname != null)
                        {
                            currentname.Visible = true;
                            currentname.Text = video["title"].ToString();
                            SetLabelText(currentname.Text, 11);
                        }

                        Label currentevent = (Label)this.Controls.Find($"event{i + 1}", true).FirstOrDefault();
                        if (currentevent != null)
                        {
                            currentevent.Visible = true;
                            currentevent.Text = video["title"].ToString();
                            SetLabelText(currentevent.Text, 11);
                        }
                    }
                }
                else
                {
                    information.Visible = true;
                }
            }
            catch(Exception ex) {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }

        }

        private void btntopvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);

        }

        private void btnwatchedvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            VisibleUpload(MainVisible);
            VisibleCoop(OtherVisible);
            VisibleTopPanel(OtherVisible);
            filevideo.Text = "";
            fileimage.Text = "";
        }

        private void btncoop_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            VisibleCoop(MainVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(OtherVisible);
        }

        public void DrawCircular(PictureBox pictureBox)
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(0, 0, width, height);
            pictureBox.Region = new Region(circlePath);
        }

        private void VisibleUpload(bool Visible)
        {
            btnchoosefile.Visible = Visible;
            btnchooseimage.Visible = Visible;
            filevideo.Visible = Visible;
            fileimage.Visible = Visible;
            tbdescription.Visible = Visible;
            tbnamefilm.Visible = Visible;
            progressupload.Visible = Visible;
            tenphim.Visible = Visible;
            noidung.Visible = Visible;
            btnuploadvideo.Visible = Visible;
        }

        public void VisibleCoop(bool Visible)
        {
            idroom.Visible = Visible;
            tbidroom.Visible = Visible;
            btnidroom.Visible = Visible;
            linkcreateroom.Visible = Visible;
        }
        public void VisibleTopPanel(bool Visible)
        {
            chat.Visible = Visible;
            toppanel.Visible = Visible;
        }

        //viết cho upload video
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
        //Lấy url để setava
        //thực hiện các tác vụ liên quan đến giao tiếp HTTP
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
            string defaultImageUrl = "https://i.pinimg.com/736x/62/ee/b3/62eeb37155f0df95a708586aed9165c5.jpg";
            using (var client = new HttpClient())
            {
                var imageBytes = client.GetByteArrayAsync(defaultImageUrl).Result;
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }

        //Hihi lấy tên tối đa =)))
        private string SetLabelText(string text, int maxLength)
        {
            //int maxLength = 15;
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }
            else
            {
                return text;
            }
        }

        private void setUserinfo()
        {
            Username.Text = Userinfo["user"]["fullname"].ToString();
            LoadImageFromUrl(Userinfo["user"]["profilepicture"].ToString());

        }

        private async void btnuploadvideo_Click(object sender, EventArgs e)
        {
            try
            {

                btnupload.Enabled = false;
                if (tbnamefilm.Text == null || tbdescription.Text == null)
                {
                    MessageBox.Show("Vui lòng ghi tên phim hoặc mô tả!");
                    return;
                }
                if (selectedimagefile == null || selectedvideofile == null)
                {
                    MessageBox.Show("Vui lòng chọn file!");
                }
                FileInfo fileInfo = new FileInfo(selectedvideofile);
                var size = fileInfo.Length;
                if (size > 100000000)
                { MessageBox.Show("Dung lượng video quá lớn!");
                    return;
                }

                var progress = new Progress<int>(percent =>
                {
                    progressupload.Value = percent;  
                });
                /* if (await videoService.UploadVideoAsync(selectedvideofile, selectedimagefile, tbnamefilm.Text.Trim(), tbdescription.Text.Trim(), size.ToString()))
                     MessageBox.Show("Upload video thành công!");
                 else
                     MessageBox.Show("Không thể upload video");*/
                await videoService.UploadVideoAsync(selectedvideofile, selectedimagefile, tbnamefilm.Text.Trim(), tbdescription.Text.Trim(), size.ToString(), Userinfo["access_token"].ToString(), progress);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }

        }

        /*private void DisplayVideos(List<Video> videos)
        {

            PictureBox[] pictureBoxes = { picfilm1, picfilm2, picfilm3, picfilm4, picfilm5, picfilm6 };
            Label[] titleLabels = { filmname1, filmname2, filmname3, filmname4, filmname5, filmname6 };
            Label[] dateLabels = { event1, event2, event3, event4, event5, event6 };

            //hiển thị số lượng PictureBox và Label phù hợp với số lượng video
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (i < videos.Count)
                {
                    pictureBoxes[i].Visible = true;
                    titleLabels[i].Visible = true;
                    dateLabels[i].Visible = true;
                    pictureBoxes[i].Image = Image.FromFile(videos[i].urlimage);
                    titleLabels[i].Text = videos[i].Title;
                    dateLabels[i].Text = videos[i].uploaddate.ToString();
                }
                else
                {
                    pictureBoxes[i].Visible = false;
                    titleLabels[i].Visible = false;
                    dateLabels[i].Visible = false;
                }
            }

        }*/

        /*private List<Video> GetUploadedVideos()
        {

        }*/
    }
}
