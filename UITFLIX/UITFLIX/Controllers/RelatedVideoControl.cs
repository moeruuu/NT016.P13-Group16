using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UITFLIX.Controllers
{
    public partial class RelatedVideoControl : UserControl
    {
        public RelatedVideoControl()
        {
            InitializeComponent();
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set { this.title = value; lbTitle.Text = value; }
        }
        private string rate;
        public string Rate
        {
            get { return this.rate; }
            set { this.rate = value; lbRate.Text = value; }
        }

        private string uploadDate;
        public string UploadDate
        {
            get { return this.uploadDate; }
            set { this.uploadDate = value; lbUploadDate.Text = value; }
        }

        private string tag;
        public string Tag
        {
            get { return this.tag; }
            set { this.tag = value; lbTag.Text = value; }
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

        private void RelatedVideoControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.PowderBlue;
        }

        private void RelatedVideoControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
