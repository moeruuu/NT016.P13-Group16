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
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            linkLabel1 = new LinkLabel();
            txtnamefilm = new Label();
            logo = new PictureBox();
            bottompanel = new Panel();
            star5 = new PictureBox();
            star4 = new PictureBox();
            star3 = new PictureBox();
            star2 = new PictureBox();
            star1 = new PictureBox();
            total = new Label();
            averrate = new Label();
            leftbottm = new Panel();
            panel1 = new Panel();
            tbdes = new RichTextBox();
            txtnamefilm1 = new Label();
            axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            bottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)star5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star1).BeginInit();
            leftbottm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(iconPictureBox1);
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(txtnamefilm);
            panel2.Controls.Add(logo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1232, 39);
            panel2.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = Color.MidnightBlue;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Download;
            iconPictureBox1.IconColor = Color.MidnightBlue;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 30;
            iconPictureBox1.Location = new Point(1050, 4);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(30, 30);
            iconPictureBox1.TabIndex = 3;
            iconPictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.CadetBlue;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.MidnightBlue;
            linkLabel1.Location = new Point(1080, 5);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(158, 23);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Download video";
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
            // logo
            // 
            logo.Cursor = Cursors.Hand;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(0, 0);
            logo.Name = "logo";
            logo.Size = new Size(50, 50);
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.TabIndex = 0;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // bottompanel
            // 
            bottompanel.Controls.Add(star5);
            bottompanel.Controls.Add(star4);
            bottompanel.Controls.Add(star3);
            bottompanel.Controls.Add(star2);
            bottompanel.Controls.Add(star1);
            bottompanel.Controls.Add(total);
            bottompanel.Controls.Add(averrate);
            bottompanel.Controls.Add(leftbottm);
            bottompanel.Dock = DockStyle.Bottom;
            bottompanel.Font = new Font("Cambria", 10F);
            bottompanel.ForeColor = Color.MidnightBlue;
            bottompanel.Location = new Point(0, 751);
            bottompanel.Name = "bottompanel";
            bottompanel.Size = new Size(1232, 165);
            bottompanel.TabIndex = 2;
            // 
            // star5
            // 
            star5.Cursor = Cursors.Hand;
            star5.Location = new Point(1150, 35);
            star5.Name = "star5";
            star5.Size = new Size(50, 50);
            star5.SizeMode = PictureBoxSizeMode.StretchImage;
            star5.TabIndex = 7;
            star5.TabStop = false;
            star5.Click += star5_Click;
            // 
            // star4
            // 
            star4.Cursor = Cursors.Hand;
            star4.Location = new Point(1094, 35);
            star4.Name = "star4";
            star4.Size = new Size(50, 50);
            star4.SizeMode = PictureBoxSizeMode.StretchImage;
            star4.TabIndex = 6;
            star4.TabStop = false;
            star4.Click += star4_Click;
            // 
            // star3
            // 
            star3.Cursor = Cursors.Hand;
            star3.Location = new Point(1038, 35);
            star3.Name = "star3";
            star3.Size = new Size(50, 50);
            star3.SizeMode = PictureBoxSizeMode.StretchImage;
            star3.TabIndex = 5;
            star3.TabStop = false;
            star3.Click += star3_Click;
            // 
            // star2
            // 
            star2.Cursor = Cursors.Hand;
            star2.Location = new Point(982, 35);
            star2.Name = "star2";
            star2.Size = new Size(50, 50);
            star2.SizeMode = PictureBoxSizeMode.StretchImage;
            star2.TabIndex = 4;
            star2.TabStop = false;
            star2.Click += star2_Click;
            // 
            // star1
            // 
            star1.Cursor = Cursors.Hand;
            star1.Location = new Point(926, 35);
            star1.Name = "star1";
            star1.Size = new Size(50, 50);
            star1.SizeMode = PictureBoxSizeMode.StretchImage;
            star1.TabIndex = 3;
            star1.TabStop = false;
            star1.Click += star1_Click;
            // 
            // total
            // 
            total.AutoSize = true;
            total.Location = new Point(926, 100);
            total.Name = "total";
            total.Size = new Size(92, 23);
            total.TabIndex = 2;
            total.Text = "Based on ";
            // 
            // averrate
            // 
            averrate.AutoSize = true;
            averrate.Font = new Font("Cambria", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            averrate.Location = new Point(814, 35);
            averrate.Name = "averrate";
            averrate.Size = new Size(96, 61);
            averrate.TabIndex = 1;
            averrate.Text = "0.0";
            // 
            // leftbottm
            // 
            leftbottm.Controls.Add(panel1);
            leftbottm.Controls.Add(tbdes);
            leftbottm.Controls.Add(txtnamefilm1);
            leftbottm.Dock = DockStyle.Left;
            leftbottm.Font = new Font("Cambria", 10F);
            leftbottm.ForeColor = Color.MidnightBlue;
            leftbottm.Location = new Point(0, 0);
            leftbottm.Name = "leftbottm";
            leftbottm.Size = new Size(797, 165);
            leftbottm.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Location = new Point(789, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(3, 150);
            panel1.TabIndex = 2;
            // 
            // tbdes
            // 
            tbdes.BorderStyle = BorderStyle.None;
            tbdes.Location = new Point(12, 55);
            tbdes.Name = "tbdes";
            tbdes.Size = new Size(762, 94);
            tbdes.TabIndex = 1;
            tbdes.Text = "";
            // 
            // txtnamefilm1
            // 
            txtnamefilm1.AutoSize = true;
            txtnamefilm1.Font = new Font("Cambria", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtnamefilm1.Location = new Point(12, 16);
            txtnamefilm1.Name = "txtnamefilm1";
            txtnamefilm1.Size = new Size(97, 33);
            txtnamefilm1.TabIndex = 0;
            txtnamefilm1.Text = "label1";
            // 
            // axWindowsMediaPlayer
            // 
            axWindowsMediaPlayer.Dock = DockStyle.Fill;
            axWindowsMediaPlayer.Enabled = true;
            axWindowsMediaPlayer.Location = new Point(0, 39);
            axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            axWindowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer.OcxState");
            axWindowsMediaPlayer.Size = new Size(1232, 712);
            axWindowsMediaPlayer.TabIndex = 3;
            // 
            // PVideo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1232, 916);
            Controls.Add(axWindowsMediaPlayer);
            Controls.Add(bottompanel);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PVideo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PVideo";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            bottompanel.ResumeLayout(false);
            bottompanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)star5).EndInit();
            ((System.ComponentModel.ISupportInitialize)star4).EndInit();
            ((System.ComponentModel.ISupportInitialize)star3).EndInit();
            ((System.ComponentModel.ISupportInitialize)star2).EndInit();
            ((System.ComponentModel.ISupportInitialize)star1).EndInit();
            leftbottm.ResumeLayout(false);
            leftbottm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label UITFLIX;
        private PictureBox logo;
        private Panel panel2;
        private Label txtnamefilm;
        private Panel bottompanel;
        private Label total;
        private Label averrate;
        private Panel leftbottm;
        private RichTextBox tbdes;
        private Label txtnamefilm1;
        private PictureBox star5;
        private PictureBox star4;
        private PictureBox star3;
        private PictureBox star2;
        private PictureBox star1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private LinkLabel linkLabel1;
    }
}