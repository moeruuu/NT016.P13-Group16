﻿namespace UITFLIX
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            txtPassword = new TextBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            btnlogin = new Button();
            linksignup = new LinkLabel();
            lbwait = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.UITFLIX;
            pictureBox1.Location = new Point(170, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.LightBlue;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Location = new Point(103, 394);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(394, 24);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SVN-Harabaras", 14F);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(37, 208);
            label1.Name = "label1";
            label1.Size = new Size(427, 35);
            label1.TabIndex = 2;
            label1.Text = "Watch your favorite movies anytime,";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SVN-Harabaras", 14F);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(235, 243);
            label2.Name = "label2";
            label2.Size = new Size(262, 35);
            label2.TabIndex = 3;
            label2.Text = "anywhere with UITflix!";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Location = new Point(37, 424);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 1);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Azure;
            panel2.Location = new Point(37, 511);
            panel2.Name = "panel2";
            panel2.Size = new Size(460, 1);
            panel2.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.LightBlue;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Location = new Point(103, 481);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(394, 24);
            txtPassword.TabIndex = 5;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.LightBlue;
            iconPictureBox1.ForeColor = SystemColors.ControlLightLight;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            iconPictureBox1.IconColor = SystemColors.ControlLightLight;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 48;
            iconPictureBox1.Location = new Point(37, 374);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(48, 48);
            iconPictureBox1.TabIndex = 7;
            iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.LightBlue;
            iconPictureBox2.ForeColor = SystemColors.ControlLightLight;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Lock;
            iconPictureBox2.IconColor = SystemColors.ControlLightLight;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 48;
            iconPictureBox2.Location = new Point(37, 461);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(48, 48);
            iconPictureBox2.TabIndex = 8;
            iconPictureBox2.TabStop = false;
            // 
            // btnlogin
            // 
            btnlogin.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = Color.CadetBlue;
            btnlogin.Location = new Point(346, 537);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(151, 34);
            btnlogin.TabIndex = 9;
            btnlogin.Text = "Đăng nhập";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // linksignup
            // 
            linksignup.ActiveLinkColor = Color.CornflowerBlue;
            linksignup.AutoSize = true;
            linksignup.LinkColor = Color.CadetBlue;
            linksignup.Location = new Point(37, 543);
            linksignup.Name = "linksignup";
            linksignup.Size = new Size(164, 23);
            linksignup.TabIndex = 10;
            linksignup.TabStop = true;
            linksignup.Text = "Tạo tài khoản mới";
            linksignup.LinkClicked += linksignup_LinkClicked;
            // 
            // lbwait
            // 
            lbwait.AutoSize = true;
            lbwait.ForeColor = Color.DarkCyan;
            lbwait.Location = new Point(179, 610);
            lbwait.Name = "lbwait";
            lbwait.Size = new Size(14, 23);
            lbwait.TabIndex = 11;
            lbwait.Text = " ";
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(540, 659);
            Controls.Add(lbwait);
            Controls.Add(linksignup);
            Controls.Add(btnlogin);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            Load += LogIn_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtPassword;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Button btnlogin;
        private LinkLabel linksignup;
        private Label lbwait;
    }
}