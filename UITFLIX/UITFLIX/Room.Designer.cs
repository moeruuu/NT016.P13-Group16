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
            lbname = new Label();
            linkleaveroom = new LinkLabel();
            IDRoom = new Label();
            label3 = new Label();
            logo = new PictureBox();
            axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            namefilm = new Label();
            label1 = new Label();
            listchatgroup = new ListBox();
            txtChat = new TextBox();
            btnsendmessage = new Button();
            label2 = new Label();
            rcmvideopanel = new FlowLayoutPanel();
            dgvQueue = new DataGridView();
            ColumnNum = new DataGridViewTextBoxColumn();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnTag = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Controls.Add(lbname);
            panel1.Controls.Add(linkleaveroom);
            panel1.Controls.Add(IDRoom);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(logo);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1490, 53);
            panel1.TabIndex = 0;
            // 
            // lbname
            // 
            lbname.AutoSize = true;
            lbname.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbname.ForeColor = Color.MidnightBlue;
            lbname.Location = new Point(62, 28);
            lbname.Margin = new Padding(2, 0, 2, 0);
            lbname.Name = "lbname";
            lbname.Size = new Size(0, 17);
            lbname.TabIndex = 5;
            // 
            // linkleaveroom
            // 
            linkleaveroom.ActiveLinkColor = Color.MidnightBlue;
            linkleaveroom.AutoSize = true;
            linkleaveroom.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkleaveroom.LinkColor = Color.White;
            linkleaveroom.Location = new Point(1376, 28);
            linkleaveroom.Margin = new Padding(2, 0, 2, 0);
            linkleaveroom.Name = "linkleaveroom";
            linkleaveroom.Size = new Size(112, 23);
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
            IDRoom.Location = new Point(91, 7);
            IDRoom.Margin = new Padding(2, 0, 2, 0);
            IDRoom.Name = "IDRoom";
            IDRoom.Size = new Size(98, 22);
            IDRoom.TabIndex = 3;
            IDRoom.Text = "01234567";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(62, 7);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(34, 22);
            label3.TabIndex = 2;
            label3.Text = "ID:";
            // 
            // logo
            // 
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(0, 0);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.Size = new Size(51, 51);
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.TabIndex = 1;
            logo.TabStop = false;
            // 
            // axWindowsMediaPlayer
            // 
            axWindowsMediaPlayer.Enabled = true;
            axWindowsMediaPlayer.Location = new Point(12, 79);
            axWindowsMediaPlayer.Margin = new Padding(2);
            axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            axWindowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer.OcxState");
            axWindowsMediaPlayer.Size = new Size(1060, 561);
            axWindowsMediaPlayer.TabIndex = 1;
            // 
            // namefilm
            // 
            namefilm.AutoSize = true;
            namefilm.BackColor = Color.Transparent;
            namefilm.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namefilm.ForeColor = Color.White;
            namefilm.Location = new Point(12, 642);
            namefilm.Margin = new Padding(2, 0, 2, 0);
            namefilm.Name = "namefilm";
            namefilm.Size = new Size(105, 23);
            namefilm.TabIndex = 2;
            namefilm.Text = "Name film";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 707);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(228, 20);
            label1.TabIndex = 3;
            label1.Text = "New videos you should watch:";
            // 
            // listchatgroup
            // 
            listchatgroup.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listchatgroup.ForeColor = Color.MidnightBlue;
            listchatgroup.FormattingEnabled = true;
            listchatgroup.ItemHeight = 21;
            listchatgroup.Location = new Point(1101, 79);
            listchatgroup.Margin = new Padding(2);
            listchatgroup.Name = "listchatgroup";
            listchatgroup.Size = new Size(349, 529);
            listchatgroup.TabIndex = 6;
            // 
            // txtChat
            // 
            txtChat.Font = new Font("Cambria", 10F);
            txtChat.ForeColor = Color.MidnightBlue;
            txtChat.Location = new Point(1102, 614);
            txtChat.Margin = new Padding(2);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(284, 27);
            txtChat.TabIndex = 7;
            // 
            // btnsendmessage
            // 
            btnsendmessage.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsendmessage.ForeColor = Color.MidnightBlue;
            btnsendmessage.Location = new Point(1390, 614);
            btnsendmessage.Margin = new Padding(2);
            btnsendmessage.Name = "btnsendmessage";
            btnsendmessage.Size = new Size(60, 27);
            btnsendmessage.TabIndex = 8;
            btnsendmessage.Text = "SEND";
            btnsendmessage.UseVisualStyleBackColor = true;
            btnsendmessage.Click += btnsendmessage_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1102, 707);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 10;
            label2.Text = "Queue videos:";
            // 
            // rcmvideopanel
            // 
            rcmvideopanel.Location = new Point(10, 731);
            rcmvideopanel.Margin = new Padding(2);
            rcmvideopanel.Name = "rcmvideopanel";
            rcmvideopanel.Size = new Size(1062, 248);
            rcmvideopanel.TabIndex = 11;
            // 
            // dgvQueue
            // 
            dgvQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQueue.Columns.AddRange(new DataGridViewColumn[] { ColumnNum, ColumnTitle, ColumnTag });
            dgvQueue.GridColor = Color.MidnightBlue;
            dgvQueue.Location = new Point(1102, 731);
            dgvQueue.Margin = new Padding(2);
            dgvQueue.Name = "dgvQueue";
            dgvQueue.RowHeadersWidth = 62;
            dgvQueue.Size = new Size(348, 248);
            dgvQueue.TabIndex = 12;
            // 
            // ColumnNum
            // 
            ColumnNum.HeaderText = "No.";
            ColumnNum.MinimumWidth = 8;
            ColumnNum.Name = "ColumnNum";
            ColumnNum.ReadOnly = true;
            ColumnNum.Width = 80;
            // 
            // ColumnTitle
            // 
            ColumnTitle.HeaderText = "Title";
            ColumnTitle.MinimumWidth = 8;
            ColumnTitle.Name = "ColumnTitle";
            ColumnTitle.ReadOnly = true;
            ColumnTitle.Width = 250;
            // 
            // ColumnTag
            // 
            ColumnTag.HeaderText = "Tag";
            ColumnTag.MinimumWidth = 8;
            ColumnTag.Name = "ColumnTag";
            ColumnTag.ReadOnly = true;
            ColumnTag.Width = 150;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1490, 1000);
            ControlBox = false;
            Controls.Add(dgvQueue);
            Controls.Add(rcmvideopanel);
            Controls.Add(label2);
            Controls.Add(btnsendmessage);
            Controls.Add(txtChat);
            Controls.Add(listchatgroup);
            Controls.Add(label1);
            Controls.Add(namefilm);
            Controls.Add(axWindowsMediaPlayer);
            Controls.Add(panel1);
            ForeColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Room";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateRoom";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox logo;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private Label namefilm;
        private Label label1;
        private ListBox listchatgroup;
        private TextBox txtChat;
        private Button btnsendmessage;
        private Label label2;
        private Label IDRoom;
        private Label label3;
        private LinkLabel linkleaveroom;
        private FlowLayoutPanel rcmvideopanel;
        private DataGridView dgvQueue;
        private DataGridViewTextBoxColumn ColumnNum;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnTag;
        private Label lbname;
    }
}