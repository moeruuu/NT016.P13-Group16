using FontAwesome.Sharp;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using UITFLIX.Models;
namespace UITFLIX
{
    public partial class Home : Form
    {
        private IconButton currentbtn;
        private Panel leftborderBtn;
        private bool MainVisible = true;
        private bool OtherVisible = false;
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        string content;
        //List<Video> videos = GetUploadedVideos();
        public Home()
        {
            InitializeComponent();
            leftborderBtn = new Panel();
            leftborderBtn.Size = new Size(10, 105);
            leftside.Controls.Add(leftborderBtn);
            DrawCircular(Avatar);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Test thử ava
            LoadImageFromUrl(@"https://i.pinimg.com/564x/3e/bd/e6/3ebde6b7d20947201080705e62685a71.jpg");
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

        private void btnnewvideo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            VisibleCoop(OtherVisible);
            VisibleUpload(OtherVisible);
            VisibleTopPanel(MainVisible);

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
            string selectedfile = openFileDialog.FileName;
            string getname = Path.GetFileNameWithoutExtension(selectedfile);
            string getextensions = Path.GetExtension(selectedfile);
            filevideo.Text = SetLabelText(getname) + getextensions;
        }

        private void btnchooseimage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp;*.svg";
            openFileDialog.Title = "Select an Image File";
            openFileDialog.ShowDialog();
            string selectedfile = openFileDialog.FileName;
            string getname  = Path.GetFileNameWithoutExtension(selectedfile);
            string getextensions = Path.GetExtension(selectedfile);
            fileimage.Text = SetLabelText(getname) + getextensions;
            
        }
        //Lấy url để setava
        private void LoadImageFromUrl(string imageUrl)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] imageData = client.DownloadData(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Avatar.Image = Image.FromStream(ms); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ava: " + ex.Message);
                }
            }
        }

        //Hihi lấy tên tối đa =)))
        private string SetLabelText(string text)
        {
            int maxLength = 15;
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }
            else
            {
                return text;
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
