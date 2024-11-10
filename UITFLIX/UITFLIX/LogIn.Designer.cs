namespace UITFLIX
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
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            btnLogin = new Button();
            btnSignUp = new Button();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
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
            label1.Location = new Point(51, 58);
            label1.Name = "label1";
            label1.Size = new Size(600, 74);
            label1.TabIndex = 23;
            label1.Text = "Watch your favorite movies anytime,\r\n                                    anywhere with UITflix!";
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.BackColor = Color.LightCyan;
            btnLogin.BackgroundImageLayout = ImageLayout.Center;
            btnLogin.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(0, 64, 64);
            btnLogin.Location = new Point(172, 512);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 56);
            btnLogin.TabIndex = 22;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.AutoSize = true;
            btnSignUp.BackColor = Color.LightCyan;
            btnSignUp.BackgroundImageLayout = ImageLayout.Center;
            btnSignUp.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnSignUp.ForeColor = Color.FromArgb(0, 64, 64);
            btnSignUp.Location = new Point(472, 512);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(150, 56);
            btnSignUp.TabIndex = 20;
            btnSignUp.Text = "Đăng Ký";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(172, 382);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(450, 31);
            txtPassword.TabIndex = 19;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(63, 231);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 70);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(172, 259);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(450, 31);
            txtUsername.TabIndex = 17;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(63, 353);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(73, 70);
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(703, 626);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(btnSignUp);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox1);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox3);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogin;
        private Button btnSignUp;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private PictureBox pictureBox3;
    }
}