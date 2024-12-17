using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Net.Http;
using Microsoft.Web.WebView2.Core;

namespace UITFLIX
{
    public partial class EmailDetails : Form
    {
        private readonly string emailBody;
        private readonly string emailDate;
        private readonly string emailFrom;
        private readonly string emailSubject;

        public EmailDetails(string body, string date, string from, string subject)
        {
            InitializeComponent();
            emailBody = body;
            emailDate = date;
            emailSubject = subject;
            emailFrom = from;
        }

        private async void EmailDetails_Load(object sender, EventArgs e)
        {
            try
            {
                labelFrom.Text = $"From: {emailFrom}";
                labelSubject.Text = $"Subject: {emailSubject}";
                labelDate.Text = $"Date: {emailDate}";

                await webView2Body.EnsureCoreWebView2Async(null);

                webView2Body.NavigateToString(emailBody);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}");
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}