namespace UITFLIX
{
    partial class Room
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room));
            panel1 = new Panel();
            linkleaveroom = new LinkLabel();
            IDRoom = new Label();
            label3 = new Label();
            logo = new PictureBox();
            axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            namefilm = new Label();
            label1 = new Label();
            listusers = new ListBox();
            listchatgroup = new ListBox();
            textBox1 = new TextBox();
            btnsendmessage = new Button();
            listqueuevideo = new ListBox();
            label2 = new Label();
            rcmvideopanel = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Controls.Add(linkleaveroom);
            panel1.Controls.Add(IDRoom);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(logo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1787, 64);
            panel1.TabIndex = 0;
            // 
            // linkleaveroom
            // 
            linkleaveroom.ActiveLinkColor = Color.MidnightBlue;
            linkleaveroom.AutoSize = true;
            linkleaveroom.LinkColor = Color.White;
            linkleaveroom.Location = new Point(1679, 39);
            linkleaveroom.Name = "linkleaveroom";
            linkleaveroom.Size = new Size(105, 25);
            linkleaveroom.TabIndex = 4;
            linkleaveroom.TabStop = true;
            linkleaveroom.Text = "Leave room";
            linkleaveroom.LinkClicked += linkleaveroom_LinkClicked;
            // 
            // IDRoom
            // 
            IDRoom.AutoSize = true;
            IDRoom.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IDRoom.ForeColor = Color.MidnightBlue;
            IDRoom.Location = new Point(108, 18);
            IDRoom.Name = "IDRoom";
            IDRoom.Size = new Size(108, 26);
            IDRoom.TabIndex = 3;
            IDRoom.Text = "01234567";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(77, 18);
            label3.Name = "label3";
            label3.Size = new Size(40, 26);
            label3.TabIndex = 2;
            label3.Text = "ID:";
            // 
            // logo
            // 
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(0, 0);
            logo.Name = "logo";
            logo.Size = new Size(64, 64);
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.TabIndex = 1;
            logo.TabStop = false;
            // 
            // axWindowsMediaPlayer
            // 
            axWindowsMediaPlayer.Enabled = true;
            axWindowsMediaPlayer.Location = new Point(12, 79);
            axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            axWindowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer.OcxState");
            axWindowsMediaPlayer.Size = new Size(1280, 720);
            axWindowsMediaPlayer.TabIndex = 1;
            // 
            // namefilm
            // 
            namefilm.AutoSize = true;
            namefilm.BackColor = Color.Transparent;
            namefilm.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namefilm.ForeColor = Color.White;
            namefilm.Location = new Point(12, 802);
            namefilm.Name = "namefilm";
            namefilm.Size = new Size(124, 28);
            namefilm.TabIndex = 2;
            namefilm.Text = "Name film";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 884);
            label1.Name = "label1";
            label1.Size = new Size(269, 23);
            label1.TabIndex = 3;
            label1.Text = "New videos you should watch:";
            // 
            // listusers
            // 
            listusers.Font = new Font("Cambria", 10F);
            listusers.ForeColor = Color.MidnightBlue;
            listusers.FormattingEnabled = true;
            listusers.ItemHeight = 23;
            listusers.Location = new Point(1323, 79);
            listusers.Name = "listusers";
            listusers.Size = new Size(435, 211);
            listusers.TabIndex = 5;
            // 
            // listchatgroup
            // 
            listchatgroup.Font = new Font("Cambria", 10F);
            listchatgroup.ForeColor = Color.MidnightBlue;
            listchatgroup.FormattingEnabled = true;
            listchatgroup.ItemHeight = 23;
            listchatgroup.Location = new Point(1323, 324);
            listchatgroup.Name = "listchatgroup";
            listchatgroup.Size = new Size(435, 418);
            listchatgroup.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Cambria", 10F);
            textBox1.ForeColor = Color.MidnightBlue;
            textBox1.Location = new Point(1323, 768);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(354, 31);
            textBox1.TabIndex = 7;
            // 
            // btnsendmessage
            // 
            btnsendmessage.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsendmessage.ForeColor = Color.MidnightBlue;
            btnsendmessage.Location = new Point(1683, 768);
            btnsendmessage.Name = "btnsendmessage";
            btnsendmessage.Size = new Size(75, 34);
            btnsendmessage.TabIndex = 8;
            btnsendmessage.Text = "SEND";
            btnsendmessage.UseVisualStyleBackColor = true;
            // 
            // listqueuevideo
            // 
            listqueuevideo.FormattingEnabled = true;
            listqueuevideo.ItemHeight = 25;
            listqueuevideo.Location = new Point(1323, 914);
            listqueuevideo.Name = "listqueuevideo";
            listqueuevideo.Size = new Size(435, 254);
            listqueuevideo.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1323, 884);
            label2.Name = "label2";
            label2.Size = new Size(131, 23);
            label2.TabIndex = 10;
            label2.Text = "Queue videos:";
            // 
            // rcmvideopanel
            // 
            rcmvideopanel.Location = new Point(12, 914);
            rcmvideopanel.Name = "rcmvideopanel";
            rcmvideopanel.Size = new Size(1280, 254);
            rcmvideopanel.TabIndex = 11;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1787, 1200);
            Controls.Add(rcmvideopanel);
            Controls.Add(label2);
            Controls.Add(listqueuevideo);
            Controls.Add(btnsendmessage);
            Controls.Add(textBox1);
            Controls.Add(listchatgroup);
            Controls.Add(listusers);
            Controls.Add(label1);
            Controls.Add(namefilm);
            Controls.Add(axWindowsMediaPlayer);
            Controls.Add(panel1);
            ForeColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Room";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateRoom";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox logo;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private Label namefilm;
        private Label label1;
        private ListBox listusers;
        private ListBox listchatgroup;
        private TextBox textBox1;
        private Button btnsendmessage;
        private ListBox listqueuevideo;
        private Label label2;
        private Label IDRoom;
        private Label label3;
        private LinkLabel linkleaveroom;
        private FlowLayoutPanel rcmvideopanel;
    }
}