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
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
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
            DataGridViewCellStyle dataGridViewCellStyle53 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle54 = new DataGridViewCellStyle();
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
            Fullname = new DataGridViewTextBoxColumn();
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
            lbNoRoom = new Label();
            dgvRooms = new DataGridView();
            NumRoom = new DataGridViewTextBoxColumn();
            RoomID = new DataGridViewTextBoxColumn();
            Host = new DataGridViewTextBoxColumn();
            StartTime = new DataGridViewTextBoxColumn();
            NumOfParticipants = new DataGridViewTextBoxColumn();
            lbNoVideo = new Label();
            lbNoUser = new Label();
            lbNoEmail = new Label();
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
            logout.Cursor = Cursors.Hand;
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
            iconRemove.Cursor = Cursors.Hand;
            iconRemove.Enabled = false;
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
            iconRefresh.Cursor = Cursors.Hand;
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
            progressBar.Size = new Size(984, 20);
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
            panelData.ImeMode = ImeMode.Off;
            panelData.Location = new Point(-5, 79);
            panelData.Name = "panelData";
            panelData.Size = new Size(1111, 612);
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
            tcData.Dock = DockStyle.Fill;
            tcData.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tcData.ItemSize = new Size(100, 55);
            tcData.Location = new Point(0, 0);
            tcData.Name = "tcData";
            tcData.SelectedIndex = 0;
            tcData.Size = new Size(1111, 612);
            tcData.SizeMode = TabSizeMode.Fixed;
            tcData.TabIndex = 0;
            tcData.SelectedIndexChanged += tcData_SelectedIndexChanged;
            // 
            // tabEmails
            // 
            tabEmails.AccessibleDescription = "Emaillllllll";
            tabEmails.BackColor = Color.LightBlue;
            tabEmails.Controls.Add(lbNoEmail);
            tabEmails.Controls.Add(dgvEmails);
            tabEmails.Location = new Point(4, 59);
            tabEmails.Name = "tabEmails";
            tabEmails.Size = new Size(1103, 549);
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
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = Color.CadetBlue;
            dataGridViewCellStyle28.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle28.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle28.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle28.WrapMode = DataGridViewTriState.True;
            dgvEmails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            dgvEmails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmails.Columns.AddRange(new DataGridViewColumn[] { Date, From, Subject, Content });
            dgvEmails.Dock = DockStyle.Fill;
            dgvEmails.GridColor = Color.LightBlue;
            dgvEmails.Location = new Point(0, 0);
            dgvEmails.Name = "dgvEmails";
            dgvEmails.ReadOnly = true;
            dgvEmails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmails.RowHeadersVisible = false;
            dgvEmails.RowHeadersWidth = 51;
            dgvEmails.ScrollBars = ScrollBars.Vertical;
            dgvEmails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmails.Size = new Size(1103, 549);
            dgvEmails.TabIndex = 2;
            // 
            // Date
            // 
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle29.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle29.Format = "g";
            Date.DefaultCellStyle = dataGridViewCellStyle29;
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Resizable = DataGridViewTriState.False;
            Date.Width = 170;
            // 
            // From
            // 
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle30.ForeColor = Color.MidnightBlue;
            From.DefaultCellStyle = dataGridViewCellStyle30;
            From.HeaderText = "From";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.ReadOnly = true;
            From.Resizable = DataGridViewTriState.False;
            From.Width = 260;
            // 
            // Subject
            // 
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle31.ForeColor = Color.MidnightBlue;
            Subject.DefaultCellStyle = dataGridViewCellStyle31;
            Subject.HeaderText = "Subject";
            Subject.MinimumWidth = 6;
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            Subject.Resizable = DataGridViewTriState.False;
            Subject.Width = 275;
            // 
            // Content
            // 
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle32.ForeColor = Color.MidnightBlue;
            Content.DefaultCellStyle = dataGridViewCellStyle32;
            Content.HeaderText = "Content";
            Content.MinimumWidth = 6;
            Content.Name = "Content";
            Content.ReadOnly = true;
            Content.Resizable = DataGridViewTriState.False;
            Content.Width = 388;
            // 
            // tabUsers
            // 
            tabUsers.BackColor = Color.LightBlue;
            tabUsers.Controls.Add(lbNoUser);
            tabUsers.Controls.Add(dgvUsers);
            tabUsers.Location = new Point(4, 59);
            tabUsers.Name = "tabUsers";
            tabUsers.Size = new Size(1103, 549);
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
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { No, UserID, Email, Username, Fullname, Online, UploadedVideos });
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.GridColor = Color.LightBlue;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.ScrollBars = ScrollBars.Vertical;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1103, 549);
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
            No.ReadOnly = true;
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
            UserID.ReadOnly = true;
            UserID.Resizable = DataGridViewTriState.False;
            UserID.Width = 120;
            // 
            // Email
            // 
            dataGridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle36.ForeColor = Color.MidnightBlue;
            Email.DefaultCellStyle = dataGridViewCellStyle36;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Resizable = DataGridViewTriState.False;
            Email.Width = 251;
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
            Username.ReadOnly = true;
            Username.Resizable = DataGridViewTriState.False;
            Username.Width = 200;
            // 
            // Fullname
            // 
            dataGridViewCellStyle38.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle38.ForeColor = Color.MidnightBlue;
            Fullname.DefaultCellStyle = dataGridViewCellStyle38;
            Fullname.HeaderText = "Fullname";
            Fullname.MinimumWidth = 6;
            Fullname.Name = "Fullname";
            Fullname.ReadOnly = true;
            Fullname.Resizable = DataGridViewTriState.False;
            Fullname.Width = 200;
            // 
            // Online
            // 
            dataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle39.ForeColor = Color.MidnightBlue;
            Online.DefaultCellStyle = dataGridViewCellStyle39;
            Online.HeaderText = "Online";
            Online.MinimumWidth = 6;
            Online.Name = "Online";
            Online.ReadOnly = true;
            Online.Resizable = DataGridViewTriState.False;
            Online.Width = 90;
            // 
            // UploadedVideos
            // 
            dataGridViewCellStyle40.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle40.ForeColor = Color.MidnightBlue;
            UploadedVideos.DefaultCellStyle = dataGridViewCellStyle40;
            UploadedVideos.HeaderText = "Uploaded Videos";
            UploadedVideos.MinimumWidth = 6;
            UploadedVideos.Name = "UploadedVideos";
            UploadedVideos.ReadOnly = true;
            UploadedVideos.Resizable = DataGridViewTriState.False;
            UploadedVideos.Width = 184;
            // 
            // tabVideos
            // 
            tabVideos.BackColor = Color.LightBlue;
            tabVideos.Controls.Add(lbNoVideo);
            tabVideos.Controls.Add(dgvVideos);
            tabVideos.Location = new Point(4, 59);
            tabVideos.Name = "tabVideos";
            tabVideos.Size = new Size(1103, 549);
            tabVideos.TabIndex = 2;
            tabVideos.Text = "Videos";
            // 
            // dgvVideos
            // 
            dgvVideos.AllowUserToAddRows = false;
            dgvVideos.AllowUserToDeleteRows = false;
            dgvVideos.AllowUserToResizeColumns = false;
            dgvVideos.AllowUserToResizeRows = false;
            dataGridViewCellStyle41.BackColor = Color.LightBlue;
            dgvVideos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            dgvVideos.BackgroundColor = Color.LightBlue;
            dgvVideos.BorderStyle = BorderStyle.None;
            dgvVideos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle42.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle42.BackColor = SystemColors.Control;
            dataGridViewCellStyle42.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle42.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle42.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = DataGridViewTriState.True;
            dgvVideos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle42;
            dgvVideos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideos.Columns.AddRange(new DataGridViewColumn[] { Num, VideoID, UploadedUser, UploadedDate, Tiltle, Rating });
            dgvVideos.Dock = DockStyle.Fill;
            dgvVideos.GridColor = Color.LightBlue;
            dgvVideos.Location = new Point(0, 0);
            dgvVideos.Name = "dgvVideos";
            dgvVideos.ReadOnly = true;
            dgvVideos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVideos.RowHeadersVisible = false;
            dgvVideos.RowHeadersWidth = 51;
            dgvVideos.ScrollBars = ScrollBars.Vertical;
            dgvVideos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVideos.Size = new Size(1103, 549);
            dgvVideos.TabIndex = 2;
            // 
            // Num
            // 
            dataGridViewCellStyle43.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.BackColor = Color.LightBlue;
            dataGridViewCellStyle43.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle43.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle43.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle43.SelectionForeColor = Color.White;
            Num.DefaultCellStyle = dataGridViewCellStyle43;
            Num.HeaderText = "No.";
            Num.MinimumWidth = 6;
            Num.Name = "Num";
            Num.ReadOnly = true;
            Num.Resizable = DataGridViewTriState.False;
            Num.Width = 48;
            // 
            // VideoID
            // 
            dataGridViewCellStyle44.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle44.BackColor = Color.LightBlue;
            dataGridViewCellStyle44.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle44.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle44.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle44.SelectionForeColor = Color.White;
            VideoID.DefaultCellStyle = dataGridViewCellStyle44;
            VideoID.HeaderText = "VideoID";
            VideoID.MinimumWidth = 6;
            VideoID.Name = "VideoID";
            VideoID.ReadOnly = true;
            VideoID.Resizable = DataGridViewTriState.False;
            VideoID.Width = 152;
            // 
            // UploadedUser
            // 
            dataGridViewCellStyle45.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle45.BackColor = Color.LightBlue;
            dataGridViewCellStyle45.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle45.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle45.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle45.SelectionForeColor = Color.White;
            UploadedUser.DefaultCellStyle = dataGridViewCellStyle45;
            UploadedUser.HeaderText = "Uploader";
            UploadedUser.MinimumWidth = 6;
            UploadedUser.Name = "UploadedUser";
            UploadedUser.ReadOnly = true;
            UploadedUser.Resizable = DataGridViewTriState.False;
            UploadedUser.Width = 152;
            // 
            // UploadedDate
            // 
            dataGridViewCellStyle46.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = Color.LightBlue;
            dataGridViewCellStyle46.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle46.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle46.Format = "g";
            dataGridViewCellStyle46.NullValue = null;
            dataGridViewCellStyle46.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle46.SelectionForeColor = Color.White;
            UploadedDate.DefaultCellStyle = dataGridViewCellStyle46;
            UploadedDate.HeaderText = "Uploaded Date";
            UploadedDate.MinimumWidth = 6;
            UploadedDate.Name = "UploadedDate";
            UploadedDate.ReadOnly = true;
            UploadedDate.Resizable = DataGridViewTriState.False;
            UploadedDate.Width = 170;
            // 
            // Tiltle
            // 
            dataGridViewCellStyle47.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = Color.LightBlue;
            dataGridViewCellStyle47.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle47.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle47.NullValue = null;
            dataGridViewCellStyle47.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle47.SelectionForeColor = Color.White;
            dataGridViewCellStyle47.WrapMode = DataGridViewTriState.False;
            Tiltle.DefaultCellStyle = dataGridViewCellStyle47;
            Tiltle.HeaderText = "Title";
            Tiltle.MinimumWidth = 6;
            Tiltle.Name = "Tiltle";
            Tiltle.ReadOnly = true;
            Tiltle.Resizable = DataGridViewTriState.False;
            Tiltle.Width = 461;
            // 
            // Rating
            // 
            dataGridViewCellStyle48.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle48.BackColor = Color.LightBlue;
            dataGridViewCellStyle48.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle48.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle48.NullValue = null;
            dataGridViewCellStyle48.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle48.SelectionForeColor = Color.White;
            Rating.DefaultCellStyle = dataGridViewCellStyle48;
            Rating.HeaderText = "Rating";
            Rating.MinimumWidth = 6;
            Rating.Name = "Rating";
            Rating.ReadOnly = true;
            Rating.Resizable = DataGridViewTriState.False;
            Rating.Width = 110;
            // 
            // tabRooms
            // 
            tabRooms.BackColor = Color.LightBlue;
            tabRooms.Controls.Add(lbNoRoom);
            tabRooms.Controls.Add(dgvRooms);
            tabRooms.Location = new Point(4, 59);
            tabRooms.Name = "tabRooms";
            tabRooms.Size = new Size(1103, 549);
            tabRooms.TabIndex = 3;
            tabRooms.Text = "Rooms";
            // 
            // lbNoRoom
            // 
            lbNoRoom.AutoSize = true;
            lbNoRoom.Font = new Font("Cambria", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNoRoom.ForeColor = Color.DarkSlateGray;
            lbNoRoom.Location = new Point(402, 279);
            lbNoRoom.Name = "lbNoRoom";
            lbNoRoom.Size = new Size(307, 33);
            lbNoRoom.TabIndex = 4;
            lbNoRoom.Text = "404 NO ROOM FOUND :((";
            lbNoRoom.Visible = false;
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
            dataGridViewCellStyle49.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = SystemColors.Control;
            dataGridViewCellStyle49.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle49.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
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
            dgvRooms.Size = new Size(1103, 549);
            dgvRooms.TabIndex = 3;
            // 
            // NumRoom
            // 
            dataGridViewCellStyle50.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle50.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle50.ForeColor = Color.MidnightBlue;
            NumRoom.DefaultCellStyle = dataGridViewCellStyle50;
            NumRoom.HeaderText = "No.";
            NumRoom.MinimumWidth = 6;
            NumRoom.Name = "NumRoom";
            NumRoom.Resizable = DataGridViewTriState.False;
            NumRoom.Width = 48;
            // 
            // RoomID
            // 
            dataGridViewCellStyle51.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle51.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle51.ForeColor = Color.MidnightBlue;
            RoomID.DefaultCellStyle = dataGridViewCellStyle51;
            RoomID.HeaderText = "RoomID";
            RoomID.MinimumWidth = 6;
            RoomID.Name = "RoomID";
            RoomID.Resizable = DataGridViewTriState.False;
            RoomID.Width = 250;
            // 
            // Host
            // 
            dataGridViewCellStyle52.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle52.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle52.ForeColor = Color.MidnightBlue;
            Host.DefaultCellStyle = dataGridViewCellStyle52;
            Host.HeaderText = "Host";
            Host.MinimumWidth = 6;
            Host.Name = "Host";
            Host.Resizable = DataGridViewTriState.False;
            Host.Width = 260;
            // 
            // StartTime
            // 
            dataGridViewCellStyle53.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle53.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle53.Format = "T";
            dataGridViewCellStyle53.NullValue = null;
            StartTime.DefaultCellStyle = dataGridViewCellStyle53;
            StartTime.HeaderText = "Start Time";
            StartTime.MinimumWidth = 6;
            StartTime.Name = "StartTime";
            StartTime.Resizable = DataGridViewTriState.False;
            StartTime.Width = 292;
            // 
            // NumOfParticipants
            // 
            dataGridViewCellStyle54.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle54.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle54.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle54.NullValue = null;
            dataGridViewCellStyle54.WrapMode = DataGridViewTriState.True;
            NumOfParticipants.DefaultCellStyle = dataGridViewCellStyle54;
            NumOfParticipants.HeaderText = "Num of Participants";
            NumOfParticipants.MinimumWidth = 6;
            NumOfParticipants.Name = "NumOfParticipants";
            NumOfParticipants.Resizable = DataGridViewTriState.False;
            NumOfParticipants.Width = 243;
            // 
            // lbNoVideo
            // 
            lbNoVideo.AutoSize = true;
            lbNoVideo.Font = new Font("Cambria", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNoVideo.ForeColor = Color.DarkSlateGray;
            lbNoVideo.Location = new Point(398, 258);
            lbNoVideo.Name = "lbNoVideo";
            lbNoVideo.Size = new Size(310, 33);
            lbNoVideo.TabIndex = 5;
            lbNoVideo.Text = "404 NO VIDEO FOUND :((";
            lbNoVideo.Visible = false;
            // 
            // lbNoUser
            // 
            lbNoUser.AutoSize = true;
            lbNoUser.Font = new Font("Cambria", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNoUser.ForeColor = Color.DarkSlateGray;
            lbNoUser.Location = new Point(398, 258);
            lbNoUser.Name = "lbNoUser";
            lbNoUser.Size = new Size(298, 33);
            lbNoUser.TabIndex = 5;
            lbNoUser.Text = "404 NO USER FOUND :((";
            lbNoUser.Visible = false;
            // 
            // lbNoEmail
            // 
            lbNoEmail.AutoSize = true;
            lbNoEmail.Font = new Font("Cambria", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNoEmail.ForeColor = Color.DarkSlateGray;
            lbNoEmail.Location = new Point(398, 258);
            lbNoEmail.Name = "lbNoEmail";
            lbNoEmail.Size = new Size(312, 33);
            lbNoEmail.TabIndex = 5;
            lbNoEmail.Text = "404 NO EMAIL FOUND :((";
            lbNoEmail.Visible = false;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1101, 719);
            ControlBox = false;
            Controls.Add(panelUnder);
            Controls.Add(panelData);
            Controls.Add(panelInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            tabEmails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmails).EndInit();
            tabUsers.ResumeLayout(false);
            tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabVideos.ResumeLayout(false);
            tabVideos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideos).EndInit();
            tabRooms.ResumeLayout(false);
            tabRooms.PerformLayout();
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
        private PictureBox logout;
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
        private TabPage tabRooms;
        private TabControl tcData;
        private Panel panelFunction;
        private DataGridView dgvEmails;
        private DataGridView dgvUsers;
        private DataGridView dgvVideos;
        private DataGridView dgvRooms;
        private ProgressBar progressBar;
        private RichTextBox tbSearch;
        private PictureBox btnSearch;
        private FontAwesome.Sharp.IconPictureBox iconRemove;
        private FontAwesome.Sharp.IconPictureBox iconRefresh;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Fullname;
        private DataGridViewTextBoxColumn Online;
        private DataGridViewTextBoxColumn UploadedVideos;
        private DataGridViewTextBoxColumn Num;
        private DataGridViewTextBoxColumn VideoID;
        private DataGridViewTextBoxColumn UploadedUser;
        private DataGridViewTextBoxColumn UploadedDate;
        private DataGridViewTextBoxColumn Tiltle;
        private DataGridViewTextBoxColumn Rating;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn Content;
        private DataGridViewTextBoxColumn NumRoom;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn Host;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn NumOfParticipants;
        private Label lbNoRoom;
        private Label lbNoEmail;
        private Label lbNoUser;
        private Label lbNoVideo;
    }
}