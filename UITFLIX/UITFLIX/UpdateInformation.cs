using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UITFLIX.Services;

namespace UITFLIX
{
    public partial class UpdateInformation : Form
    {
        private JObject userinfo;
        private readonly string AccessToken;
        private static string selectedimagefile = "Not Null";
        private readonly UserService userService;
        public UpdateInformation(JObject in4, string accessToken)
        {
            InitializeComponent();
            userinfo = in4;
            DrawCircular(Avatar);
            SettingInformation(true);
            AccessToken = accessToken;
            userService = new UserService();
            txtFullname.Text = userinfo["user"]["fullname"].ToString();
            txtBio.Text = userinfo["user"]["bio"].ToString();
            //MessageBox.Show(userinfo.ToString());
        }

        public void DrawCircular(PictureBox pictureBox)
        {
            int width = pictureBox.Width;
            int height = pictureBox.Height;

            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(0, 0, width, height);
            pictureBox.Region = new Region(circlePath);
        }

        private async void LoadImageFromUrl(string imageUrl)
        {

            using (var client = new HttpClient())
            {
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

        private void SettingInformation(bool Visible)
        {
            try
            {
                LoadImageFromUrl(userinfo["user"]["profilepicture"].ToString());

                Avatar.Visible = Visible;
                underlineinf.Visible = Visible;
                txtBio.Visible = Visible;
                txtFullname.Visible = Visible;
                lbBio.Visible = Visible;
                lbFullname.Visible = Visible;
                btnChangeAva.Visible = Visible;
                btnUpdateInfo.Visible = Visible;
                btninformation.TextImageRelation = TextImageRelation.TextBeforeImage;
                btnpass.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + ex.StackTrace);
            }
        }

        private void SettingPassword(bool Visible)
        {
            lbcfpass.Visible = Visible;
            lbNewpass.Visible = Visible;
            lbOldpass.Visible = Visible;
            txtCfPass.Visible = Visible;
            txtNewPass.Visible = Visible;
            txtPass.Visible = Visible;
            btnSavePwd.Visible = Visible;
            underlinepass.Visible = Visible;
            btnpass.TextImageRelation = TextImageRelation.TextBeforeImage;
            btninformation.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private void btninformation_Click(object sender, EventArgs e)
        {
            SettingInformation(true);
            SettingPassword(false);
        }

        private void btnpass_Click(object sender, EventArgs e)
        {
            SettingPassword(true);
            SettingInformation(false);
        }

        private void btnChangeAva_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.webp;*.svg";
            openFileDialog.ShowDialog();
            selectedimagefile = openFileDialog.FileName;
            if (selectedimagefile != null)
                Avatar.Image = System.Drawing.Image.FromFile(selectedimagefile);
        }
        private void txtBio_Enter(object sender, EventArgs e)
        {
            if (txtBio.Text == "< Người dùng này cạn lời rồi ... >")
            {
                txtBio.Text = "";
            }
        }

        private async void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text.Trim();
            string bio = txtBio.Text.Trim();

            if (fullname == string.Empty)
            {
                MessageBox.Show("Fullname không thể để trống. Vui lòng nhập tên đầy đủ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (bio == string.Empty)
            {
                bio = "< Người dùng này cạn lời rồi ... >";
            }
            try
            {
                var response = await userService.UpdateInformation(fullname, bio, selectedimagefile, AccessToken);

                var res = MessageBox.Show("Update thông tin thành công. Bạn có muốn quay lại trang home?", "Thành công", MessageBoxButtons.YesNo);
                JObject obj = JObject.Parse(response.ToString());
                txtFullname.Text = null;
                txtBio.Text = null;
                LoadImageFromUrl(userinfo["user"]["profilepicture"].ToString());
                userinfo["user"]["profilepicture"] = obj["user"]["profilepicture"];
                userinfo["user"]["fullname"] = obj["user"]["fullname"];
                userinfo["user"]["bio"] = obj["user"]["bio"];
                //MessageBox.Show(obj.ToString());
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    VideoService videoService = new VideoService();
                    new Home(userinfo, videoService, AccessToken).ShowDialog();
                    this.Close();
                }
                else
                {
                    //load lại form, thay bằng dữ liệu mới 
                    ReloadForm(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Hệ thống không thể update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void ReloadForm(JObject obj)
        {
            this.Hide();
            var location = this.Location;
            this.Close();

            var newUIForm = new UpdateInformation(obj, AccessToken);
            newUIForm.Location = location;
            newUIForm.TopMost = true;
            newUIForm.TopMost = false;
            newUIForm.ShowDialog();
        }

        private void logo_Click(object sender, EventArgs e)
        {
            if (txtBio.ToString().Trim() != userinfo["user"]["bio"].ToString() || txtFullname.ToString().Trim() != userinfo["user"]["fullname"].ToString() || selectedimagefile != null)
            {
                var res = MessageBox.Show("Bạn chưa lưu thay đổi. Bạn vẫn muốn thoát chứ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.Hide();
                    VideoService videos = new VideoService();
                    new Home(userinfo, videos, AccessToken).ShowDialog();
                    this.Close();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
