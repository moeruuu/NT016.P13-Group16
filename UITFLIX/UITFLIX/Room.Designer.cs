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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            iconleaveroom = new PictureBox();
            lbname = new Label();
            IDRoom = new Label();
            label3 = new Label();
            logo = new PictureBox();
            namefilm = new Label();
            label1 = new Label();
            txtChat = new TextBox();
            label2 = new Label();
            rcmvideopanel = new FlowLayoutPanel();
            dgvQueue = new DataGridView();
            ColumnNum = new DataGridViewTextBoxColumn();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnTag = new DataGridViewTextBoxColumn();
            listchatgroup = new RichTextBox();
            iconSend = new FontAwesome.Sharp.IconPictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconleaveroom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconSend).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Controls.Add(iconleaveroom);
            panel1.Controls.Add(lbname);
            panel1.Controls.Add(IDRoom);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(logo);
            panel1.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(-1, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1511, 53);
            panel1.TabIndex = 0;
            // 
            // iconleaveroom
            // 
            iconleaveroom.BackColor = Color.PowderBlue;
            iconleaveroom.Cursor = Cursors.Hand;
            iconleaveroom.Image = (Image)resources.GetObject("iconleaveroom.Image");
            iconleaveroom.Location = new Point(1458, 10);
            iconleaveroom.Margin = new Padding(2);
            iconleaveroom.Name = "iconleaveroom";
            iconleaveroom.Size = new Size(35, 35);
            iconleaveroom.SizeMode = PictureBoxSizeMode.StretchImage;
            iconleaveroom.TabIndex = 7;
            iconleaveroom.TabStop = false;
            iconleaveroom.Click += iconleaveroom_Click;
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
            // namefilm
            // 
            namefilm.AutoSize = true;
            namefilm.BackColor = Color.Transparent;
            namefilm.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namefilm.ForeColor = Color.White;
            namefilm.Location = new Point(22, 644);
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
            label1.Location = new Point(20, 707);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(228, 20);
            label1.TabIndex = 3;
            label1.Text = "New videos you should watch:";
            // 
            // txtChat
            // 
            txtChat.AllowDrop = true;
            txtChat.Font = new Font("Cambria", 10F);
            txtChat.ForeColor = Color.MidnightBlue;
            txtChat.Location = new Point(1102, 614);
            txtChat.Margin = new Padding(2);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(357, 27);
            txtChat.TabIndex = 7;
            txtChat.KeyDown += txtChat_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1112, 707);
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
            dgvQueue.BackgroundColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQueue.Columns.AddRange(new DataGridViewColumn[] { ColumnNum, ColumnTitle, ColumnTag });
            dgvQueue.GridColor = Color.MidnightBlue;
            dgvQueue.Location = new Point(1102, 731);
            dgvQueue.Margin = new Padding(2);
            dgvQueue.MultiSelect = false;
            dgvQueue.Name = "dgvQueue";
            dgvQueue.ReadOnly = true;
            dgvQueue.RowHeadersVisible = false;
            dgvQueue.RowHeadersWidth = 62;
            dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQueue.Size = new Size(382, 248);
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
            ColumnTitle.Width = 205;
            // 
            // ColumnTag
            // 
            ColumnTag.HeaderText = "Tag";
            ColumnTag.MinimumWidth = 8;
            ColumnTag.Name = "ColumnTag";
            ColumnTag.ReadOnly = true;
            ColumnTag.Width = 94;
            // 
            // listchatgroup
            // 
            listchatgroup.BackColor = Color.MintCream;
            listchatgroup.BorderStyle = BorderStyle.FixedSingle;
            listchatgroup.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listchatgroup.ForeColor = Color.MidnightBlue;
            listchatgroup.Location = new Point(1101, 79);
            listchatgroup.Name = "listchatgroup";
            listchatgroup.ReadOnly = true;
            listchatgroup.ScrollBars = RichTextBoxScrollBars.Vertical;
            listchatgroup.Size = new Size(383, 529);
            listchatgroup.TabIndex = 13;
            listchatgroup.Text = "";
            // 
            // iconSend
            // 
            iconSend.BackColor = Color.Transparent;
            iconSend.Cursor = Cursors.Hand;
            iconSend.ForeColor = Color.DarkSlateGray;
            iconSend.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            iconSend.IconColor = Color.DarkSlateGray;
            iconSend.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconSend.IconSize = 27;
            iconSend.Location = new Point(1457, 614);
            iconSend.Name = "iconSend";
            iconSend.Size = new Size(27, 27);
            iconSend.TabIndex = 14;
            iconSend.TabStop = false;
            iconSend.Click += iconSend_Click;
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1510, 1000);
            ControlBox = false;
            Controls.Add(iconSend);
            Controls.Add(listchatgroup);
            Controls.Add(dgvQueue);
            Controls.Add(rcmvideopanel);
            Controls.Add(label2);
            Controls.Add(txtChat);
            Controls.Add(label1);
            Controls.Add(namefilm);
            Controls.Add(panel1);
            ForeColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Room";
            Padding = new Padding(10, 0, 0, 0);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateRoom";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconleaveroom).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconSend).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox logo;
        private Label namefilm;
        private Label label1;
        private TextBox txtChat;
        private Label label2;
        private Label IDRoom;
        private Label label3;
        private FlowLayoutPanel rcmvideopanel;
        private DataGridView dgvQueue;
        private Label lbname;
        private RichTextBox listchatgroup;
        private DataGridViewTextBoxColumn ColumnNum;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnTag;
        private FontAwesome.Sharp.IconPictureBox iconSend;
        private PictureBox iconleaveroom;
    }
}