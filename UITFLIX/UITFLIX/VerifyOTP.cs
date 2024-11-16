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
      
        public VerifyOTP()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            userService = new UserService();
        }

        private async void btnverify_Click(object sender, EventArgs e)
        {
            btnverify.Enabled = false;
            //btnverify.Text = $"Vui lòng chờ {delay}s...";

            if (string.IsNullOrEmpty(tbotp.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var OTP = new
            {
                otp = tbotp.Text.Trim(),
            };
            var response = await userService.VerifyOTP(OTP);
            if (response.Contains("thành công!"))
            {
                MessageBox.Show("Đăng ký thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
    }
}
