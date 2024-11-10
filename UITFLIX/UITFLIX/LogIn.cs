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
    public partial class LogIn : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }
            var loginResult = await Login(username, password);
            if (loginResult)
            {
                MessageBox.Show("Đăng nhập thành công!");
                
                this.Hide();
                Home home = new Home();
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        // Phương thức thực hiện đăng nhập qua API
        private async Task<bool> Login(string username, string password)
        {
            try
            {
                // Dữ liệu đăng nhập (DTO)
                var loginDTO = new
                {
                    Username = username,
                    Password = password
                };

                // Chuyển đối tượng loginDTO thành JSON
                var json = JsonConvert.SerializeObject(loginDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST tới API 
                HttpResponseMessage response = await client.PostAsync("http://localhost:5019/api/user/login", content);

                // Kiểm tra kết quả trả về từ API
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối API: " + ex.Message);
                return false;
            }
        }
    }
}
