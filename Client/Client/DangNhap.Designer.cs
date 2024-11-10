namespace Client
{
    partial class DangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            pictureBox3 = new PictureBox();
            txtUsername = new TextBox();
            pictureBox1 = new PictureBox();
            txtPassword = new TextBox();
            btnSignUp = new Button();
            btnExit = new Button();
            btnLogin = new Button();
            linkForgotPassword = new LinkLabel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AllowDrop = true;
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.CausesValidation = false;
            label1.Font = new Font("Cambria", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(52, 95);
            label1.Name = "label1";
            label1.Size = new Size(600, 74);
            label1.TabIndex = 13;
            label1.Text = "Watch your favorite movies anytime,\r\n                                    anywhere with UITflix!";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(64, 390);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(73, 70);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(173, 296);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(450, 31);
            txtUsername.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(64, 268);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 70);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(173, 419);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(450, 31);
            txtPassword.TabIndex = 8;
            // 
            // btnSignUp
            // 
            btnSignUp.AutoSize = true;
            btnSignUp.BackColor = Color.LightCyan;
            btnSignUp.BackgroundImageLayout = ImageLayout.Center;
            btnSignUp.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnSignUp.ForeColor = Color.FromArgb(0, 64, 64);
            btnSignUp.Location = new Point(269, 549);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(150, 56);
            btnSignUp.TabIndex = 9;
            btnSignUp.Text = "Đăng Ký";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.BackColor = Color.LightCyan;
            btnExit.BackgroundImageLayout = ImageLayout.Center;
            btnExit.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(0, 64, 64);
            btnExit.Location = new Point(473, 549);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 56);
            btnExit.TabIndex = 10;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.BackColor = Color.LightCyan;
            btnLogin.BackgroundImageLayout = ImageLayout.Center;
            btnLogin.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(0, 64, 64);
            btnLogin.Location = new Point(64, 549);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 56);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.AutoSize = true;
            linkForgotPassword.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkForgotPassword.LinkColor = Color.FromArgb(0, 64, 64);
            linkForgotPassword.Location = new Point(446, 487);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(177, 26);
            linkForgotPassword.TabIndex = 14;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Quên Mật Khẩu?";
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // DangNhap
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.LightBlue;
            ClientSize = new Size(725, 682);
            Controls.Add(linkForgotPassword);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);
            Controls.Add(btnSignUp);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox1);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox3);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private PictureBox pictureBox3;
        private TextBox txtUsername;
        private PictureBox pictureBox1;
        private TextBox txtPassword;
        private Button btnSignUp;
        private Button btnExit;
        private Button btnLogin;
        private Label label1;
        private LinkLabel linkForgotPassword;
    }
}
