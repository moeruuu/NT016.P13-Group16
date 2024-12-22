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
using System.Security.Cryptography;
namespace UITFLIX
    
{
    public partial class Chat : Form
    {
        private MailService chatService;
        private JObject _userInfo;
        private string _accessToken;
        private string _plaintextEmailPassword;
        private bool isPasswordVisible = false;

        public Chat(JObject userInfo, string accessToken)
        {
            InitializeComponent();
            _userInfo = userInfo; ;
            chatService = new MailService(accessToken);
        }

        private void logo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            textBoxName.Text = _userInfo["user"]["fullname"].ToString();
            textBoxEmail.Text = _userInfo["user"]["email"].ToString();

            LoadUserEmailPasswordAsync();
            iconEye.BringToFront();
        }
        public async Task LoadUserEmailPasswordAsync()
        {
            try
            {
                var encryptedPassword = await chatService.GetEmailPasswordAsync();

                if (!string.IsNullOrEmpty(encryptedPassword))
                {
                    textBoxEmailPassword.PasswordChar = '*';
                    textBoxEmailPassword.Text = encryptedPassword;
                    textBoxEmailPassword.Tag = encryptedPassword;
                }
                else
                {
                    textBoxEmailPassword.Text = string.Empty;
                    textBoxEmailPassword.Tag = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading email password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                string subject = textBoxSubject.Text;
                string body = richTextBoxBody.Text;
                string attachmentPath = textBoxAttachmentPath.Text;
                string emailPassword = textBoxEmailPassword.Text.Trim();
                if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body))
                {
                    MessageBox.Show("Please fill in all the required information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (emailPassword == "*******************")
                {
                    if (textBoxEmailPassword.Tag != null)
                    {
                        emailPassword = textBoxEmailPassword.Tag.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        await chatService.SaveEmailPasswordAsync(emailPassword);
                        textBoxEmailPassword.Text = "*******************";
                        textBoxEmailPassword.Tag = emailPassword;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving email password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                string name = _userInfo["user"]["fullname"].ToString();
                string email = _userInfo["user"]["email"].ToString();
                var chatModel = new ChatModel
                {
                    Name = name,
                    Email = email,
                    Subject = subject,
                    Body = body,
                    EmailPassword = emailPassword
                };

                if (!string.IsNullOrWhiteSpace(attachmentPath))
                    chatModel.AttachmentPath = attachmentPath;

                buttonSend.Enabled = false;
                progressBar.Visible = true;
                progressBar.Value = 0;
                var sendEmailTask = chatService.SendEmailAsync(chatModel);
                var progressTask = UpdateProgressBarAsync();
                await Task.WhenAll(sendEmailTask, progressTask);
                string jsonData = JsonConvert.SerializeObject(chatModel);
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
                buttonSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar.Visible = false;
                buttonSend.Enabled = true;
            }
            finally
            {
                progressBar.Visible = false;
                buttonSend.Enabled = true;
            }

        }
        private async Task UpdateProgressBarAsync()
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;
                await Task.Delay(17);
            }
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
                        MessageBox.Show("The file does not exist. Please select it again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    if (fileInfo.Length > 10 * 1024 * 1024)
                    {
                        MessageBox.Show("The attached file must not exceed 10MB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string[] allowedExtensions = { ".txt", ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".doc", ".docx" };
                    string fileExtension = fileInfo.Extension.ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        MessageBox.Show("Only text files (.txt), images (.jpg, *.jpeg, *.png, *.bmp, .gif), or Word documents (.doc, *.docx) are allowed!",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    textBoxAttachmentPath.Text = selectedFilePath;
                }
            }
        }
        public string HashPassword(string pass)
        {
            HashAlgorithm al = SHA256.Create();
            byte[] inputbyte = Encoding.UTF8.GetBytes(pass);
            byte[] hashbyte = al.ComputeHash(inputbyte);
            string hashstring = BitConverter.ToString(hashbyte).Replace("-", "");
            return hashstring;
        }
        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmailPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmailPassword.Text != "*******************")
            { 
                isPasswordVisible = false;
                iconEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;

                if (textBoxEmailPassword.PasswordChar == '\0')
                {
                    textBoxEmailPassword.PasswordChar = '*';
                }
                textBoxEmailPassword.Tag = null;
            }
        }


        private void iconEye_Click(object sender, EventArgs e)
        {
            if (!isPasswordVisible)
            {

                if (textBoxEmailPassword.Tag != null)
                {
                    textBoxEmailPassword.Text = textBoxEmailPassword.Tag.ToString();
                }
                textBoxEmailPassword.PasswordChar = '\0';
                iconEye.IconChar = FontAwesome.Sharp.IconChar.Eye;
                isPasswordVisible = true;
            }
            else 
            {
                if (textBoxEmailPassword.Tag != null)
                {
                    textBoxEmailPassword.Text = new string('*', textBoxEmailPassword.Tag.ToString().Length);
                }
                textBoxEmailPassword.PasswordChar = '*';
                iconEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                isPasswordVisible = false;
            }
        }
    }
}
