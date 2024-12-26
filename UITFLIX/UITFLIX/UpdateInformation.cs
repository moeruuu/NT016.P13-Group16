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
            if (userinfo["user"]["bio"].ToString() == "< This user is speechless ... >" || userinfo["user"]["bio"] == null)
                txtBio.Text = string.Empty;
            else
                txtBio.Text = userinfo["user"]["bio"].ToString();
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
                    Avatar.Image = LoadDefaultImage();
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
            if (txtPass.Text == "Enter your old password...")
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
                txtPass.Text = "Enter your old password...";
                txtPass.ForeColor = Color.SkyBlue;
            }
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "Enter your new password...")
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
                txtNewPass.Text = "Enter your new password...";
                txtNewPass.ForeColor = Color.SkyBlue;
            }
        }

        private void txtCfPass_Enter(object sender, EventArgs e)
        {
            if (txtCfPass.Text == "Confirm your password...")
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
                txtCfPass.Text = "Confirm your password...";
                txtCfPass.ForeColor = Color.SkyBlue;
            }
        }
        private void SettingPassword(bool Visible)
        {
            lbcfpass.Visible = Visible;
            lbNewpass.Visible = Visible;
            lbOldpass.Visible = Visible;
            txtPass.Visible = Visible;
            txtPass.Text = "Enter your old password...";
            txtPass.ForeColor = Color.SkyBlue;
            txtNewPass.Visible = Visible;
            txtNewPass.Text = "Enter your new password...";
            txtNewPass.ForeColor = Color.SkyBlue;
            txtCfPass.Visible = Visible;
            txtCfPass.Text = "Confirm your password...";
            txtCfPass.ForeColor = Color.SkyBlue;
            btnSavePwd.Visible = Visible;
            underlinepass.Visible = Visible;
            btnpass.TextImageRelation = TextImageRelation.TextBeforeImage;
            btninformation.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private void btninformation_Click(object sender, EventArgs e)
        {
            SettingPassword(false);
            SettingInformation(true);
        }

        private void btnpass_Click(object sender, EventArgs e)
        {
            SettingInformation(false);
            SettingPassword(true);
        }

        private void btnChangeAva_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.webp;*.svg";
            openFileDialog.ShowDialog();
            selectedimagefile = openFileDialog.FileName;
            try
            {
                if (selectedimagefile != null)
                    Avatar.Image = System.Drawing.Image.FromFile(selectedimagefile);
            }
            catch
            {
                MessageBox.Show("No valid image found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text.Trim();
            string bio = txtBio.Text.Trim();

            if (fullname == string.Empty)
            {
                MessageBox.Show("Full name cannot be empty. Please enter your full name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (bio == string.Empty)
                bio = "< This user is speechless ... >";

            try
            {
                var response = await userService.UpdateInformation(fullname, bio, selectedimagefile, AccessToken);
                var res = MessageBox.Show("Information updated successfully. Would you like to return to the home page?", "Success", MessageBoxButtons.YesNo);
                JObject obj = JObject.Parse(response.ToString());

                txtFullname.Text = null;
                txtBio.Text = null;
                LoadImageFromUrl(userinfo["user"]["profilepicture"].ToString());
                userinfo["user"]["profilepicture"] = obj["user"]["profilepicture"];
                userinfo["user"]["fullname"] = obj["user"]["fullname"];
                userinfo["user"]["bio"] = obj["user"]["bio"];

                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    if (userinfo["user"]["role"].ToString() == "1")
                    {
                        VideoService videos = new VideoService();
                        new Home(userinfo, videos, AccessToken).ShowDialog();
                    }
                    else
                    {
                        Admin admin = new Admin(userinfo, AccessToken);
                        admin.ShowDialog();
                    }
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
            string bio = txtBio.Text.Trim();
            if (txtBio.Text.Trim() == string.Empty)
                bio = "< This user is speechless ... >";
            if (bio == "" && userinfo["user"]["bio"] == null)
                return;
            if (bio != userinfo["user"]["bio"].ToString() || txtFullname.Text.Trim() != userinfo["user"]["fullname"].ToString() || selectedimagefile != "Not Null")
            {
                var res = MessageBox.Show("You have unsaved changes. Do you still want to exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.Hide();
                    if (userinfo["user"]["role"].ToString() == "1")
                    {
                        VideoService videos = new VideoService();
                        new Home(userinfo, videos, AccessToken).ShowDialog();
                    }
                    else
                    {
                        Admin admin = new Admin(userinfo, AccessToken);
                        admin.ShowDialog();
                    }    
                    this.Close();
                }
                else
                    return;
            }
            else
            {
                this.Hide();
                if (userinfo["user"]["role"].ToString() == "1")
                {
                    VideoService videos = new VideoService();
                    new Home(userinfo, videos, AccessToken).ShowDialog();
                }
                else
                {
                    Admin admin = new Admin(userinfo, AccessToken);
                    admin.ShowDialog();
                }
                this.Close();
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
                ErrorMsg = "The old password must be between 6 and 20 characters long.";
                lbOldpass.Text = "Old password(*)";
                checkflag = false;
            }
            else
            {
                lbOldpass.Text = "Old password";
            }
            if (!checkpassword(newPassword))
            {
                ErrorMsg += "\n\nPlease enter a new password that is at least 6 characters and no more than 20 characters long.";
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
                ErrorMsg += "\n\nThe password you entered does not match. Please enter it again.";
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
                MessageBox.Show(ErrorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var Pass = new
            {
                oldPassword = oldPassword,
                newPassword = newPassword,
            };
            var response = await userService.ChangePassword(Pass, AccessToken);

            if (response.Contains("Success", StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                MessageBox.Show("Password changed successfully! Please log in again.", "Success", MessageBoxButtons.OK);
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
