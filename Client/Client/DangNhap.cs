using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.VisualBasic.ApplicationServices;



namespace Client
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HashAlgorithm al = SHA256.Create();
            byte[] inputbyte = Encoding.UTF8.GetBytes(password);
            byte[] hashbyte = al.ComputeHash(inputbyte);
            string hashedPassword = BitConverter.ToString(hashbyte).Replace("-", "");

            try
            {
                var client = new MongoClient("mongodb+srv://nt106-p13:hocltmkhongvui@clusteruyenthy.wttnb.mongodb.net/");
                var database = client.GetDatabase("DOAN");
                var collection = database.GetCollection<BsonDocument>("Users");

                //tìm kiếm người dùng 
                var filter = Builders<BsonDocument>.Filter.Eq("username", username) &
                             Builders<BsonDocument>.Filter.Eq("password", hashedPassword);
                var userDocument = await collection.Find(filter).FirstOrDefaultAsync();
                if (userDocument != null)
                {
                    // Chuyển đổi BsonDocument thành JSON và phân tích cú pháp thành đối tượng C#
                    string jsonString = userDocument.ToJson();
                    var user = JsonConvert.DeserializeObject<User>(jsonString);

                    MessageBox.Show($"Đăng nhập thành công!\n !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // mở form chính
                    //
                    //



                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kết nối đến MongoDB: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        { 
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
        }
            
    }


}


