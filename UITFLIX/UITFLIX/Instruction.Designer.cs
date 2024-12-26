namespace UITFLIX
{
    partial class Instruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instruction));
            flowLayoutPanel1 = new FlowLayoutPanel();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            richTextBox2 = new RichTextBox();
            pictureBox3 = new PictureBox();
            richTextBox3 = new RichTextBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(richTextBox1);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Controls.Add(pictureBox2);
            flowLayoutPanel1.Controls.Add(richTextBox2);
            flowLayoutPanel1.Controls.Add(pictureBox3);
            flowLayoutPanel1.Controls.Add(richTextBox3);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(878, 524);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.LightBlue;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.CausesValidation = false;
            richTextBox1.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.MidnightBlue;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(847, 76);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "Để sử dụng được tài khoản Gmail chúng ta không thể sử dụng trực tiếp mật khẩu của tài khoản Google mà phải tạo App password để đăng nhập.\n- B1: Mở xác thực mật khẩu hai bước";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(847, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 274);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(847, 747);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.LightBlue;
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.CausesValidation = false;
            richTextBox2.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox2.ForeColor = Color.MidnightBlue;
            richTextBox2.Location = new Point(3, 1027);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(847, 79);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "- B2: Truy cập: https://myaccount.google.com/apppasswords\n- B3: Tạo một app password và lưu lại để sử dụng cho việc xác thực với gmail server\n*Lưu ý: Cần xóa các khoảng cách";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 1112);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(844, 622);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // richTextBox3
            // 
            richTextBox3.BackColor = Color.LightBlue;
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox3.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox3.ForeColor = Color.MidnightBlue;
            richTextBox3.Location = new Point(3, 1740);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(847, 33);
            richTextBox3.TabIndex = 7;
            richTextBox3.Text = "*Lưu ý: Đừng tiết lộ app password cho bất cứ ai!";
            richTextBox3.TextChanged += richTextBox3_TextChanged;
            // 
            // Instruction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(902, 548);
            Controls.Add(flowLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Instruction";
            Text = "Instruction (Vietnamese ver)";
            Load += Instruction_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private RichTextBox richTextBox2;
        private PictureBox pictureBox3;
        private RichTextBox richTextBox3;
    }
}