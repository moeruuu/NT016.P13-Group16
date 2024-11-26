using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UITFLIX.Services;

namespace UITFLIX
{
    public partial class SignUp : Form
    {
        private readonly UserService userService;
        public SignUp()
        {
            InitializeComponent();
            this.txtFullname.Enter += new System.EventHandler(this.txtFullname_Enter);
            this.txtFullname.Leave += new System.EventHandler(this.txtFullname_Leave);
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtCFPassword.Enter += new System.EventHandler(this.txtCFPassword_Enter);
            this.txtCFPassword.Leave += new System.EventHandler(this.txtCFPassword_Leave);

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            userService = new UserService();
            btnsignup.Enabled = true;
        }
        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if (txtFullname.Text == "Fullname...")
            {
                txtFullname.Text = "";
                txtFullname.ForeColor = Color.White;
            }
        }

        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                txtFullname.Text = "Fullname...";
                txtFullname.ForeColor = Color.SkyBlue;
            }
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
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email...")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email...";
                txtEmail.ForeColor = Color.SkyBlue;
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

        private void txtCFPassword_Enter(object sender, EventArgs e)
        {
            if (txtCFPassword.Text == "Confirm Password...")
            {
                txtCFPassword.PasswordChar = '*';
                txtCFPassword.Text = "";
                txtCFPassword.ForeColor = Color.White;
            }
        }

        private void txtCFPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCFPassword.Text))
            {
                txtCFPassword.PasswordChar = '\0';
                txtCFPassword.Text = "Confirm Password...";
                txtCFPassword.ForeColor = Color.SkyBlue;
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            txtFullname.Text = "Fullname...";
            txtFullname.ForeColor = Color.SkyBlue;
            txtUsername.Text = "Username...";
            txtUsername.ForeColor = Color.SkyBlue;
            txtEmail.Text = "Email...";
            txtEmail.ForeColor = Color.SkyBlue;
            txtPassword.Text = "Password...";
            txtPassword.ForeColor = Color.SkyBlue;
            txtCFPassword.Text = "Confirm Password...";
            txtCFPassword.ForeColor = Color.SkyBlue;
        }

        public bool checkusername(string username)
        {
            return Regex.IsMatch(username, "^[a-zA-Z0-9]{4,25}$");
        }
        public bool checkemail(string email)
        {
            return Regex.IsMatch(email, @"^[\w]{4,30}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
        }
        public bool checkpassword(string password)
        {
            return Regex.IsMatch(password, @"^.{6,20}$");
        }

        private async void btnsignup_Click(object sender, EventArgs e)
        {

            lbwait.Text = "Waiting for sign up...";
            btnsignup.Enabled = false;
            string fullname = txtFullname.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtCFPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            if (!checkusername(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập không chứa kí tự đặc biệt và dài từ 5 đến 15 chữ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!checkemail(email))
            {
                MessageBox.Show("Vui lòng nhập email đúng định dạng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!checkpassword(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu ít nhất 6 kí tự đến 20 kí tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var SignUp = new
            {
                fullname = fullname,
                username = username,
                email = email,
                password = password,
            };
            var response = await userService.Register(SignUp);
            //JObject status = JObject.Parse(response);
            if (response.Contains("thành công!", StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                VerifyOTP otp = new VerifyOTP(0, null, null);
                otp.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void linklogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.ShowDialog();
            this.Close();
        }
    }
}

