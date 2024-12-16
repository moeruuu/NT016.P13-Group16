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
        //private readonly string _emailBody;
        //private MimeMessage emailMessage;
        //public EmailDetails(string emailContent)
        //{
        //    InitializeComponent();
        //    labelFrom.Text = $"From: {from}";
        //    labelSubject.Text = $"Subject: {subject}";
        //    MessageBox.Show(content, "Nội dung kiểm tra");
        //    webView2Body.CoreWebView2InitializationCompleted += (s, e) =>
        //    {
        //        LoadContentIntoWebView(content);
        //    };

        //    InitializeWebView2Async(content);
        //}
        public EmailDetails (string htmlContent)
        {
            InitializeComponent();
            webView2Body.NavigationCompleted += WebView2Body_NavigationCompleted;
            LoadHtmlContent(htmlContent);
        }
        private async void LoadHtmlContent(string htmlContent)
        {
            await webView2Body.EnsureCoreWebView2Async();

            webView2Body.NavigateToString(htmlContent);
        }

        private void WebView2Body_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show("Không thể tải nội dung email.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}