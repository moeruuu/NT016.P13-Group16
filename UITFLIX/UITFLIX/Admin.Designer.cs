namespace UITFLIX
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            logout = new PictureBox();
            panelUnder = new Panel();
            progressBar1 = new ProgressBar();
            panelInfo = new Panel();
            pbAvatar = new PictureBox();
            label1 = new Label();
            lbName = new Label();
            pbLogo = new PictureBox();
            panelData = new Panel();
            panelFunction = new Panel();
            btnSearch = new PictureBox();
            searchtb = new RichTextBox();
            tcData = new TabControl();
            tabEmails = new TabPage();
            dgvEmails = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            From = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            Content = new DataGridViewTextBoxColumn();
            tabUsers = new TabPage();
            dgvUsers = new DataGridView();
            tabVideos = new TabPage();
            dgvVideos = new DataGridView();
            tabRooms = new TabPage();
            iconload = new FontAwesome.Sharp.IconPictureBox();
            iconX = new FontAwesome.Sharp.IconPictureBox();
            dgvRooms = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            RoomID = new DataGridViewTextBoxColumn();
            Host = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            NumOfParticipants = new DataGridViewTextBoxColumn();
            No = new DataGridViewTextBoxColumn();
            UserID = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Online = new DataGridViewTextBoxColumn();
            UploadedVideos = new DataGridViewTextBoxColumn();
            Num = new DataGridViewTextBoxColumn();
            VideoID = new DataGridViewTextBoxColumn();
            UploadedUser = new DataGridViewTextBoxColumn();
            UploadedDate = new DataGridViewTextBoxColumn();
            Tiltle = new DataGridViewTextBoxColumn();
            Rating = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            panelUnder.SuspendLayout();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            panelData.SuspendLayout();
            panelFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            tcData.SuspendLayout();
            tabEmails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmails).BeginInit();
            tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabVideos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideos).BeginInit();
            tabRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // logout
            // 
            logout.BackColor = Color.PowderBlue;
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(1066, 5);
            logout.Margin = new Padding(2);
            logout.Name = "logout";
            logout.Size = new Size(24, 24);
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.TabIndex = 3;
            logout.TabStop = false;
            logout.Click += logout_Click;
            // 
            // panelUnder
            // 
            panelUnder.BackColor = Color.PowderBlue;
            panelUnder.Controls.Add(iconX);
            panelUnder.Controls.Add(iconload);
            panelUnder.Controls.Add(progressBar1);
            panelUnder.Controls.Add(logout);
            panelUnder.Dock = DockStyle.Bottom;
            panelUnder.Location = new Point(0, 687);
            panelUnder.Margin = new Padding(2);
            panelUnder.Name = "panelUnder";
            panelUnder.Size = new Size(1101, 32);
            panelUnder.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(5, 7);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(972, 20);
            progressBar1.TabIndex = 4;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.CadetBlue;
            panelInfo.Controls.Add(pbAvatar);
            panelInfo.Controls.Add(label1);
            panelInfo.Controls.Add(lbName);
            panelInfo.Controls.Add(pbLogo);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(1101, 81);
            panelInfo.TabIndex = 5;
            // 
            // pbAvatar
            // 
            pbAvatar.Location = new Point(1025, 9);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(64, 64);
            pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAvatar.TabIndex = 4;
            pbAvatar.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightBlue;
            label1.Location = new Point(82, 18);
            label1.Name = "label1";
            label1.Size = new Size(144, 50);
            label1.TabIndex = 3;
            label1.Text = "UITflix";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbName.ForeColor = Color.White;
            lbName.Location = new Point(944, 32);
            lbName.Name = "lbName";
            lbName.RightToLeft = RightToLeft.No;
            lbName.Size = new Size(64, 23);
            lbName.TabIndex = 2;
            lbName.Text = "Name";
            lbName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pbLogo
            // 
            pbLogo.BackgroundImageLayout = ImageLayout.Center;
            pbLogo.Image = Properties.Resources.UITFLIX;
            pbLogo.Location = new Point(12, 9);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(64, 64);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // panelData
            // 
            panelData.BackColor = Color.PowderBlue;
            panelData.Controls.Add(panelFunction);
            panelData.Controls.Add(tcData);
            panelData.Dock = DockStyle.Fill;
            panelData.ImeMode = ImeMode.Off;
            panelData.Location = new Point(0, 81);
            panelData.Name = "panelData";
            panelData.Size = new Size(1101, 606);
            panelData.TabIndex = 7;
            // 
            // panelFunction
            // 
            panelFunction.BackColor = Color.PowderBlue;
            panelFunction.Controls.Add(btnSearch);
            panelFunction.Controls.Add(searchtb);
            panelFunction.Location = new Point(406, 0);
            panelFunction.Name = "panelFunction";
            panelFunction.Size = new Size(695, 56);
            panelFunction.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.search;
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Location = new Point(654, 13);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(35, 36);
            btnSearch.TabIndex = 31;
            btnSearch.TabStop = false;
            // 
            // searchtb
            // 
            searchtb.BackColor = Color.White;
            searchtb.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtb.ForeColor = Color.CadetBlue;
            searchtb.Location = new Point(338, 14);
            searchtb.Margin = new Padding(2);
            searchtb.Multiline = false;
            searchtb.Name = "searchtb";
            searchtb.Size = new Size(305, 35);
            searchtb.TabIndex = 3;
            searchtb.Text = "";
            // 
            // tcData
            // 
            tcData.Controls.Add(tabEmails);
            tcData.Controls.Add(tabUsers);
            tcData.Controls.Add(tabVideos);
            tcData.Controls.Add(tabRooms);
            tcData.Dock = DockStyle.Bottom;
            tcData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tcData.ItemSize = new Size(100, 55);
            tcData.Location = new Point(0, 3);
            tcData.Name = "tcData";
            tcData.SelectedIndex = 0;
            tcData.Size = new Size(1101, 603);
            tcData.SizeMode = TabSizeMode.Fixed;
            tcData.TabIndex = 0;
            // 
            // tabEmails
            // 
            tabEmails.AccessibleDescription = "Emaillllllll";
            tabEmails.BackColor = Color.LightBlue;
            tabEmails.Controls.Add(dgvEmails);
            tabEmails.Location = new Point(4, 59);
            tabEmails.Name = "tabEmails";
            tabEmails.Size = new Size(1093, 540);
            tabEmails.TabIndex = 0;
            tabEmails.Text = "Emails";
            // 
            // dgvEmails
            // 
            dgvEmails.AllowUserToAddRows = false;
            dgvEmails.AllowUserToDeleteRows = false;
            dgvEmails.AllowUserToResizeColumns = false;
            dgvEmails.AllowUserToResizeRows = false;
            dgvEmails.BackgroundColor = Color.LightBlue;
            dgvEmails.BorderStyle = BorderStyle.None;
            dgvEmails.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmails.Columns.AddRange(new DataGridViewColumn[] { Date, From, Subject, Content });
            dgvEmails.Dock = DockStyle.Fill;
            dgvEmails.GridColor = Color.LightBlue;
            dgvEmails.Location = new Point(0, 0);
            dgvEmails.Name = "dgvEmails";
            dgvEmails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmails.RowHeadersVisible = false;
            dgvEmails.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmails.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvEmails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmails.Size = new Size(1093, 540);
            dgvEmails.TabIndex = 0;
            // 
            // Date
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.MidnightBlue;
            Date.DefaultCellStyle = dataGridViewCellStyle2;
            Date.HeaderText = "Received Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Resizable = DataGridViewTriState.False;
            Date.Width = 170;
            // 
            // From
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            From.DefaultCellStyle = dataGridViewCellStyle3;
            From.HeaderText = "From";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.ReadOnly = true;
            From.Resizable = DataGridViewTriState.False;
            From.Width = 260;
            // 
            // Subject
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.MidnightBlue;
            Subject.DefaultCellStyle = dataGridViewCellStyle4;
            Subject.HeaderText = "Subject";
            Subject.MinimumWidth = 6;
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            Subject.Resizable = DataGridViewTriState.False;
            Subject.Width = 220;
            // 
            // Content
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.MidnightBlue;
            Content.DefaultCellStyle = dataGridViewCellStyle5;
            Content.HeaderText = "Content";
            Content.MinimumWidth = 6;
            Content.Name = "Content";
            Content.ReadOnly = true;
            Content.Resizable = DataGridViewTriState.False;
            Content.Width = 443;
            // 
            // tabUsers
            // 
            tabUsers.BackColor = Color.LightBlue;
            tabUsers.Controls.Add(dgvUsers);
            tabUsers.Location = new Point(4, 59);
            tabUsers.Name = "tabUsers";
            tabUsers.Size = new Size(1093, 540);
            tabUsers.TabIndex = 1;
            tabUsers.Text = "Users";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.BackgroundColor = Color.LightBlue;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { No, UserID, Email, Username, Online, UploadedVideos });
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.GridColor = Color.LightBlue;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1093, 540);
            dgvUsers.TabIndex = 1;
            // 
            // tabVideos
            // 
            tabVideos.BackColor = Color.LightBlue;
            tabVideos.Controls.Add(dgvVideos);
            tabVideos.Location = new Point(4, 59);
            tabVideos.Name = "tabVideos";
            tabVideos.Size = new Size(1093, 540);
            tabVideos.TabIndex = 2;
            tabVideos.Text = "Videos";
            // 
            // dgvVideos
            // 
            dgvVideos.AllowUserToAddRows = false;
            dgvVideos.AllowUserToDeleteRows = false;
            dgvVideos.AllowUserToResizeColumns = false;
            dgvVideos.AllowUserToResizeRows = false;
            dgvVideos.BackgroundColor = Color.LightBlue;
            dgvVideos.BorderStyle = BorderStyle.None;
            dgvVideos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvVideos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvVideos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideos.Columns.AddRange(new DataGridViewColumn[] { Num, VideoID, UploadedUser, UploadedDate, Tiltle, Rating });
            dgvVideos.Dock = DockStyle.Fill;
            dgvVideos.GridColor = Color.LightBlue;
            dgvVideos.Location = new Point(0, 0);
            dgvVideos.Name = "dgvVideos";
            dgvVideos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVideos.RowHeadersVisible = false;
            dgvVideos.RowHeadersWidth = 51;
            dgvVideos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVideos.Size = new Size(1093, 540);
            dgvVideos.TabIndex = 2;
            // 
            // tabRooms
            // 
            tabRooms.BackColor = Color.LightBlue;
            tabRooms.Controls.Add(dgvRooms);
            tabRooms.Location = new Point(4, 59);
            tabRooms.Name = "tabRooms";
            tabRooms.Size = new Size(1093, 540);
            tabRooms.TabIndex = 3;
            tabRooms.Text = "Rooms";
            // 
            // iconload
            // 
            iconload.BackColor = Color.PowderBlue;
            iconload.ForeColor = SystemColors.ActiveCaptionText;
            iconload.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            iconload.IconColor = SystemColors.ActiveCaptionText;
            iconload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconload.IconSize = 24;
            iconload.Location = new Point(1007, 6);
            iconload.Name = "iconload";
            iconload.Size = new Size(24, 24);
            iconload.TabIndex = 6;
            iconload.TabStop = false;
            // 
            // iconX
            // 
            iconX.BackColor = Color.PowderBlue;
            iconX.ForeColor = Color.DarkRed;
            iconX.IconChar = FontAwesome.Sharp.IconChar.X;
            iconX.IconColor = Color.DarkRed;
            iconX.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconX.IconSize = 24;
            iconX.Location = new Point(1037, 5);
            iconX.Name = "iconX";
            iconX.Size = new Size(24, 24);
            iconX.TabIndex = 7;
            iconX.TabStop = false;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeColumns = false;
            dgvRooms.AllowUserToResizeRows = false;
            dgvRooms.BackgroundColor = Color.LightBlue;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = SystemColors.Control;
            dataGridViewCellStyle21.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle21.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, RoomID, Host, StartTime, NumOfParticipants });
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.GridColor = Color.LightBlue;
            dgvRooms.Location = new Point(0, 0);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1093, 540);
            dgvRooms.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle22.ForeColor = Color.MidnightBlue;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewTextBoxColumn1.HeaderText = "No.";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            // 
            // RoomID
            // 
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = Color.White;
            dataGridViewCellStyle23.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle23.ForeColor = Color.MidnightBlue;
            RoomID.DefaultCellStyle = dataGridViewCellStyle23;
            RoomID.HeaderText = "RoomID";
            RoomID.MinimumWidth = 6;
            RoomID.Name = "RoomID";
            RoomID.Resizable = DataGridViewTriState.False;
            RoomID.Width = 250;
            // 
            // Host
            // 
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle24.ForeColor = Color.MidnightBlue;
            Host.DefaultCellStyle = dataGridViewCellStyle24;
            Host.HeaderText = "Host";
            Host.MinimumWidth = 6;
            Host.Name = "Host";
            Host.Resizable = DataGridViewTriState.False;
            Host.Width = 250;
            // 
            // StartTime
            // 
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle25.ForeColor = Color.MidnightBlue;
            StartTime.DefaultCellStyle = dataGridViewCellStyle25;
            StartTime.HeaderText = "Start Time";
            StartTime.MinimumWidth = 6;
            StartTime.Name = "StartTime";
            StartTime.Resizable = DataGridViewTriState.False;
            StartTime.Width = 250;
            // 
            // NumOfParticipants
            // 
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = Color.White;
            dataGridViewCellStyle26.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle26.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle26.NullValue = null;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.True;
            NumOfParticipants.DefaultCellStyle = dataGridViewCellStyle26;
            NumOfParticipants.HeaderText = "Num of Participants";
            NumOfParticipants.MinimumWidth = 6;
            NumOfParticipants.Name = "NumOfParticipants";
            NumOfParticipants.Resizable = DataGridViewTriState.False;
            NumOfParticipants.Width = 243;
            // 
            // No
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.MidnightBlue;
            No.DefaultCellStyle = dataGridViewCellStyle8;
            No.HeaderText = "No.";
            No.MinimumWidth = 6;
            No.Name = "No";
            No.Resizable = DataGridViewTriState.False;
            No.Width = 48;
            // 
            // UserID
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.MidnightBlue;
            UserID.DefaultCellStyle = dataGridViewCellStyle9;
            UserID.HeaderText = "UserID";
            UserID.MinimumWidth = 6;
            UserID.Name = "UserID";
            UserID.Resizable = DataGridViewTriState.False;
            UserID.Width = 242;
            // 
            // Email
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.MidnightBlue;
            Email.DefaultCellStyle = dataGridViewCellStyle10;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Resizable = DataGridViewTriState.False;
            Email.Width = 260;
            // 
            // Username
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.MidnightBlue;
            Username.DefaultCellStyle = dataGridViewCellStyle11;
            Username.HeaderText = "Username";
            Username.MinimumWidth = 6;
            Username.Name = "Username";
            Username.Resizable = DataGridViewTriState.False;
            Username.Width = 260;
            // 
            // Online
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.MidnightBlue;
            Online.DefaultCellStyle = dataGridViewCellStyle12;
            Online.HeaderText = "Online";
            Online.MinimumWidth = 6;
            Online.Name = "Online";
            Online.Resizable = DataGridViewTriState.False;
            Online.Width = 90;
            // 
            // UploadedVideos
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.MidnightBlue;
            UploadedVideos.DefaultCellStyle = dataGridViewCellStyle13;
            UploadedVideos.HeaderText = "Uploaded Videos";
            UploadedVideos.MinimumWidth = 6;
            UploadedVideos.Name = "UploadedVideos";
            UploadedVideos.Resizable = DataGridViewTriState.False;
            UploadedVideos.Width = 193;
            // 
            // Num
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.ForeColor = Color.MidnightBlue;
            Num.DefaultCellStyle = dataGridViewCellStyle15;
            Num.HeaderText = "No.";
            Num.MinimumWidth = 6;
            Num.Name = "Num";
            Num.Resizable = DataGridViewTriState.False;
            Num.Width = 48;
            // 
            // VideoID
            // 
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = Color.White;
            dataGridViewCellStyle16.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle16.ForeColor = Color.MidnightBlue;
            VideoID.DefaultCellStyle = dataGridViewCellStyle16;
            VideoID.HeaderText = "VideoID";
            VideoID.MinimumWidth = 6;
            VideoID.Name = "VideoID";
            VideoID.Resizable = DataGridViewTriState.False;
            VideoID.Width = 152;
            // 
            // UploadedUser
            // 
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle17.ForeColor = Color.MidnightBlue;
            UploadedUser.DefaultCellStyle = dataGridViewCellStyle17;
            UploadedUser.HeaderText = "Username";
            UploadedUser.MinimumWidth = 6;
            UploadedUser.Name = "UploadedUser";
            UploadedUser.Resizable = DataGridViewTriState.False;
            UploadedUser.Width = 152;
            // 
            // UploadedDate
            // 
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle18.ForeColor = Color.MidnightBlue;
            UploadedDate.DefaultCellStyle = dataGridViewCellStyle18;
            UploadedDate.HeaderText = "Uploaded Date";
            UploadedDate.MinimumWidth = 6;
            UploadedDate.Name = "UploadedDate";
            UploadedDate.Resizable = DataGridViewTriState.False;
            UploadedDate.Width = 170;
            // 
            // Tiltle
            // 
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = Color.White;
            dataGridViewCellStyle19.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle19.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle19.NullValue = null;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            Tiltle.DefaultCellStyle = dataGridViewCellStyle19;
            Tiltle.HeaderText = "Title";
            Tiltle.MinimumWidth = 6;
            Tiltle.Name = "Tiltle";
            Tiltle.Resizable = DataGridViewTriState.False;
            Tiltle.Width = 386;
            // 
            // Rating
            // 
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle20.ForeColor = Color.MidnightBlue;
            Rating.DefaultCellStyle = dataGridViewCellStyle20;
            Rating.HeaderText = "Rating";
            Rating.MinimumWidth = 6;
            Rating.Name = "Rating";
            Rating.Resizable = DataGridViewTriState.False;
            Rating.Width = 185;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1101, 719);
            ControlBox = false;
            Controls.Add(panelData);
            Controls.Add(panelInfo);
            Controls.Add(panelUnder);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            panelUnder.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            panelData.ResumeLayout(false);
            panelFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            tcData.ResumeLayout(false);
            tabEmails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmails).EndInit();
            tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabVideos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVideos).EndInit();
            tabRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconload).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconX).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl;
        private TabPage tabEmail;
        private TabPage tabUser;
        private TabPage tabVideo;
        private Button btnSend;
        private Button btnLogout;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn ColID;
        private DataGridViewTextBoxColumn ColFullname;
        private DataGridViewTextBoxColumn ColUsername;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColIsonline;
        private DataGridView dgvVideo;
        private DataGridViewTextBoxColumn CoIVideoID;
        private DataGridViewTextBoxColumn ColTag;
        private DataGridViewTextBoxColumn ColVideoName;
        private DataGridViewTextBoxColumn ColDate;
        private PictureBox logout;
        private DataGridView dgvEmail;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Panel panelUnder;
        private Panel panelInfo;
        private Panel panelData;
        private PictureBox pbLogo;
        private Label lbName;
        private Label label1;
        private PictureBox pbAvatar;
        private TabPage tabEmails;
        private TabPage tabUsers;
        private TabPage tabVideos;
        private TabControl tcData;
        private Panel panelFunction;
        private DataGridView dgvEmails;
       // private DataGridView dgvUsers;
        private DataGridView dgvVideos;
        private ProgressBar progressBar1;
        private RichTextBox searchtb;
        private PictureBox btnSearch;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn Content;
        private TabPage tabRooms;
        private FontAwesome.Sharp.IconPictureBox iconX;
        private FontAwesome.Sharp.IconPictureBox iconload;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn Host;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn NumOfParticipants;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Online;
        private DataGridViewTextBoxColumn UploadedVideos;
        private DataGridViewTextBoxColumn Num;
        private DataGridViewTextBoxColumn VideoID;
        private DataGridViewTextBoxColumn UploadedUser;
        private DataGridViewTextBoxColumn UploadedDate;
        private DataGridViewTextBoxColumn Tiltle;
        private DataGridViewTextBoxColumn Rating;
    }
}