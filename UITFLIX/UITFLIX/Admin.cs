using FontAwesome.Sharp;
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
using Microsoft.VisualBasic.ApplicationServices;
using MimeKit;
using System.Net.Mail;
using MailKit.Net.Imap;

namespace UITFLIX
{
    public partial class Admin : Form
    {
        private readonly JObject userinfo;
        private readonly string accesstoken;

        private readonly UserService userService;
        private readonly VideoService videoService;
        private readonly MailService mailService;
        private readonly CoopService coopService;

        public static Point? adminLocation;

        private int selectedIndexUser = -1;
        private int selectedIndexVideo = -1;

        public Admin(JObject user, string token)
        {
            if (adminLocation.HasValue)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = adminLocation.Value;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            InitializeComponent();
            userinfo = user;
            accesstoken = token;
            userService = new UserService();
            videoService = new VideoService();
            mailService = new MailService(accesstoken);
            coopService = new CoopService();

            tbSearch.Text = " Search";
            tbSearch.ForeColor = Color.CadetBlue;
            tbSearch.Font = new Font(tbSearch.Font, FontStyle.Italic);
            tbSearch.Font = new Font(tbSearch.Font.FontFamily, 14);
            tbSearch.ScrollBars = RichTextBoxScrollBars.None;

            dgvEmails.AutoGenerateColumns = false;

            SetInfo();
        }

        //Set info
        public void SetInfo()
        {
            lbName.Text = userinfo["user"]["fullname"].ToString();
            lbName.Location = new Point(pbAvatar.Location.X - lbName.Width - 4, lbName.Location.Y);
            DrawCircular(pbAvatar);
            LoadImageFromUrl(userinfo["user"]["profilepicture"].ToString());
        }

        //Set avatar
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
                            pbAvatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    pbAvatar.Image = LoadDefaultImage();
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

        //Mở form update info
        private void lbName_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminLocation = this.Location;
            new UpdateInformation(userinfo, accesstoken).ShowDialog();
            this.Close();
        }

        //Nút logout
        private async void logout_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                var LogOutModel = new
                {
                    Id = userinfo["user"]["id"].ToString()
                };
                var response = await userService.LogOut(LogOutModel, accesstoken);
                if (response.Contains("thành công!"))
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

        //Chọn tab
        private void tcData_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = tcData.SelectedIndex;
            if (selectedIndex == 0 || selectedIndex == -1)
            {
                EmailsLoading();
                iconRemove.Enabled = false;
                iconRemove.IconColor = Color.Gray;
            }
            else if (selectedIndex == 1)
            {
                UsersLoading();
                iconRemove.Enabled = true;
                iconRemove.IconColor = Color.DarkRed;
            }
            else if (selectedIndex == 2)
            {
                VideosLoading();
                iconRemove.Enabled = true;
                iconRemove.IconColor = Color.DarkRed;
            }
            else if (selectedIndex == 3)
            {
                RoomsLoading();
                iconRemove.Enabled = false;
                iconRemove.IconColor = Color.Gray;
            }
        }

        //Load tab Emails
        private async void EmailsLoading()
        {
            dgvEmails.Rows.Clear();
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            var jArray = await mailService.GetEmails();

            if (jArray == null)
            {
                lbNoEmail.Visible = true;
                progressBar.Visible = false;
                return;
            }

            try
            {
                foreach (var email in jArray)
                {
                    dgvEmails.Rows.Add(email["date"], email["from"], email["subject"], email["body"]);
                }
                dgvEmails.Sort(dgvEmails.Columns["Date"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }

            progressBar.Visible = false;
        }
        private void dgvEmails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            var selectedRow = dgvEmails.Rows[e.RowIndex];

            string emailFrom = selectedRow.Cells["From"].Value?.ToString() ?? "Unknown sender";
            string emailSubject = selectedRow.Cells["Subject"].Value?.ToString() ?? "No subject";
            string emailContent = selectedRow.Cells["Content"].Value?.ToString() ?? "No content";
            string emailDate = selectedRow.Cells["Date"].Value?.ToString() ?? "No date";
            string htmlContent = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>{emailSubject}</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            padding: 10px;
        }}
        img {{
            max-width: 100%;
            height: auto;
            margin: 10px 0;
        }}
        h1 {{
            color: #333;
        }}
        hr {{
            margin: 20px 0;
        }}
    </style>
</head>
<body>
    <h1>{emailSubject}</h1>
    <p><strong>From:</strong> {emailFrom}</p>
    <p><strong>Date:</strong> {emailDate}</p>
    <hr />
    {ReplaceImagesInBody(emailContent)}
