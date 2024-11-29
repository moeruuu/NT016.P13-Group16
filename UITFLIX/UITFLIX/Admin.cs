using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UITFLIX.Services;

namespace UITFLIX
{
    public partial class Admin : Form
    {
        private readonly JObject userinfo;
        private readonly string accesstoken;

        private readonly UserService userService;
        public Admin(JObject user, string token)
        {
            InitializeComponent();
            userinfo = user;
            accesstoken = token;
            userService = new UserService();
            Settingnames();

        }

        void Settingnames()
        {
            lblName.Text += userinfo["user"]["fullname"].ToString();
        }

        private async void logout_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                var LogOutModel = new
                {
                    Id = userinfo["user"]["id"].ToString()
                };
                var response = await userService.LogOut(LogOutModel, accesstoken);
                if (response.Contains("thành công!"))
                {
                    this.Hide();
                    LogIn login = new LogIn();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }
    }

}
