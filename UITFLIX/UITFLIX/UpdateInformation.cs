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
using System.Text.RegularExpressions;
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
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Enter Old Password...")
            {
                txtPass.PasswordChar = '*';
                txtPass.Text = "";
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtPass.PasswordChar = '\0';
                txtPass.Text = "Enter Old Password...";
                txtPass.ForeColor = Color.SkyBlue;
            }
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "Enter New Password...")
            {
                txtNewPass.PasswordChar = '*';
                txtNewPass.Text = "";
            }
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                txtNewPass.PasswordChar = '\0';
                txtNewPass.Text = "Enter New Password...";
                txtNewPass.ForeColor = Color.SkyBlue;
            }
        }

        private void txtCfPass_Enter(object sender, EventArgs e)
        {
            if (txtCfPass.Text == "Confirm Password...")
            {
                txtCfPass.PasswordChar = '*';
                txtCfPass.Text = "";
            }
        }

        private void txtCfPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCfPass.Text))
            {
                txtCfPass.PasswordChar = '\0';
                txtCfPass.Text = "Confirm Password...";
                txtCfPass.ForeColor = Color.SkyBlue;
            }
        }
        private void SettingPassword(bool Visible)
        {
            lbcfpass.Visible = Visible;
            lbNewpass.Visible = Visible;
            lbOldpass.Visible = Visible;
            txtPass.Visible = Visible;
            txtPass.Text = "Enter Old Password...";
            txtPass.ForeColor = Color.SkyBlue;
            txtNewPass.Visible = Visible;
            txtNewPass.Text = "Enter New Password...";
            txtNewPass.ForeColor = Color.SkyBlue;
            txtCfPass.Visible = Visible;
            txtCfPass.Text = "Confirm Password...";
            txtCfPass.ForeColor = Color.SkyBlue;
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
                txtBio.ForeColor = Color.SkyBlue;
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
            new UpdateInformation(obj, AccessToken).ShowDialog();
            this.Close();
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

        public bool checkpassword(string password)
        {
            return Regex.IsMatch(password, @"^.{6,20}$");
        }
        public bool checkconfirmpassword(string password, string secondpassword)
        {
            return password.Equals(secondpassword);
        }
        private async void btnSavePwd_Click(object sender, EventArgs e)
        {
            string oldPassword = txtPass.Text.Trim();
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtCfPass.Text.Trim();
            bool checkflag = true;
            string ErrorMsg = "";
            if (!checkpassword(oldPassword))
            {
                ErrorMsg = "Mật khẩu cũ phải dài từ 6 đến 20 kí tự.";
                lbOldpass.Text = "Old password(*)";
                checkflag = false;
            }
            else
            {
                lbOldpass.Text = "Old password";
            }
            if (!checkpassword(newPassword))
            {
                ErrorMsg += "\n\nVui lòng nhập mật khẩu mới ít nhất 6 kí tự đến 20 kí tự.";
                ErrorMsg.Trim();
                lbNewpass.Text = "New password(*)";
                checkflag |= false;
            }
            else
            {
                lbNewpass.Text = "New password";
            }
            if (!checkconfirmpassword(newPassword, confirmPassword))
            {
                ErrorMsg += "\n\nMật khẩu bạn nhập lại không khớp, vui lòng nhập lại.";
                ErrorMsg.Trim();
                lbcfpass.Text = "Confirm new password(*)";
                checkflag &= false;
            }
            else
            {
                lbcfpass.Text = "Confirm new password";
            }

            if (checkflag == false)
            {
                MessageBox.Show(ErrorMsg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var response = await userService.ChangePassword(oldPassword, newPassword, AccessToken);

            if (response.Contains("Thành công!", StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                MessageBox.Show("Thay đổi mật khẩu thành công! Vui lòng đăng nhập lại.", "Thành công", MessageBoxButtons.OK);
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
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
