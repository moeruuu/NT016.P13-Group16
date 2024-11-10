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

namespace UITFLIX
{
    public partial class SignUp : Form
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5019/"), 
            Timeout = TimeSpan.FromSeconds(30) 
        };
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.ShowDialog();
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            string fullname = txtFullname.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtCFPassword.Text;
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và mật khẩu xác nhận không đúng!");
                return;
            }
            var registerResult = await Register(username, password, confirmPassword, fullname, email);
            if (registerResult)
            {
                MessageBox.Show("Đăng ký thành công!");
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Tên tài khoản đã tồn tại hoặc có lỗi xảy ra!");
            }
        }

        private async Task<bool> Register(string username, string password, string confirmPassword, string fullname, string email)
        {
            try
            {
                var registerDTO = new
                {
                    Username = username,
                    Password = password,
                    ConfirmPassword = confirmPassword,
                    Fullname = fullname,
                    Email = email
                };

                var json = JsonConvert.SerializeObject(registerDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:5019/api/user/register", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(errorMessage); // Hiển thị thông báo lỗi từ API
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message);
                return false;
            }
        }
    }
}
