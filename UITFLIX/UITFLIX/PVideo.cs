using AxWMPLib;
using Newtonsoft.Json.Linq;
using System;
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

namespace UITFLIX
{
    public partial class PVideo : Form
    {
        private readonly JToken jvideo;
        private readonly string accesstoken;
        private readonly VideoService videoService;
        private readonly JObject Userinfo;
        private bool rated = false;
        public PVideo(JToken videonek, string accesstoken, VideoService service, JObject user)
        {
            InitializeComponent();
            //MessageBox.Show(jvideo.ToString());
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            setStar();
            jvideo = videonek;
            this.accesstoken = accesstoken;
            videoService = service;
            Userinfo = user;
            txtnamefilm.Text = jvideo["title"].ToString();
            txtnamefilm1.Text = jvideo["title"].ToString();
            tbdes.Text = "DESCRIPTION: \n";
            tbdes.Text += jvideo["description"].ToString();
            double num = double.Parse(jvideo["rating"].ToString());
            double round = Math.Round(num, 1);
            averrate.Text = round.ToString("0.0");
            total.Text += jvideo["numRate"].ToString() + " ratings.";
            LoadVideo();
        }

        public async Task LoadVideo()
        {
            try
            {
                var id = jvideo["id"].ToString();
                var stream = await videoService.PlayVideo(accesstoken, id);
                if (stream != null)
                {
                    axWindowsMediaPlayer.URL = stream;
                    axWindowsMediaPlayer.Ctlcontrols.play();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logo_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(Userinfo, videoService, accesstoken);
            home.ShowDialog();
            this.Close();
        }


        private void setStar()
        {

            star1.Image = Resources._1;
            star2.Image = Resources._1;
            star3.Image = Resources._1;
            star4.Image = Resources._1;
            star5.Image = Resources._1;

        }

        private async void star1_Click(object sender, EventArgs e)
        {
            if (rated)
            {
                MessageBox.Show("Bạn đã đánh giá rồi");
                return;
            }
            star1.Image = Resources._1;
            star2.Image = Resources._2;
            star3.Image = Resources._2;
            star4.Image = Resources._2;
            star5.Image = Resources._2;
            await videoService.Rating(jvideo["id"].ToString(), 1, accesstoken);
            MessageBox.Show("Cảm ơn bạn đã đánh giá!");
            rated = true;
        }

        private async void star2_Click(object sender, EventArgs e)
        {
            if (rated)
            {
                MessageBox.Show("Bạn đã đánh giá rồi");
                return;
            }
            star1.Image = Resources._1;
            star2.Image = Resources._1;
            star3.Image = Resources._2;
            star4.Image = Resources._2;
            star5.Image = Resources._2;
            await videoService.Rating(jvideo["id"].ToString(), 2, accesstoken);
            MessageBox.Show("Cảm ơn bạn đã đánh giá!");
            rated = true;
        }

        private async void star3_Click(object sender, EventArgs e)
        {
            if (rated)
            {
                MessageBox.Show("Bạn đã đánh giá rồi");
                return;
            }
            star1.Image = Resources._1;
            star2.Image = Resources._1;
            star3.Image = Resources._1;
            star4.Image = Resources._2;
            star5.Image = Resources._2;
            await videoService.Rating(jvideo["id"].ToString(), 3, accesstoken);
            MessageBox.Show("Cảm ơn bạn đã đánh giá!");
            rated = true;
        }

        private async void star4_Click(object sender, EventArgs e)
        {
            if (rated)
            {
                MessageBox.Show("Bạn đã đánh giá rồi");
                return;
            }
            star1.Image = Resources._1;
            star2.Image = Resources._1;
            star3.Image = Resources._1;
            star4.Image = Resources._1;
            star5.Image = Resources._2;
            await videoService.Rating(jvideo["id"].ToString(), 3, accesstoken);
            MessageBox.Show("Cảm ơn bạn đã đánh giá!");
            rated = true;
        }

        private async void star5_Click(object sender, EventArgs e)
        {
            if (rated)
            {
                MessageBox.Show("Bạn đã đánh giá rồi");
                return;
            }
            star1.Image = Resources._1;
            star2.Image = Resources._1;
            star3.Image = Resources._1;
            star3.Image = Resources._1;
            star4.Image = Resources._1;
            star5.Image = Resources._1;
            await videoService.Rating(jvideo["id"].ToString(), 3, accesstoken);
            MessageBox.Show("Cảm ơn bạn đã đánh giá!");
            rated = true;
        }
    }
}
