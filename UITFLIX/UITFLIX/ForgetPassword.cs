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
                ErrorMsg = "Invalid email.";
                lbEmail.Text = "Email(*)";
                checkflag = false;
            }
            else
                lbEmail.Text = "Email";

            if (!checkpassword(newPassword))
            {
                ErrorMsg += "\n\nPlease enter a new password that is at least 6 characters and no more than 20 characters long.";
                ErrorMsg.Trim();
                lbNewpass.Text = "New password(*)";
                checkflag = false;
            }
            else
                lbNewpass.Text = "New password";

            if (!checkconfirmpassword(newPassword, confirmPassword))
            {
                ErrorMsg += "\n\nThe passwords you entered do not match. Please try again.";
                ErrorMsg.Trim();
                lbcfpass.Text = "Confirm new password(*)";
                checkflag = false;
            }
            else
                lbcfpass.Text = "Confirm new password";

            if (checkflag == false)
            {
                MessageBox.Show(ErrorMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var ForgetPwd = new
            {
                statusCode = 0,
                Email = email,
                Password = newPassword,
            };
            var response = await userService.ForgetPassword(ForgetPwd);

            if (response.Contains("OTP sent", StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                VerifyOTP verify = new VerifyOTP(1, email, newPassword);
                verify.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
