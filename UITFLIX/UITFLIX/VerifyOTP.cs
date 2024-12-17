using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UITFLIX.Services;

namespace UITFLIX
{
    public partial class VerifyOTP : Form
    {
        private readonly UserService userService;
        private readonly int code;
        private readonly string email;
        private readonly string password;

        public VerifyOTP(int requestCode, string Email, string Password)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            userService = new UserService();

            this.code = requestCode;
            this.email = Email;
            this.password = Password;
        }

        private async void btnverify_Click(object sender, EventArgs e)
        {
            btnverify.Enabled = false;
            if (string.IsNullOrEmpty(tbotp.Text.Trim()))
            {
                MessageBox.Show("Please enter the OTP!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var OTP = new
            {
                requestCode = code,
                otp = tbotp.Text.Trim(),
            };
            var response = await userService.VerifyOTP(OTP);
            if (response.Contains("registration successfully!"))
            {
                MessageBox.Show("Registration successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
                this.Close();
            }
            else if(response.Contains("successfully create a new password!"))
            {
                MessageBox.Show("Password changed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var ForgetPwd = new
                {
                    statusCode = 1,
                    Email = email,
                    Password = password,
                };
                await userService.ForgetPassword(ForgetPwd);

                this.Hide();
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
                this.Close();
            }    
            else
            {
                MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
    }
}
