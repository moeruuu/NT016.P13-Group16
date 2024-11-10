namespace Client
{
    partial class QuenMatKhau
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
            label4 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 64, 64);
            label4.Location = new Point(48, 153);
            label4.Name = "label4";
            label4.Size = new Size(165, 26);
            label4.TabIndex = 5;
            label4.Text = "Email Đăng Ký:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(230, 44);
            label1.Name = "label1";
            label1.Size = new Size(321, 52);
            label1.TabIndex = 6;
            label1.Text = "Quên Mật Khẩu";
           
            // 
            // textBox1
            // 
            textBox1.Location = new Point(259, 148);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(456, 31);
            textBox1.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = Color.LightCyan;
            button1.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 64, 64);
            button1.Location = new Point(259, 233);
            button1.Name = "button1";
            button1.Size = new Size(223, 64);
            button1.TabIndex = 11;
            button1.Text = "Lấy Lại Mật Khẩu";
            button1.UseVisualStyleBackColor = false;
            
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightCyan;
            btnExit.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.FromArgb(0, 64, 64);
            btnExit.Location = new Point(567, 233);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(148, 64);
            btnExit.TabIndex = 12;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // QuenMatKhau
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.LightBlue;
            ClientSize = new Size(775, 626);
            Controls.Add(btnExit);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label4);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "QuenMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuenMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button btnExit;
    }
}