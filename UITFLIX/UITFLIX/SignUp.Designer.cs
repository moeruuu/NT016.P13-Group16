namespace UITFLIX
{
    partial class SignUp
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
            txtFullname = new TextBox();
            label6 = new Label();
            btnBack = new Button();
            btnSignUp = new Button();
            txtCFPassword = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(269, 97);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(474, 31);
            txtFullname.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 64, 64);
            label6.Location = new Point(49, 98);
            label6.Name = "label6";
            label6.Size = new Size(182, 26);
            label6.TabIndex = 27;
            label6.Text = "Tên Người Dùng:";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightCyan;
            btnBack.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(0, 64, 64);
            btnBack.Location = new Point(524, 523);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(219, 62);
            btnBack.TabIndex = 25;
            btnBack.Text = "Quay Lại Trang Đăng Nhập";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.LightCyan;
            btnSignUp.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.FromArgb(0, 64, 64);
            btnSignUp.Location = new Point(269, 523);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(154, 62);
            btnSignUp.TabIndex = 24;
            btnSignUp.Text = "Đăng Ký ";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtCFPassword
            // 
            txtCFPassword.Location = new Point(269, 362);
            txtCFPassword.Name = "txtCFPassword";
            txtCFPassword.PasswordChar = '*';
            txtCFPassword.Size = new Size(474, 31);
            txtCFPassword.TabIndex = 23;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(269, 451);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(474, 31);
            txtEmail.TabIndex = 22;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(269, 270);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(474, 31);
            txtPassword.TabIndex = 21;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(269, 179);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(474, 31);
            txtUsername.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 64, 64);
            label5.Location = new Point(49, 367);
            label5.Name = "label5";
            label5.Size = new Size(214, 26);
            label5.TabIndex = 19;
            label5.Text = "Xác Nhận Mật Khẩu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 64, 64);
            label4.Location = new Point(49, 184);
            label4.Name = "label4";
            label4.Size = new Size(164, 26);
            label4.TabIndex = 18;
            label4.Text = "Tên Tài Khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 64, 64);
            label3.Location = new Point(49, 275);
            label3.Name = "label3";
            label3.Size = new Size(115, 26);
            label3.TabIndex = 17;
            label3.Text = "Mật Khẩu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 64, 64);
            label2.Location = new Point(49, 456);
            label2.Name = "label2";
            label2.Size = new Size(77, 26);
            label2.TabIndex = 16;
            label2.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(193, 2);
            label1.Name = "label1";
            label1.Size = new Size(413, 52);
            label1.TabIndex = 15;
            label1.Text = "Đăng Ký Tài Khoản";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(792, 698);
            Controls.Add(txtFullname);
            Controls.Add(label6);
            Controls.Add(btnBack);
            Controls.Add(btnSignUp);
            Controls.Add(txtCFPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SignUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFullname;
        private Label label6;
        private Button btnBack;
        private Button btnSignUp;
        private TextBox txtCFPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}