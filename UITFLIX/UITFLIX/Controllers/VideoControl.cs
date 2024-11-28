using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UITFLIX.Controllers
{
    public partial class VideoControl : UserControl
    {
        public VideoControl()
        {
            InitializeComponent();
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set { this.title = value; lbTitle.Text = value; lbTitle.Location = new Point((this.ClientSize.Width - lbTitle.Width) / 2, 166); }
        }
        private string sub;
        public string Sub
        {
            get { return this.sub; }
            set { this.sub = value; lbSub.Text = value; lbSub.Location = new Point((this.ClientSize.Width - lbSub.Width) / 2, 196); }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return this.imageUrl; }
            set
            {
                this.imageUrl = value;
                LoadImage(ImageUrl);
            }
        }

        private async void LoadImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                pbImage.Image = null;
                return;
            }

            if (Uri.TryCreate(imageUrl, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var bytes = await client.GetByteArrayAsync(imageUrl);
                        using (var ms = new MemoryStream(bytes))
                        {
                            if (ms.CanRead)
                            {
                                ms.Seek(0, SeekOrigin.Begin);
                                var image = Image.FromStream(ms);

                                pbImage.Invoke((Action)(() =>
                                {
                                    pbImage.Image = image;
                                }));
                                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    pbImage.Invoke((Action)(() =>
                    {
                        pbImage.Image = null;
                    }));
                }
            }
            else
            {
                pbImage.Image = null; // URL không hợp lệ
            }
        }

        private void VideoControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.PowderBlue;
        }

        private void VideoControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }
    }
}
