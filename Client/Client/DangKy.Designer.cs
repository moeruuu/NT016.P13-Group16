namespace Client
{
    partial class DangKy
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFullname = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtCFPassword = new TextBox();
            btnSignUp = new Button();
            btnBack = new Button();
            btnExit = new Button();
            txtUsername = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(191, 9);
            label1.Name = "label1";
            label1.Size = new Size(413, 52);
            label1.TabIndex = 1;
            label1.Text = "Đăng Ký Tài Khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 64, 64);
            label2.Location = new Point(47, 463);
            label2.Name = "label2";
            label2.Size = new Size(77, 26);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 64, 64);
            label3.Location = new Point(47, 282);
            label3.Name = "label3";
            label3.Size = new Size(115, 26);
            label3.TabIndex = 3;
            label3.Text = "Mật Khẩu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 64, 64);
            label4.Location = new Point(47, 191);
            label4.Name = "label4";
            label4.Size = new Size(164, 26);
            label4.TabIndex = 4;
            label4.Text = "Tên Tài Khoản:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 64, 64);
            label5.Location = new Point(47, 374);
            label5.Name = "label5";
            label5.Size = new Size(214, 26);
            label5.TabIndex = 5;
            label5.Text = "Xác Nhận Mật Khẩu:";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(267, 100);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(474, 31);
            txtFullname.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(267, 277);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(474, 31);
            txtPassword.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(267, 458);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(474, 31);
            txtEmail.TabIndex = 8;
            // 
            // txtCFPassword
            // 
            txtCFPassword.Location = new Point(267, 369);
            txtCFPassword.Name = "txtCFPassword";
            txtCFPassword.PasswordChar = '*';
            txtCFPassword.Size = new Size(474, 31);
            txtCFPassword.TabIndex = 9;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.LightCyan;
            btnSignUp.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.FromArgb(0, 64, 64);
            btnSignUp.Location = new Point(267, 530);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(154, 62);
            btnSignUp.TabIndex = 10;
            btnSignUp.Text = "Đăng Ký ";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightCyan;
            btnBack.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.FromArgb(0, 64, 64);
            btnBack.Location = new Point(522, 530);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(219, 62);
            btnBack.TabIndex = 11;
            btnBack.Text = "Quay Lại Trang Đăng Nhập";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightCyan;
            btnExit.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.FromArgb(0, 64, 64);
            btnExit.Location = new Point(587, 641);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(154, 62);
            btnExit.TabIndex = 12;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(267, 186);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(474, 31);
            txtUsername.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(0, 64, 64);
            label6.Location = new Point(47, 105);
            label6.Name = "label6";
            label6.Size = new Size(182, 26);
            label6.TabIndex = 13;
            label6.Text = "Tên Người Dùng:";
            // 
            // DangKy
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.LightBlue;
            ClientSize = new Size(814, 754);
            Controls.Add(txtUsername);
            Controls.Add(label6);
            Controls.Add(btnExit);
            Controls.Add(btnBack);
            Controls.Add(btnSignUp);
            Controls.Add(txtCFPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtFullname);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DangKy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtFullname;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtCFPassword;
        private Button btnSignUp;
        private Button btnBack;
        private Button btnExit;
        private TextBox txtUsername;
        private Label label6;
    }
}