</body>
</html>";

            var emailDetailsForm = new EmailDetails(htmlContent);
            emailDetailsForm.ShowDialog();
        }
        private string ReplaceImagesInBody(string bodyContent)
        {
            string pattern = @"\[image:\s*(.*?)\]";
            string replacement = @"<img src='$1' alt='Image' onerror=""this.onerror=null;this.src='https://example.com/default.jpg';"" />";
            return System.Text.RegularExpressions.Regex.Replace(bodyContent, pattern, replacement);
        }

        //Load tab Users
        private async void UsersLoading()
        {
            dgvUsers.Rows.Clear();
            selectedIndexUser = -1;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            var jArray = await userService.GetUsers(accesstoken);
            int num = 1;

            if (jArray == null)
            {
                lbNoUser.Visible = true;
                progressBar.Visible = false;
                return;
            }

            try
            {
                foreach (var user in jArray)
                {
                    string id = user["id"].ToString();
                    string displayedId = "******" + id.Substring(id.Length - 6);

                    string online;
                    if (user["user"]["isOnline"].ToString() == "False")
                        online = "OFF";
                    else
                        online = "ON";


                    int rowIndex = dgvUsers.Rows.Add(num, displayedId, user["user"]["email"], user["user"]["username"], user["user"]["fullname"], online, user["videosCount"] + " videos");

                    dgvUsers.Rows[rowIndex].Cells["UserID"].Tag = id;
                    num++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }

            progressBar.Visible = false;
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Online")
            {
                var cellValue = e.Value?.ToString();
                if (cellValue == "ON")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (cellValue == "OFF")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        //Load tab Videos
        private async void VideosLoading()
        {
            dgvVideos.Rows.Clear();
            selectedIndexVideo = -1;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            var jArray = await videoService.GetVideos(accesstoken);
            int num = 1;

            if (jArray == null)
            {
                lbNoVideo.Visible = true;
                progressBar.Visible = false;
                return;
            }

            try
            {
                foreach (var video in jArray)
                {
                    string id = video["video"]["id"].ToString();
                    string displayedId = "******" + id.Substring(id.Length - 6);
                    int rowIndex = dgvVideos.Rows.Add(num, displayedId, video["uploader"], video["video"]["uploadedDate"], video["video"]["title"], video["video"]["rating"]);
                    dgvVideos.Rows[rowIndex].Cells["VideoID"].Tag = id;
                    num++;
                }
                dgvVideos.Sort(dgvVideos.Columns["UploadedDate"], ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }

            progressBar.Visible = false;
            dgvVideos.CellFormatting += dgvVideos_CellFormatting;
        }

        private void dgvVideos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVideos.Columns[e.ColumnIndex].Name == "Rating")
            {
                var cellValue = double.Parse(e.Value?.ToString());
                if (cellValue >= 4.0)
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (cellValue >= 2.5)
                {
                    e.CellStyle.ForeColor = Color.Goldenrod;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        //Load tab Rooms
        private async void RoomsLoading()
        {
            dgvRooms.Rows.Clear();
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            var jArray = await coopService.GetRooms(accesstoken);
            int num = 1;

            if (jArray == null)
            {
                lbNoRoom.Visible = true;
                progressBar.Visible = false;
                return;
            }

            try
            {
                foreach (var room in jArray)
                {
                    dgvRooms.Rows.Add(num, room["room"]["roomId"], room["host"], room["room"]["startTime"], room["participants"]);
                    num++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }

            progressBar.Visible = false;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                selectedIndexUser = e.RowIndex;
        }

        private void dgvVideos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                selectedIndexVideo = e.RowIndex;
        }

        //Button Remove
        private async void iconRemove_Click(object sender, EventArgs e)
        {
            int selectedTab = tcData.SelectedIndex;
            if (selectedTab == 0 || selectedTab == 3)
                return;
            if (selectedTab == 1)
            {
                if (selectedIndexUser == -1)
                {
                    MessageBox.Show("Please choose a user to remove", "Notice", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    if (dgvUsers.Rows[selectedIndexUser].Cells[5].Value.ToString() == "ON")
                    {
                        MessageBox.Show("This user is online. You are not able to delete this user now!", "Notice", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        var res = MessageBox.Show("\"Are you sure you want to permanently delete this user?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            var response = await userService.DeleteUser(dgvUsers.Rows[selectedIndexUser].Cells["UserID"].Tag.ToString(), accesstoken);
                            if (response == "Thành công")
                            {
                                MessageBox.Show("Deleted user successfully", "Success", MessageBoxButtons.OK);
                                dgvUsers.Rows.RemoveAt(selectedIndexUser);
                                selectedIndexUser = -1;
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete this user", "Error", MessageBoxButtons.OKCancel);
                                return;
                            }
                        }
                    }
                }
            }
            else if (selectedTab == 2)
            {
                if (selectedIndexVideo == -1)
                {
                    MessageBox.Show("Please choose a video to remove", "Notice", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    var res = MessageBox.Show("Are you sure you want to permanently delete this video?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        var response = await videoService.DeleteVideo(dgvVideos.Rows[selectedIndexVideo].Cells["VideoID"].Tag.ToString(), accesstoken);
                        MessageBox.Show(dgvVideos.Rows[selectedIndexVideo].Cells["VideoID"].Tag.ToString());
                        if (response == "Thành công")
                        {
                            MessageBox.Show("Deleted video successfully", "Success", MessageBoxButtons.OK);
                            dgvVideos.Rows.RemoveAt(selectedIndexVideo);
                            selectedIndexVideo = -1;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete this video", "Error", MessageBoxButtons.OKCancel);
                            return;
                        }
                    }
                }
            }
        }

    }

}
