using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UITFLIX
{
    public partial class EmailDetails : Form
    {
        private readonly WebView2 webView2;
        public EmailDetails(string subject, string from, string date, string body)
        {
            InitializeComponent();
        }
    }
}
