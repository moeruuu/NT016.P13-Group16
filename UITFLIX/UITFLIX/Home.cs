using FontAwesome.Sharp;
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

        private string accesstoken;
        //private readonly UserService userService;
        public Home(JObject in4, VideoService video, string token)
        {
            InitializeComponent();
            leftborderBtn = new Panel();
            leftborderBtn.Size = new Size(10, 105);
            leftside.Controls.Add(leftborderBtn);
            DrawCircular(Avatar);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Mở new videos ngay khi mở form
            // btnnewvideo_Click(btnnewvideo, EventArgs.Empty);

            Userinfo = in4;
            videoService = video;
            accesstoken = token;
            setUserinfo();
            //userService = user;
            //MessageBox.Show(accesstoken);
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
            VisibleImageandLabel(false);
            ActiveButton(sender, RGBColors.color1);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            bottompanel.Visible = true;
            progressupload.Visible = true;
            cbpage.Visible = false;
            try
            {
                progressupload.Minimum = 0;

                //MessageBox.Show(accesstoken);
                // httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Userinfo["access_token"].ToString());
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
                    btncoop.Enabled = false;
                    btntopvideo.Enabled = false;
                    btnnewvideo.Enabled = false;
                    btnwatchedvideo.Enabled = false;
                    btnupload.Enabled = false;
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

                        Label currentevent = (Label)this.Controls.Find($"event{i + 1}", true).FirstOrDefault();
                        if (currentevent != null)
                        {
                            currentevent.Visible = true;
                            DateTime uploadedDate = video["uploadedDate"].ToObject<DateTime>();
                            currentevent.Text = uploadedDate.ToUniversalTime().ToString("dd/MM/yyyy");
                            //SetLabelText(currentevent.Text, 11);
                        }
                    }
                    progressupload.Visible = false;

                    btncoop.Enabled = true;
                    btnnewvideo.Enabled = true;
                    btnwatchedvideo.Enabled = true;
                    btnupload.Enabled = true;
                    btntopvideo.Enabled = true;
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

        }
        private void OpenNewForm(JToken video)
        {
            this.Hide();
            PVideo videos = new PVideo(video, accesstoken, videoService, Userinfo);
            videos.ShowDialog();
            this.Close();
        }
        private async void btntopvideo_Click(object sender, EventArgs e)
        {
            VisibleImageandLabel(false);
            ActiveButton(sender, RGBColors.color2);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            bottompanel.Visible = true;
            progressupload.Visible = true;
            cbpage.Visible = false;
            try
            {
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
                    //tranh nguoi dung an vao trang khac khi dang load
                    btncoop.Enabled = false;
                    btntopvideo.Enabled = false;
                    btnnewvideo.Enabled = false;
                    btnwatchedvideo.Enabled = false;
                    btnupload.Enabled = false;
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

                        Label currentevent = (Label)this.Controls.Find($"event{i + 1}", true).FirstOrDefault();
                        if (currentevent != null)
                        {
                            currentevent.Visible = true;
                            double rate = double.Parse(video["rating"].ToString());
                            double round = Math.Round(rate, 1);

                            currentevent.Text = "Rating: " + round.ToString("0.0");
                            //SetLabelText(currentevent.Text, 11);
                        }
                    }
                    progressupload.Visible = false;
                    btncoop.Enabled = true;
                    btnnewvideo.Enabled = true;
                    btnwatchedvideo.Enabled = true;
                    btnupload.Enabled = true;
                    btntopvideo.Enabled = true;
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

        }

        private void btnwatchedvideo_Click(object sender, EventArgs e)
        {
            VisibleImageandLabel(false);
            ActiveButton(sender, RGBColors.color3);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);
            bottompanel.Visible = true;
            cbpage.Visible = false;
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            VisibleImageandLabel(false);
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
        }

        private void btncoop_Click(object sender, EventArgs e)
        {
            VisibleImageandLabel(false);
            ActiveButton(sender, RGBColors.color5);
            VisibleCoop(MainVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(OtherVisible);
            bottompanel.Visible = false;
            information.Visible = false;
            cbpage.Visible = false;
        }

        public void DrawCircular(PictureBox pictureBox)
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(0, 0, width, height);
            pictureBox.Region = new Region(circlePath);
        }

        private void VisibleImageandLabel(bool Visable)
        {
            picfilm1.Visible = Visable;
            picfilm2.Visible = Visable;
            picfilm3.Visible = Visable;
            picfilm4.Visible = Visable;
            picfilm5.Visible = Visable;
            picfilm6.Visible = Visable;
            filmname1.Visible = Visable;
            filmname2.Visible = Visable;
            filmname3.Visible = Visable;
            filmname4.Visible = Visable;
            filmname5.Visible = Visable;
            filmname6.Visible = Visable;
            event1.Visible = Visable;
            event2.Visible = Visable;
            event3.Visible = Visable;
            event4.Visible = Visable;
            event5.Visible = Visable;
            event6.Visible = Visable;
        }
        private void VisibleUpload(bool Visible)
        {
            btnchoosefile.Visible = Visible;
            btnchooseimage.Visible = Visible;
            filevideo.Visible = Visible;
            fileimage.Visible = Visible;
            tbdescription.Visible = Visible;
            tbnamefilm.Visible = Visible;
            //progressupload.Visible = Visible;
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

        //Hihi lấy tên tối đa =)))
        private string SetLabelText(string text, int max)
        {
            //int max = 15;
            if (text.Length > max)
            {
                return text.Substring(0, max) + "...";
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

            btnchooseimage.Enabled = false;
            btnchoosefile.Enabled = false;
            btnuploadvideo.Enabled = false;
            btncoop.Enabled = false;
            btntopvideo.Enabled = false;
            btnnewvideo.Enabled = false;
            btnwatchedvideo.Enabled = false;
            btnupload.Enabled = false;
            try
            {
                waiting.Visible = true;

                if (tbnamefilm.Text == null || tbdescription.Text == null)
                {
                    MessageBox.Show("Vui lòng ghi tên phim hoặc mô tả!");
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

                /* if (await videoService.UploadVideoAsync(selectedvideofile, selectedimagefile, tbnamefilm.Text.Trim(), tbdescription.Text.Trim(), size.ToString()))
                     MessageBox.Show("Upload video thành công!");
                 else
                     MessageBox.Show("Không thể upload video");*/
                await videoService.UploadVideoAsync(selectedvideofile, selectedimagefile, tbnamefilm.Text.Trim(), tbdescription.Text.Trim(), size.ToString(), Userinfo["access_token"].ToString());
                waiting.Visible = false;

                btncoop.Enabled = true;
                btnnewvideo.Enabled = true;
                btnwatchedvideo.Enabled = true;
                btnupload.Enabled = true;
                btntopvideo.Enabled = true;
                tbdescription.Clear();
                tbnamefilm.Clear();
                fileimage.Text = "";
                filevideo.Text = "";
                selectedvideofile = "";
                selectedimagefile = "";
                btnchoosefile.Enabled = true;
                btnchooseimage.Enabled = true;
                btnuploadvideo.Enabled = true;
            }
            catch (Exception ex)
            {
                waiting.Visible = false;
                btnupload.Enabled = true;
                btnchoosefile.Enabled = true;
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }

        }

        private void picfilm1_MouseEnter(object sender, EventArgs e)
        {
            picfilm1.Size = new Size(picfilm1.Width + 60, picfilm1.Height + 60);
            picfilm1.Location = new Point(picfilm1.Left - 30, picfilm1.Top);
        }

        private void picfilm1_MouseLeave(object sender, EventArgs e)
        {
            picfilm1.Size = new Size(picfilm1.Width - 60, picfilm1.Height - 60);
            picfilm1.Location = new Point(picfilm1.Left + 30, picfilm1.Top);
        }

        private void picfilm2_MouseEnter(object sender, EventArgs e)
        {
            picfilm2.Size = new Size(picfilm2.Width + 60, picfilm2.Height + 60);
            picfilm2.Location = new Point(picfilm2.Left - 30, picfilm2.Top);
        }

        private void picfilm2_MouseLeave(object sender, EventArgs e)
        {
            picfilm2.Size = new Size(picfilm2.Width - 60, picfilm2.Height - 60);
            picfilm2.Location = new Point(picfilm2.Left + 30, picfilm2.Top);
        }

        private void picfilm3_MouseEnter(object sender, EventArgs e)
        {
            picfilm3.Size = new Size(picfilm3.Width + 60, picfilm3.Height + 60);
            picfilm3.Location = new Point(picfilm3.Left - 30, picfilm3.Top);
        }

        private void picfilm3_MouseLeave(object sender, EventArgs e)
        {
            picfilm3.Size = new Size(picfilm3.Width - 60, picfilm3.Height - 60);
            picfilm3.Location = new Point(picfilm3.Left + 30, picfilm3.Top);
        }

        private void picfilm4_MouseEnter(object sender, EventArgs e)
        {
            picfilm4.Size = new Size(picfilm4.Width + 60, picfilm4.Height + 60);
            picfilm4.Location = new Point(picfilm4.Left - 30, picfilm4.Top);
        }

        private void picfilm4_MouseLeave(object sender, EventArgs e)
        {
            picfilm4.Size = new Size(picfilm4.Width - 60, picfilm4.Height - 60);
            picfilm4.Location = new Point(picfilm4.Left + 30, picfilm4.Top);
        }

        private void picfilm5_MouseEnter(object sender, EventArgs e)
        {
            picfilm5.Size = new Size(picfilm5.Width + 60, picfilm5.Height + 60);
            picfilm5.Location = new Point(picfilm5.Left - 30, picfilm5.Top);
        }

        private void picfilm5_MouseLeave(object sender, EventArgs e)
        {
            picfilm5.Size = new Size(picfilm5.Width - 60, picfilm5.Height - 60);
            picfilm5.Location = new Point(picfilm5.Left + 30, picfilm5.Top);
        }

        private void picfilm6_MouseEnter(object sender, EventArgs e)
        {
            picfilm6.Size = new Size(picfilm6.Width + 60, picfilm6.Height + 60);
            picfilm6.Location = new Point(picfilm6.Left - 30, picfilm6.Top);
        }

        private void picfilm6_MouseLeave(object sender, EventArgs e)
        {
            picfilm6.Size = new Size(picfilm6.Width - 60, picfilm6.Height - 60);
            picfilm6.Location = new Point(picfilm6.Left + 30, picfilm6.Top);
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            cbpage.Visible = true;
            progressupload.Visible = true;
            DisableButton();
            leftborderBtn.Visible = false;
            VisibleImageandLabel(false);
            VisibleCoop(false);
            VisibleUpload(false);

            cbpage.Items.Clear();

            if (String.IsNullOrEmpty(searchtb.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung tìm kiếm!");
                return;
            }
            try
            {
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

                    btncoop.Enabled = false;
                    btntopvideo.Enabled = false;
                    btnnewvideo.Enabled = false;
                    btnwatchedvideo.Enabled = false;
                    btnupload.Enabled = false;
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
                    progressupload.Visible = false;
                    btncoop.Enabled = true;
                    btnnewvideo.Enabled = true;
                    btnwatchedvideo.Enabled = true;
                    btnupload.Enabled = true;
                    btntopvideo.Enabled = true;
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

            }
        }

        private async void cbpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = cbpage.SelectedItem;
            int page = int.Parse(cbpage.Text);
            try
            {
                var findvideos = await videoService.SearchVideos(searchtb.Text.Trim(), page, accesstoken);
                if (findvideos != null)
                {
                    JArray jarray = (JArray)findvideos["videos"];
                    progressupload.Minimum = 0;
                    progressupload.Maximum = jarray.Count;

                    progressupload.Value = 0;

                    btncoop.Enabled = false;
                    btntopvideo.Enabled = false;
                    btnnewvideo.Enabled = false;
                    btnwatchedvideo.Enabled = false;
                    btnupload.Enabled = false;
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
                    progressupload.Visible = false;
                    btncoop.Enabled = true;
                    btnnewvideo.Enabled = true;
                    btnwatchedvideo.Enabled = true;
                    btnupload.Enabled = true;
                    btntopvideo.Enabled = true;
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
        }
    }

}
