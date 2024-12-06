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
            // listchatgroup
            // 
            listchatgroup.Font = new Font("Cambria", 10F);
            listchatgroup.ForeColor = Color.MidnightBlue;
            listchatgroup.FormattingEnabled = true;
            listchatgroup.ItemHeight = 23;
            listchatgroup.Location = new Point(1323, 79);
            listchatgroup.Name = "listchatgroup";
            listchatgroup.Size = new Size(435, 671);
            listchatgroup.TabIndex = 6;
            // 
            // txtChat
            // 
            txtChat.Font = new Font("Cambria", 10F);
            txtChat.ForeColor = Color.MidnightBlue;
            txtChat.Location = new Point(1323, 768);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(354, 31);
            txtChat.TabIndex = 7;
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
            btnsendmessage.Click += btnsendmessage_Click;
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
            // dgvQueue
            // 
            dgvQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQueue.Columns.AddRange(new DataGridViewColumn[] { ColumnNum, ColumnTitle, ColumnTag });
            dgvQueue.GridColor = Color.MidnightBlue;
            dgvQueue.Location = new Point(1323, 914);
            dgvQueue.Name = "dgvQueue";
            dgvQueue.RowHeadersWidth = 62;
            dgvQueue.Size = new Size(435, 254);
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
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1787, 1200);
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
    }
}