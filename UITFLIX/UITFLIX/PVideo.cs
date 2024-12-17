using AxWMPLib;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UITFLIX.Models;
using UITFLIX.Properties;
using UITFLIX.Services;
using UITFLIX.Controllers;

namespace UITFLIX
{
    public partial class PVideo : Form
    {
        private readonly JToken jvideo;
        private readonly VideoService videoService;
        private readonly JObject Userinfo;
        private readonly string accesstoken;
        private bool rated = false;
        private static string temp;
        private ToolTip toolTip = new ToolTip();

        public PVideo(JToken videonek, string accesstoken, VideoService service, JObject user)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.FormClosing += PVideo_FormClosing;
            setStar();
            jvideo = videonek;
            this.accesstoken = accesstoken;
            videoService = service;
            Userinfo = user;
            txtnamefilm.Text = jvideo["title"].ToString();
            txtnamefilm1.Text = jvideo["title"].ToString();
            tbdes.Text += jvideo["description"].ToString();
            setlabelrateandnum(jvideo["rating"].ToString(), jvideo["numRate"].ToString());

            LoadVideo();
            LoadRalatedVideos();
        }

        public void setlabelrateandnum(string rating, string numrate)
        {
            double num = double.Parse(rating);
            double round = Math.Round(num, 1);
            averrate.Text = round.ToString("0.0");
            int check = int.Parse(numrate);
            if (check <= 1)
                total.Text = "Based on " + numrate + " rating.";
            else
                total.Text = "Based on " + numrate + " ratings.";
        }

