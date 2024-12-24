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

        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            string accountNumber = textBoxAccountNum.Text.Trim();
            string accountName = textBoxAccountName.Text.Trim();
            string transferNote = textBoxNote.Text.Trim();
            var amount = Convert.ToInt32(textBoxAmount.Text.Trim());
            if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(accountName) || amount <= 0)
            {
                MessageBox.Show("Please enter valid account information and amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            buttonGenerate.Enabled = false;

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
            // use restsharp for request api.
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request, Method.Post);

            var content = response.Content;
            var dataResult = JsonConvert.DeserializeObject<DonateResponse>(content);
            var image = DonateService.Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));

            pictureBoxQRCode.Image = image;

            buttonGenerate.Enabled = true;

        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {

        }
    }
}

