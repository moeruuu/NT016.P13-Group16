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
using UITFLIX.Services;

namespace UITFLIX
{
    public partial class PVideo : Form
    {
        private readonly JToken jvideo;
        private readonly string accesstoken;
        private readonly VideoService videoService;
        public PVideo(JToken videonek, string accesstoken, VideoService service)
        {
            InitializeComponent();
            //MessageBox.Show(jvideo.ToString());
            //this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            jvideo = videonek;
            this.accesstoken = accesstoken;
            videoService = service;
            txtnamefilm.Text = jvideo["title"].ToString();
            DateTime uploadedDate = jvideo["uploadedDate"].ToObject<DateTime>();
            txtdate.Text = uploadedDate.ToUniversalTime().ToString("dd/MM/yyyy");
            tbdes.Text += jvideo["description"].ToString();
            LoadVideo();
            SettingWindowsMediaPlayer();
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

        public void SettingWindowsMediaPlayer()
        {
            axWindowsMediaPlayer.uiMode = "mini";
            axWindowsMediaPlayer.Dock = DockStyle.Fill;

        }

        private void btndes_Click(object sender, EventArgs e)
        {
            if (btndes.Text.Contains("Off"))
            {
                btndes.Text = "Description: On";
                description.Visible = true;
            }
            else
            {
                btndes.Text = "Description: Off";
                description.Visible = false;
            }
        }
    }
}
