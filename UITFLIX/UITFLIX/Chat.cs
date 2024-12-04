using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UITFLIX.Models;
using UITFLIX.Services;
using Newtonsoft.Json;
namespace UITFLIX
{
    public partial class Chat : Form
    {
        private ChatService chatService;
        private JObject _userInfo;
        private string _accessToken;
        public Chat(JObject userInfo, string accessToken)
        {
            InitializeComponent();
            _userInfo = userInfo;;
            chatService = new ChatService(accessToken);
        }

        private void iconPictureBoxChat_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBoxHome_Click(object sender, EventArgs e)
        {
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                string subject = textBoxSubject.Text;
                string body = richTextBoxBody.Text;
                string attachmentPath = textBoxAttachmentPath.Text;
                if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string name = _userInfo["user"]["fullname"].ToString();
                string email = _userInfo["user"]["email"].ToString();
                var chatModel = new ChatModel
                {
                    Name = name,
                    Email = email,
                    Subject = subject,
                    Body = body,
                };
                if (!string.IsNullOrWhiteSpace(attachmentPath))
                {
                    chatModel.AttachmentPath = attachmentPath;
                }
                string jsonData = JsonConvert.SerializeObject(chatModel);
                MessageBox.Show(jsonData);
                var response = await chatService.SendEmailAsync(chatModel);
                MessageBox.Show(response, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Chat_Load(object sender, EventArgs e)
        {
            textBoxName.Text = _userInfo["user"]["fullname"].ToString();
            textBoxEmail.Text = _userInfo["user"]["email"].ToString();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text and Image Files|*.txt;*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.doc; *.docx";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    if (!File.Exists(selectedFilePath))
                    {
                        MessageBox.Show("Tệp không tồn tại. Vui lòng chọn lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    if (fileInfo.Length > 10 * 1024 * 1024)
                    {
                        MessageBox.Show("Tệp đính kèm không được vượt quá 10 MB!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string[] allowedExtensions = { ".txt", ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".doc", ".docx" };
                    string fileExtension = fileInfo.Extension.ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        MessageBox.Show("Chỉ cho phép tệp văn bản (*.txt), hình ảnh (*.jpg, *.jpeg, *.png, *.bmp, *.gif) hoặc word (*.doc, *.docx)!",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    textBoxAttachmentPath.Text = selectedFilePath;
                }
            }
        }
    }
}
