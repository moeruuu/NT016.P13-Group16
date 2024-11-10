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
using System.Text.RegularExpressions;
using System.Web;

namespace Client
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }
        public bool checkfullname(string fullname)
        {
            return Regex.IsMatch(fullname, "^[a-zA-Z]{6,25}$");
        }
        public bool checkusername(string username)
        {
            return Regex.IsMatch(username, "^[a-zA-Z0-9]{4,15}$");
        }
        private bool checkpass(string password)
        {
            return Regex.IsMatch(password, @"^[\w]{6,20}$");
        }
        private bool checkemail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{4,20}@gmail.com(.vn|)$");
        }
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            string fullname = txtUsername.Text;
            string username = txtFullname.Text;
            string password = txtPassword.Text;
            string cfpassword = txtCFPassword.Text;
            string email = txtEmail.Text;
            if (!checkfullname(fullname)) { MessageBox.Show("Vui lòng nhập họ tên người dùng từ 6 đến 20 ký tự, không dùng ký tự đặc biệt."); return; }
            if (!checkusername(username)) { MessageBox.Show("Vui lòng nhập tên tài khoản từ 4 đến 15 ký tự, không dùng ký tự đặc biệt."); return; }
            if (!checkpass(password)) { MessageBox.Show("Vui lòng nhập tên tài khoản từ 6 đến 20 ký tự, không dùng ký tự đặc biệt."); return; }
            if (cfpassword != password) { MessageBox.Show("Mật khẩu không khớp"); return; }
            if (!checkemail(email)) { MessageBox.Show("Vui lòng nhập đúng định dạng email."); return; }

            //kết nối tới db và kiểm tra xem người dùng đã tồn tại chưa
            var client = new MongoClient("mongodb+srv://nt106-p13:hocltmkhongvui@clusteruyenthy.wttnb.mongodb.net/");
            var database = client.GetDatabase("DOAN");
            var collection = database.GetCollection<BsonDocument>("Users");

            var filter = Builders<BsonDocument>.Filter.Eq("username", username);
            var existingUser = await collection.Find(filter).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.");
                return;
            }
            //Hash password bằng SHA256
            using (SHA256 al = SHA256.Create())
            {
                byte[] inputbyte = Encoding.UTF8.GetBytes(password);
                byte[] hashbyte = al.ComputeHash(inputbyte);
                string hashedPassword = BitConverter.ToString(hashbyte).Replace("-", "").ToLower(); 

                var user = new BsonDocument
        {
            { "fullname", fullname},
            { "username", username },
            { "password", hashedPassword }, // Lưu mật khẩu đã mã hóa
            { "email", email }
        };

                // Thêm người dùng vào cơ sở dữ liệu
                await collection.InsertOneAsync(user);

                MessageBox.Show("Đăng ký thành công!");
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
            }

        }

        
    }
}
