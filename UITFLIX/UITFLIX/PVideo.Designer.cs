namespace UITFLIX
{
    partial class PVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PVideo));
            panel2 = new Panel();
            btndes = new FontAwesome.Sharp.IconButton();
            txtnamefilm = new Label();
            pictureBox1 = new PictureBox();
            txtdate = new Label();
            panel3 = new Panel();
            tbdes = new RichTextBox();
            description = new Panel();
            axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            description.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btndes);
            panel2.Controls.Add(txtnamefilm);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1280, 39);
            panel2.TabIndex = 1;
            // 
            // btndes
            // 
            btndes.Dock = DockStyle.Right;
            btndes.FlatAppearance.BorderSize = 0;
            btndes.FlatStyle = FlatStyle.Flat;
            btndes.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btndes.ForeColor = Color.MidnightBlue;
            btndes.IconChar = FontAwesome.Sharp.IconChar.Comment;
            btndes.IconColor = Color.MidnightBlue;
            btndes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btndes.IconSize = 35;
            btndes.Location = new Point(1074, 0);
            btndes.Name = "btndes";
            btndes.Size = new Size(206, 39);
            btndes.TabIndex = 2;
            btndes.TabStop = false;
            btndes.Text = "Description: Off";
            btndes.TextAlign = ContentAlignment.MiddleLeft;
            btndes.TextImageRelation = TextImageRelation.TextBeforeImage;
            btndes.UseVisualStyleBackColor = true;
            btndes.Click += btndes_Click;
            // 
            // txtnamefilm
            // 
            txtnamefilm.AutoSize = true;
            txtnamefilm.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtnamefilm.ForeColor = Color.MidnightBlue;
            txtnamefilm.Location = new Point(65, 7);
            txtnamefilm.Name = "txtnamefilm";
            txtnamefilm.Size = new Size(58, 21);
            txtnamefilm.TabIndex = 1;
            txtnamefilm.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtdate
            // 
            txtdate.AutoSize = true;
            txtdate.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtdate.ForeColor = Color.MidnightBlue;
            txtdate.Location = new Point(12, 51);
            txtdate.Name = "txtdate";
            txtdate.Size = new Size(62, 23);
            txtdate.TabIndex = 0;
            txtdate.Text = "label2";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightBlue;
            panel3.Dock = DockStyle.Top;
            panel3.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.ForeColor = SystemColors.ButtonHighlight;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1280, 31);
            panel3.TabIndex = 1;
            // 
            // tbdes
            // 
            tbdes.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbdes.ForeColor = Color.MidnightBlue;
            tbdes.Location = new Point(12, 77);
            tbdes.Name = "tbdes";
            tbdes.Size = new Size(857, 166);
            tbdes.TabIndex = 2;
            tbdes.Text = "";
            // 
            // description
            // 
            description.Controls.Add(tbdes);
            description.Controls.Add(panel3);
            description.Controls.Add(txtdate);
            description.Dock = DockStyle.Bottom;
            description.Location = new Point(0, 500);
            description.Name = "description";
            description.Size = new Size(1280, 255);
            description.TabIndex = 4;
            description.Visible = false;
            // 
            // axWindowsMediaPlayer
            // 
            axWindowsMediaPlayer.Dock = DockStyle.Fill;
            axWindowsMediaPlayer.Enabled = true;
            axWindowsMediaPlayer.Location = new Point(0, 39);
            axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            axWindowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer.OcxState");
            axWindowsMediaPlayer.Size = new Size(1280, 716);
            axWindowsMediaPlayer.TabIndex = 3;
            // 
            // PVideo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 755);
            Controls.Add(description);
            Controls.Add(axWindowsMediaPlayer);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PVideo";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            description.ResumeLayout(false);
            description.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label UITFLIX;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label txtnamefilm;
        private FontAwesome.Sharp.IconButton btndes;
        private Label txtdate;
        private Panel panel3;
        private RichTextBox tbdes;
        private Panel description;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
    }
}