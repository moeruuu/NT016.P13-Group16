using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UITFLIX.Services;
using UITFLIX.Models;

namespace UITFLIX
{
    public partial class ForgetPassword : Form
    {
        private readonly UserService userService;
        public ForgetPassword()
        {
            InitializeComponent();
            userService = new UserService();
        }

        public bool checkemail(string email)
        {
            return Regex.IsMatch(email, @"^[\w]{4,30}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
        }
        public bool checkpassword(string password)
        {
            return Regex.IsMatch(password, @"^.{6,20}$");
        }
        public bool checkconfirmpassword(string password, string secondpassword)
        {
            return password.Equals(secondpassword);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtCfPass.Text.Trim();
            bool checkflag = true;
            string ErrorMsg = "";
            if (!checkemail(email))
            {
                ErrorMsg = "Email không hợp lệ";
                lbEmail.Text = "Email(*)";
                checkflag = false;
            }
            else
            {
                lbEmail.Text = "Email";
            }
            if (!checkpassword(newPassword))
            {
                ErrorMsg += "\n\nVui lòng nhập mật khẩu mới ít nhất 6 kí tự đến 20 kí tự.";
                ErrorMsg.Trim();
                lbNewpass.Text = "New password(*)";
                checkflag = false;
            }
            else
            {
                lbNewpass.Text = "New password";
            }
            if (!checkconfirmpassword(newPassword, confirmPassword))
            {
                ErrorMsg += "\n\nMật khẩu bạn nhập lại không khớp, vui lòng nhập lại.";
                ErrorMsg.Trim();
                lbcfpass.Text = "Confirm new password(*)";
                checkflag = false;
            }
            else
            {
                lbcfpass.Text = "Confirm new password";
            }

            if (checkflag == false)
            {
                MessageBox.Show(ErrorMsg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var ForgetPwd = new
            {
                statusCode = 0,
                Email = email,
                Password = newPassword,
            };
            var response = await userService.ForgetPassword(ForgetPwd);

            if (response.Contains("Đã gửi mã OTP", StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                VerifyOTP verify = new VerifyOTP(1, email, newPassword);
                verify.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi " + response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.ShowDialog();
            this.Close();
        }
    }
}
