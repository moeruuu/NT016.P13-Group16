﻿using System;
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
            iconEye.Enabled = false;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username or Email...")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.White;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username or Email...";
                txtUsername.ForeColor = Color.SkyBlue;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            iconEye.Enabled = true;
            if (txtPassword.Text == "Password...")
            {
                txtPassword.PasswordChar = '*';
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            iconEye.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "Password...";
                txtPassword.ForeColor = Color.SkyBlue;
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Username or Email...";
            txtUsername.ForeColor = Color.SkyBlue;
            txtPassword.Text = "Password...";
            txtPassword.ForeColor = Color.SkyBlue;
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Fill your name or your password, please!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                if (response.IsSuccessStatusCode)
                {
                    this.Hide();
                    var accesstoken = res["access_token"].ToString();
                    var videoService = new VideoService();
                    if (res["user"]["role"].ToString() == "1")
                    {
                        Home home = new Home(res, videoService, accesstoken);
                        home.ShowDialog();
                    }
                    else
                        new Admin(res, accesstoken).ShowDialog();
                    this.Close();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                {
                    MessageBox.Show(res["message"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void linksignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
            this.Close();
        }

        private void linkforgetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.ShowDialog();
            this.Close();
        }

        private void iconEye_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                iconEye.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                iconEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
