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
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle45 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle46 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle47 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle48 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle49 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle50 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle51 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle52 = new DataGridViewCellStyle();
            logout = new PictureBox();
            panelUnder = new Panel();
            iconRemove = new FontAwesome.Sharp.IconPictureBox();
            iconRefresh = new FontAwesome.Sharp.IconPictureBox();
            progressBar = new ProgressBar();
            panelInfo = new Panel();
            pbAvatar = new PictureBox();
            label1 = new Label();
            lbName = new Label();
            pbLogo = new PictureBox();
            panelData = new Panel();
            panelFunction = new Panel();
            btnSearch = new PictureBox();
            tbSearch = new RichTextBox();
            tcData = new TabControl();
            tabEmails = new TabPage();
            dgvEmails = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            From = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            Content = new DataGridViewTextBoxColumn();
            tabUsers = new TabPage();
            dgvUsers = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            UserID = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Online = new DataGridViewTextBoxColumn();
            UploadedVideos = new DataGridViewTextBoxColumn();
            tabVideos = new TabPage();
            dgvVideos = new DataGridView();
            Num = new DataGridViewTextBoxColumn();
            VideoID = new DataGridViewTextBoxColumn();
            UploadedUser = new DataGridViewTextBoxColumn();
            UploadedDate = new DataGridViewTextBoxColumn();
            Tiltle = new DataGridViewTextBoxColumn();
            Rating = new DataGridViewTextBoxColumn();
            tabRooms = new TabPage();
            dgvRooms = new DataGridView();
            NumRoom = new DataGridViewTextBoxColumn();
            RoomID = new DataGridViewTextBoxColumn();
            Host = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            NumOfParticipants = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            panelUnder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconRemove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconRefresh).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // logout
            // 
            logout.BackColor = Color.PowderBlue;
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(1065, 5);
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
            panelUnder.Controls.Add(iconRemove);
            panelUnder.Controls.Add(iconRefresh);
            panelUnder.Controls.Add(progressBar);
            panelUnder.Controls.Add(logout);
            panelUnder.Dock = DockStyle.Bottom;
            panelUnder.Location = new Point(0, 687);
            panelUnder.Margin = new Padding(2);
            panelUnder.Name = "panelUnder";
            panelUnder.Size = new Size(1101, 32);
            panelUnder.TabIndex = 4;
            // 
            // iconRemove
            // 
            iconRemove.BackColor = Color.PowderBlue;
            iconRemove.ForeColor = Color.DarkRed;
            iconRemove.IconChar = FontAwesome.Sharp.IconChar.X;
            iconRemove.IconColor = Color.DarkRed;
            iconRemove.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconRemove.IconSize = 24;
            iconRemove.Location = new Point(1036, 5);
            iconRemove.Name = "iconRemove";
            iconRemove.Size = new Size(24, 24);
            iconRemove.TabIndex = 7;
            iconRemove.TabStop = false;
            // 
            // iconRefresh
            // 
            iconRefresh.BackColor = Color.PowderBlue;
            iconRefresh.ForeColor = SystemColors.ActiveCaptionText;
            iconRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            iconRefresh.IconColor = SystemColors.ActiveCaptionText;
            iconRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconRefresh.IconSize = 24;
            iconRefresh.Location = new Point(1006, 6);
            iconRefresh.Name = "iconRefresh";
            iconRefresh.Size = new Size(24, 24);
            iconRefresh.TabIndex = 6;
            iconRefresh.TabStop = false;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 7);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(965, 20);
            progressBar.TabIndex = 4;
            progressBar.Visible = false;
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
            pbAvatar.BackColor = Color.CadetBlue;
            pbAvatar.BackgroundImageLayout = ImageLayout.Stretch;
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
            lbName.Cursor = Cursors.Hand;
            lbName.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbName.ForeColor = Color.White;
            lbName.Location = new Point(944, 32);
            lbName.Name = "lbName";
            lbName.RightToLeft = RightToLeft.No;
            lbName.Size = new Size(64, 23);
            lbName.TabIndex = 2;
            lbName.Text = "Name";
            lbName.Click += lbName_Click;
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
            panelFunction.Controls.Add(tbSearch);
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
            btnSearch.Location = new Point(647, 13);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(35, 36);
            btnSearch.TabIndex = 31;
            btnSearch.TabStop = false;
            // 
            // tbSearch
            // 
            tbSearch.BackColor = Color.White;
            tbSearch.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearch.ForeColor = Color.CadetBlue;
            tbSearch.Location = new Point(336, 14);
            tbSearch.Margin = new Padding(2);
            tbSearch.Multiline = false;
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(305, 35);
            tbSearch.TabIndex = 3;
            tbSearch.Text = "";
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
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = SystemColors.Window;
            dataGridViewCellStyle27.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle27.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
            dgvEmails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            dgvEmails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmails.Columns.AddRange(new DataGridViewColumn[] { Date, From, Subject, Content });
            dgvEmails.Dock = DockStyle.Fill;
            dgvEmails.GridColor = Color.LightBlue;
            dgvEmails.Location = new Point(0, 0);
            dgvEmails.Name = "dgvEmails";
            dgvEmails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmails.RowHeadersVisible = false;
            dgvEmails.RowHeadersWidth = 51;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmails.RowsDefaultCellStyle = dataGridViewCellStyle32;
            dgvEmails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmails.Size = new Size(1093, 540);
            dgvEmails.TabIndex = 0;
            // 
            // Date
            // 
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = Color.White;
            dataGridViewCellStyle28.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle28.ForeColor = Color.MidnightBlue;
            Date.DefaultCellStyle = dataGridViewCellStyle28;
            Date.HeaderText = "Received Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Resizable = DataGridViewTriState.False;
            Date.Width = 170;
            // 
            // From
            // 
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = Color.White;
            dataGridViewCellStyle29.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle29.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle29.NullValue = null;
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            From.DefaultCellStyle = dataGridViewCellStyle29;
            From.HeaderText = "From";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.ReadOnly = true;
            From.Resizable = DataGridViewTriState.False;
            From.Width = 260;
            // 
            // Subject
            // 
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle30.ForeColor = Color.MidnightBlue;
            Subject.DefaultCellStyle = dataGridViewCellStyle30;
            Subject.HeaderText = "Subject";
            Subject.MinimumWidth = 6;
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            Subject.Resizable = DataGridViewTriState.False;
            Subject.Width = 220;
            // 
            // Content
            // 
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle31.ForeColor = Color.MidnightBlue;
            Content.DefaultCellStyle = dataGridViewCellStyle31;
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
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = SystemColors.Control;
            dataGridViewCellStyle33.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle33.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
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
            // No
            // 
            dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle34.ForeColor = Color.MidnightBlue;
            No.DefaultCellStyle = dataGridViewCellStyle34;
            No.HeaderText = "No.";
            No.MinimumWidth = 6;
            No.Name = "No";
            No.Resizable = DataGridViewTriState.False;
            No.Width = 48;
            // 
            // UserID
            // 
            dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle35.ForeColor = Color.MidnightBlue;
            UserID.DefaultCellStyle = dataGridViewCellStyle35;
            UserID.HeaderText = "UserID";
            UserID.MinimumWidth = 6;
            UserID.Name = "UserID";
            UserID.Resizable = DataGridViewTriState.False;
            UserID.Width = 242;
            // 
            // Email
            // 
            dataGridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle36.ForeColor = Color.MidnightBlue;
            Email.DefaultCellStyle = dataGridViewCellStyle36;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Resizable = DataGridViewTriState.False;
            Email.Width = 260;
            // 
            // Username
            // 
            dataGridViewCellStyle37.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle37.ForeColor = Color.MidnightBlue;
            Username.DefaultCellStyle = dataGridViewCellStyle37;
            Username.HeaderText = "Username";
            Username.MinimumWidth = 6;
            Username.Name = "Username";
            Username.Resizable = DataGridViewTriState.False;
            Username.Width = 260;
            // 
            // Online
            // 
            dataGridViewCellStyle38.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle38.ForeColor = Color.MidnightBlue;
            Online.DefaultCellStyle = dataGridViewCellStyle38;
            Online.HeaderText = "Online";
            Online.MinimumWidth = 6;
            Online.Name = "Online";
            Online.Resizable = DataGridViewTriState.False;
            Online.Width = 90;
            // 
            // UploadedVideos
            // 
            dataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle39.ForeColor = Color.MidnightBlue;
            UploadedVideos.DefaultCellStyle = dataGridViewCellStyle39;
            UploadedVideos.HeaderText = "Uploaded Videos";
            UploadedVideos.MinimumWidth = 6;
            UploadedVideos.Name = "UploadedVideos";
            UploadedVideos.Resizable = DataGridViewTriState.False;
            UploadedVideos.Width = 193;
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
            dataGridViewCellStyle40.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = SystemColors.Control;
            dataGridViewCellStyle40.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle40.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = DataGridViewTriState.True;
            dgvVideos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle40;
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
            // Num
            // 
            dataGridViewCellStyle41.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle41.ForeColor = Color.MidnightBlue;
            Num.DefaultCellStyle = dataGridViewCellStyle41;
            Num.HeaderText = "No.";
            Num.MinimumWidth = 6;
            Num.Name = "Num";
            Num.Resizable = DataGridViewTriState.False;
            Num.Width = 48;
            // 
            // VideoID
            // 
            dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.BackColor = Color.White;
            dataGridViewCellStyle42.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle42.ForeColor = Color.MidnightBlue;
            VideoID.DefaultCellStyle = dataGridViewCellStyle42;
            VideoID.HeaderText = "VideoID";
            VideoID.MinimumWidth = 6;
            VideoID.Name = "VideoID";
            VideoID.Resizable = DataGridViewTriState.False;
            VideoID.Width = 152;
            // 
            // UploadedUser
            // 
            dataGridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle43.ForeColor = Color.MidnightBlue;
            UploadedUser.DefaultCellStyle = dataGridViewCellStyle43;
            UploadedUser.HeaderText = "Username";
            UploadedUser.MinimumWidth = 6;
            UploadedUser.Name = "UploadedUser";
            UploadedUser.Resizable = DataGridViewTriState.False;
            UploadedUser.Width = 152;
            // 
            // UploadedDate
            // 
            dataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle44.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle44.ForeColor = Color.MidnightBlue;
            UploadedDate.DefaultCellStyle = dataGridViewCellStyle44;
            UploadedDate.HeaderText = "Uploaded Date";
            UploadedDate.MinimumWidth = 6;
            UploadedDate.Name = "UploadedDate";
            UploadedDate.Resizable = DataGridViewTriState.False;
            UploadedDate.Width = 170;
            // 
            // Tiltle
            // 
            dataGridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle45.BackColor = Color.White;
            dataGridViewCellStyle45.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle45.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle45.NullValue = null;
            dataGridViewCellStyle45.WrapMode = DataGridViewTriState.True;
            Tiltle.DefaultCellStyle = dataGridViewCellStyle45;
            Tiltle.HeaderText = "Title";
            Tiltle.MinimumWidth = 6;
            Tiltle.Name = "Tiltle";
            Tiltle.Resizable = DataGridViewTriState.False;
            Tiltle.Width = 461;
            // 
            // Rating
            // 
            dataGridViewCellStyle46.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle46.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle46.ForeColor = Color.MidnightBlue;
            Rating.DefaultCellStyle = dataGridViewCellStyle46;
            Rating.HeaderText = "Rating";
            Rating.MinimumWidth = 6;
            Rating.Name = "Rating";
            Rating.Resizable = DataGridViewTriState.False;
            Rating.Width = 110;
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
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeColumns = false;
            dgvRooms.AllowUserToResizeRows = false;
            dgvRooms.BackgroundColor = Color.LightBlue;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle47.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle47.BackColor = SystemColors.Control;
            dataGridViewCellStyle47.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle47.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle47.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { NumRoom, RoomID, Host, StartTime, NumOfParticipants });
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
            // NumRoom
            // 
            dataGridViewCellStyle48.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle48.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle48.ForeColor = Color.MidnightBlue;
            NumRoom.DefaultCellStyle = dataGridViewCellStyle48;
            NumRoom.HeaderText = "No.";
            NumRoom.MinimumWidth = 6;
            NumRoom.Name = "NumRoom";
            NumRoom.Resizable = DataGridViewTriState.False;
            NumRoom.Width = 48;
            // 
            // RoomID
            // 
            dataGridViewCellStyle49.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle49.ForeColor = Color.MidnightBlue;
            RoomID.DefaultCellStyle = dataGridViewCellStyle49;
            RoomID.HeaderText = "RoomID";
            RoomID.MinimumWidth = 6;
            RoomID.Name = "RoomID";
            RoomID.Resizable = DataGridViewTriState.False;
            RoomID.Width = 250;
            // 
            // Host
            // 
            dataGridViewCellStyle50.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle50.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle50.ForeColor = Color.MidnightBlue;
            Host.DefaultCellStyle = dataGridViewCellStyle50;
            Host.HeaderText = "Host";
            Host.MinimumWidth = 6;
            Host.Name = "Host";
            Host.Resizable = DataGridViewTriState.False;
            Host.Width = 260;
            // 
            // StartTime
            // 
            dataGridViewCellStyle51.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle51.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle51.ForeColor = Color.MidnightBlue;
            StartTime.DefaultCellStyle = dataGridViewCellStyle51;
            StartTime.HeaderText = "Start Time";
            StartTime.MinimumWidth = 6;
            StartTime.Name = "StartTime";
            StartTime.Resizable = DataGridViewTriState.False;
            StartTime.Width = 292;
            // 
            // NumOfParticipants
            // 
            dataGridViewCellStyle52.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle52.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle52.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle52.NullValue = null;
            dataGridViewCellStyle52.WrapMode = DataGridViewTriState.True;
            NumOfParticipants.DefaultCellStyle = dataGridViewCellStyle52;
            NumOfParticipants.HeaderText = "Num of Participants";
            NumOfParticipants.MinimumWidth = 6;
            NumOfParticipants.Name = "NumOfParticipants";
            NumOfParticipants.Resizable = DataGridViewTriState.False;
            NumOfParticipants.Width = 243;
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
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            panelUnder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconRemove).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconRefresh).EndInit();
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
        private ProgressBar progressBar;
        private RichTextBox tbSearch;
        private PictureBox btnSearch;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn Content;
        private TabPage tabRooms;
        private FontAwesome.Sharp.IconPictureBox iconRemove;
        private FontAwesome.Sharp.IconPictureBox iconRefresh;
        private DataGridView dgvRooms;
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
        private DataGridViewTextBoxColumn NumRoom;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn Host;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn NumOfParticipants;
    }
}