using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UITFLIX.Services;


namespace UITFLIX
{
    public partial class LogIn : Form
    {
        public static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://localhost:7292/"),
            Timeout = TimeSpan.FromSeconds(60)
        };

        public LogIn()
        {
            InitializeComponent();
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            btnlogin.Enabled = true;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username...")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.White;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username...";
                txtUsername.ForeColor = Color.SkyBlue;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password...")
            {
                txtPassword.PasswordChar = '*';
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "Password...";
                txtPassword.ForeColor = Color.SkyBlue;
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Username...";
            txtUsername.ForeColor = Color.SkyBlue;
            txtPassword.Text = "Password...";
            txtPassword.ForeColor = Color.SkyBlue;
        }

        private async void linksignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
            this.Hide();
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            lbwait.Enabled = false;
            lbwait.Text = "Waiting for login...";
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                var User = new
                {
                    username = username,
                    password = password
                };
                var json = JsonConvert.SerializeObject(User);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/User/LogIn", content);
                var info = await response.Content.ReadAsStringAsync();
                JObject res = JObject.Parse(info);
                //MessageBox.Show(Userinfo.ToString());
                //MessageBox.Show(response.ToString());
                if (response.IsSuccessStatusCode)
                {
                    
                    Home home = new Home(res);
                    home.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(info);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +'\n'+ ex.StackTrace);
            }

        }
    }
}
