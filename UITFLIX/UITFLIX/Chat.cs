﻿using Newtonsoft.Json.Linq;
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
        private MailService chatService;
        private JObject _userInfo;
        private string _accessToken;

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

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                string subject = textBoxSubject.Text;
                string body = richTextBoxBody.Text;
                string attachmentPath = textBoxAttachmentPath.Text;
                if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body))
                {
                    MessageBox.Show("Please fill in all the required information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }
        private async Task UpdateProgressBarAsync()
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;
                await Task.Delay(17);
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

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
