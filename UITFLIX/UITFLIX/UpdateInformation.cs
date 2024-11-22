﻿using Newtonsoft.Json.Linq;
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

namespace UITFLIX
{
    public partial class UpdateInformation : Form
    {
        private readonly JObject userinfo;
        private readonly string AccessToken;
        private static string selectedimagefile;
        public UpdateInformation(JObject in4, string accessToken)
        {
            InitializeComponent();
            userinfo = in4;
            DrawCircular(Avatar);
            SettingInformation(true);
            AccessToken = accessToken;
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
            lbPass.Visible = Visible;
            txtCfPass.Visible = Visible;
            txtNewPass.Visible = Visible;
            txtPass.Visible = Visible;
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
            Avatar.Image = System.Drawing.Image.FromFile(selectedimagefile);
        }
    }
}