        public async Task LoadVideo()
        {
            try
            {
                axWindowsMediaPlayer.Ctlcontrols.stop();
                axWindowsMediaPlayer.URL = null;
                var id = jvideo["id"].ToString();
                var stream = await videoService.PlayVideo(id, accesstoken);
                if (stream != null)
                {
                    temp = stream;
                    axWindowsMediaPlayer.URL = stream;
                    axWindowsMediaPlayer.Ctlcontrols.play();
                }
                await videoService.SaveWatchedVideo(jvideo["id"].ToString(), accesstoken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setStar()
        {
            star1.Image = Resources._2;
            star2.Image = Resources._2;
            star3.Image = Resources._2;
            star4.Image = Resources._2;
            star5.Image = Resources._2;

        }

        private async void star1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rated)
                {
                    MessageBox.Show("You have already submitted a rating for this view.");
                    return;
                }
                star1.Image = Resources._1;
                star2.Image = Resources._2;
                star3.Image = Resources._2;
                star4.Image = Resources._2;
                star5.Image = Resources._2;
                var afterrated = await videoService.Rating(jvideo["id"].ToString(), 1, accesstoken);

                MessageBox.Show("Thank you for your feedback!", "UITflix", MessageBoxButtons.OK);
                rated = true;
                JObject res = JObject.Parse(afterrated);
                setlabelrateandnum(res["rating"].ToString(), res["numRate"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void star2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rated)
                {
                    MessageBox.Show("You have already submitted a rating for this view.");
                    return;
                }
                star1.Image = Resources._1;
                star2.Image = Resources._1;
                star3.Image = Resources._2;
                star4.Image = Resources._2;
                star5.Image = Resources._2;
                var afterrated = await videoService.Rating(jvideo["id"].ToString(), 2, accesstoken);

                MessageBox.Show("Thank you for your feedback!", "UITflix", MessageBoxButtons.OK);
                rated = true;
                JObject res = JObject.Parse(afterrated);
                setlabelrateandnum(res["rating"].ToString(), res["numRate"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void star3_Click(object sender, EventArgs e)
        {
            try
            {
                if (rated)
                {
                    MessageBox.Show("You have already submitted a rating for this view.");
                    return;
                }
                star1.Image = Resources._1;
                star2.Image = Resources._1;
                star3.Image = Resources._1;
                star4.Image = Resources._2;
                star5.Image = Resources._2;
                var afterrated = await videoService.Rating(jvideo["id"].ToString(), 3, accesstoken);

                MessageBox.Show("Thank you for your feedback!", "UITflix", MessageBoxButtons.OK);
                rated = true;
                JObject res = JObject.Parse(afterrated);
                setlabelrateandnum(res["rating"].ToString(), res["numRate"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void star4_Click(object sender, EventArgs e)
        {
            try
            {
                if (rated)
                {
                    MessageBox.Show("You have already submitted a rating for this view.");
                    return;
                }
                star1.Image = Resources._1;
                star2.Image = Resources._1;
                star3.Image = Resources._1;
                star4.Image = Resources._1;
                star5.Image = Resources._2;
                var afterrated = await videoService.Rating(jvideo["id"].ToString(), 4, accesstoken);

                MessageBox.Show("Thank you for your feedback!", "UITflix", MessageBoxButtons.OK);
                rated = true;
                JObject res = JObject.Parse(afterrated);
                setlabelrateandnum(res["rating"].ToString(), res["numRate"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void star5_Click(object sender, EventArgs e)
        {
            try
            {
                if (rated)
                {
                    MessageBox.Show("You have already submitted a rating for this view.");
                    return;
                }
                star1.Image = Resources._1;
                star2.Image = Resources._1;
                star3.Image = Resources._1;
                star4.Image = Resources._1;
                star5.Image = Resources._1;
                var afterrated = await videoService.Rating(jvideo["id"].ToString(), 5, accesstoken);

                MessageBox.Show("Thank you for your feedback!", "UITflix", MessageBoxButtons.OK);
                rated = true;
                JObject res = JObject.Parse(afterrated);
                setlabelrateandnum(res["rating"].ToString(), res["numRate"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logo_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.stop();
            axWindowsMediaPlayer.close();
            this.Hide();
            Home home = new Home(Userinfo, videoService, accesstoken);
            home.ShowDialog();
            this.Close();
        }

        private void PVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(temp) && File.Exists(temp))
                    File.Delete(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PVideo_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try
            {
                axWindowsMediaPlayer.Ctlcontrols.stop();
                axWindowsMediaPlayer.close();
                if (!string.IsNullOrEmpty(temp) && File.Exists(temp))
                    File.Delete(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowRelatedVideos_Click(object sender, EventArgs e)
        {
            if (btnShowRelatedVideos.ForeColor == Color.MidnightBlue)
            {
                btnShowRelatedVideos.ForeColor = Color.Violet;
                btnShowRelatedVideos.IconColor = Color.Violet;
                flpRelatedVideos.Visible = true;
            }
            else
            {
                btnShowRelatedVideos.ForeColor = Color.MidnightBlue;
                btnShowRelatedVideos.IconColor = Color.MidnightBlue;
                flpRelatedVideos.Visible = false;
            }
        }

        private async void LoadRalatedVideos()
        {
            flpRelatedVideos.Controls.Clear();

            try
            {
                var jarray = await videoService.GetRelatedVideos(jvideo["tag"].ToString(), accesstoken);
                if (jarray != null && jarray.Count > 0)
                {
                    foreach (JToken video in jarray)
                    {
                        if (video["id"].ToString() == jvideo["id"].ToString()) continue;

                        RelatedVideoControl item = new RelatedVideoControl()
                        {
                            Title = SetLabelText(video["title"].ToString(), 14),
                            Rate = Math.Round(double.Parse(video["rating"].ToString()), 1).ToString() + " ★",
                            UploadDate = video["uploadedDate"].ToObject<DateTime>().ToUniversalTime().ToString("dd/MM/yyyy"),
                            Tag = $"[{video["tag"].ToString()}]",
                            ImageUrl = video["urlImage"].ToString()
                        };

                        item.Click += (sender, e) => OpenPlayVIdeoForm(video); 
                        toolTip.SetToolTip(item, video["title"].ToString());
                        flpRelatedVideos.Controls.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SetLabelText(string text, int max)
        {
            if (text.Length > max) return text.Substring(0, max) + "...";
            else return text;
        }

        private async void OpenPlayVIdeoForm(JToken video)
        {
            this.Hide();
            PVideo videos = new PVideo(video, accesstoken, videoService, Userinfo);
            videos.ShowDialog();
            this.Close();
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var videoId = jvideo["id"]?.ToString();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Video Files (*.mp4)|*.mp4";
                    saveFileDialog.FileName = "";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectedPath = saveFileDialog.FileName;

                        var tempFilePath = await videoService.DownloadVideo(videoId, accesstoken);

                        if (!string.IsNullOrEmpty(tempFilePath))
                        {
                            File.Copy(tempFilePath, selectedPath, true);

                            MessageBox.Show($"Saved Video: {selectedPath}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Can't load video!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
