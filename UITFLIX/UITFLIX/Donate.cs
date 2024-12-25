using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UITFLIX.Models;
using UITFLIX.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Windows.Documents;
using System.Net;

namespace UITFLIX
{
    public partial class Donate : Form
    {
        private string accessToken;

        public Donate(string accessToken)
        {
            InitializeComponent();
            this.accessToken = accessToken;
        }

        private void Donate_Load(object sender, EventArgs e)
        {
            labelQRCode.BringToFront();
            textBoxAccountName.Text = "LE NGUYEN PHUONG GIANG";
            textBoxAccountNum.Text = "36510167";
            textBoxAmount.Focus();
            textBoxAmount.SelectAll();
        }

        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            string accountNumber = textBoxAccountNum.Text.Trim();
            string accountName = textBoxAccountName.Text.Trim();
            string transferNote = richTextBoxNote.Text.Trim();
            var amountText = textBoxAmount.Text.Trim();
            if (!int.TryParse(amountText, out var amount) || amount <= 0 || amountText.Length > 13)
            {
                MessageBox.Show("The amount must be a positive integer with no more than 13 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (transferNote.Length > 25 || transferNote.Any(c => !char.IsLetterOrDigit(c) && c != ' '))
            {
                MessageBox.Show("The transfer description must not exceed 25 characters and must not contain special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            buttonGenerate.Enabled = false;
            progressBarDonate.Style = ProgressBarStyle.Marquee;
            progressBarDonate.Visible = true;

            try
            {
                var donateRequest = new DonateRequest();
                donateRequest.acqId = 970416;
                donateRequest.accountNo = accountNumber;
                donateRequest.accountName = accountName;
                donateRequest.amount = amount;
                donateRequest.addInfo = transferNote;
                donateRequest.format = "text";
                donateRequest.template = "compact";
                donateRequest.theme = "compact";

                var jsonRequest = JsonConvert.SerializeObject(donateRequest);

                var client = new RestClient("https://api.vietqr.io/v2/generate");
                var request = new RestRequest();

                request.Method = Method.Post;
                request.AddHeader("Accept", "application/json");
                request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

                var fullUrl = client.BuildUri(request).ToString();
                var webRequest = (HttpWebRequest)WebRequest.Create(fullUrl);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(await webRequest.GetRequestStreamAsync()))
                {
                    streamWriter.Write(jsonRequest);
                }

                using (var response = (HttpWebResponse)await webRequest.GetResponseAsync())
                {
                    var totalBytes = response.ContentLength;
                    var bytesRead = 0L;

                    using (var responseStream = response.GetResponseStream())

                    using (var memoryStream = new MemoryStream())
                    {
                        var buffer = new byte[8192];
                        int read;

                        while ((read = await responseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            memoryStream.Write(buffer, 0, read);
                            bytesRead += read;

                            Invoke(new Action(() =>
                            {
                                if (totalBytes > 0)
                                {
                                    progressBarDonate.Value = (int)((bytesRead * 100L) / totalBytes);
                                }
                            }));
                        }
                        var content = Encoding.UTF8.GetString(memoryStream.ToArray());
                        var dataResult = JsonConvert.DeserializeObject<DonateResponse>(content);
                        var image = DonateService.Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
                        var resizedImage = ResizeImage(image, 300, 300);
                        pictureBoxQRCode.Image = resizedImage;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonGenerate.Enabled = true;
                progressBarDonate.Style = ProgressBarStyle.Blocks;
                progressBarDonate.Value = 0;
                progressBarDonate.Visible = false;
            }

        }
        private Image ResizeImage(Image image, int width, int height)
        {
            var resized = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resized))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resized;
        }
    }
}

