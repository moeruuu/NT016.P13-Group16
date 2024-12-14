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
            DataGridViewCellStyle dataGridViewCellStyle55 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle56 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle57 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle58 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle59 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle60 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle61 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle62 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle63 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle64 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle65 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle66 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle67 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle68 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle69 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle70 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle71 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle72 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle73 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle74 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle75 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle76 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle77 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle78 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle79 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle80 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle81 = new DataGridViewCellStyle();
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
            lbNoEmail = new Label();
            dgvEmails = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            From = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            Content = new DataGridViewTextBoxColumn();
            tabUsers = new TabPage();
            lbNoUser = new Label();
            dgvUsers = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            UserID = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Fullname = new DataGridViewTextBoxColumn();
            Online = new DataGridViewTextBoxColumn();
            UploadedVideos = new DataGridViewTextBoxColumn();
            tabVideos = new TabPage();
            lbNoVideo = new Label();
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
            btnSearch.Click += btnSearch_Click;
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
            // dgvEmails
            // 
            dgvEmails.AllowUserToAddRows = false;
            dgvEmails.AllowUserToDeleteRows = false;
            dgvEmails.AllowUserToResizeColumns = false;
            dgvEmails.AllowUserToResizeRows = false;
            dgvEmails.BackgroundColor = Color.LightBlue;
            dgvEmails.BorderStyle = BorderStyle.None;
            dgvEmails.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle55.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.BackColor = Color.CadetBlue;
            dataGridViewCellStyle55.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle55.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle55.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle55.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle55.WrapMode = DataGridViewTriState.True;
            dgvEmails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
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
            dataGridViewCellStyle56.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle56.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle56.Format = "g";
            Date.DefaultCellStyle = dataGridViewCellStyle56;
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Resizable = DataGridViewTriState.False;
            Date.Width = 170;
            // 
            // From
            // 
            dataGridViewCellStyle57.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle57.ForeColor = Color.MidnightBlue;
            From.DefaultCellStyle = dataGridViewCellStyle57;
            From.HeaderText = "From";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.ReadOnly = true;
            From.Resizable = DataGridViewTriState.False;
            From.Width = 260;
            // 
            // Subject
            // 
            dataGridViewCellStyle58.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle58.ForeColor = Color.MidnightBlue;
            Subject.DefaultCellStyle = dataGridViewCellStyle58;
            Subject.HeaderText = "Subject";
            Subject.MinimumWidth = 6;
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            Subject.Resizable = DataGridViewTriState.False;
            Subject.Width = 275;
            // 
            // Content
            // 
            dataGridViewCellStyle59.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle59.ForeColor = Color.MidnightBlue;
            Content.DefaultCellStyle = dataGridViewCellStyle59;
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
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.BackgroundColor = Color.LightBlue;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle60.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle60.BackColor = SystemColors.Control;
            dataGridViewCellStyle60.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle60.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle60.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle60.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle60.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle60;
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
            dataGridViewCellStyle61.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle61.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle61.ForeColor = Color.MidnightBlue;
            No.DefaultCellStyle = dataGridViewCellStyle61;
            No.HeaderText = "No.";
            No.MinimumWidth = 6;
            No.Name = "No";
            No.ReadOnly = true;
            No.Resizable = DataGridViewTriState.False;
            No.Width = 48;
            // 
            // UserID
            // 
            dataGridViewCellStyle62.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle62.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle62.ForeColor = Color.MidnightBlue;
            UserID.DefaultCellStyle = dataGridViewCellStyle62;
            UserID.HeaderText = "UserID";
            UserID.MinimumWidth = 6;
            UserID.Name = "UserID";
            UserID.ReadOnly = true;
            UserID.Resizable = DataGridViewTriState.False;
            UserID.Width = 120;
            // 
            // Email
            // 
            dataGridViewCellStyle63.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle63.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle63.ForeColor = Color.MidnightBlue;
            Email.DefaultCellStyle = dataGridViewCellStyle63;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Resizable = DataGridViewTriState.False;
            Email.Width = 251;
            // 
            // Username
            // 
            dataGridViewCellStyle64.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle64.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle64.ForeColor = Color.MidnightBlue;
            Username.DefaultCellStyle = dataGridViewCellStyle64;
            Username.HeaderText = "Username";
            Username.MinimumWidth = 6;
            Username.Name = "Username";
            Username.ReadOnly = true;
            Username.Resizable = DataGridViewTriState.False;
            Username.Width = 200;
            // 
            // Fullname
            // 
            dataGridViewCellStyle65.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle65.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle65.ForeColor = Color.MidnightBlue;
            Fullname.DefaultCellStyle = dataGridViewCellStyle65;
            Fullname.HeaderText = "Fullname";
            Fullname.MinimumWidth = 6;
            Fullname.Name = "Fullname";
            Fullname.ReadOnly = true;
            Fullname.Resizable = DataGridViewTriState.False;
            Fullname.Width = 200;
            // 
            // Online
            // 
            dataGridViewCellStyle66.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle66.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle66.ForeColor = Color.MidnightBlue;
            Online.DefaultCellStyle = dataGridViewCellStyle66;
            Online.HeaderText = "Online";
            Online.MinimumWidth = 6;
            Online.Name = "Online";
            Online.ReadOnly = true;
            Online.Resizable = DataGridViewTriState.False;
            Online.Width = 90;
            // 
            // UploadedVideos
            // 
            dataGridViewCellStyle67.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle67.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle67.ForeColor = Color.MidnightBlue;
            UploadedVideos.DefaultCellStyle = dataGridViewCellStyle67;
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
            // dgvVideos
            // 
            dgvVideos.AllowUserToAddRows = false;
            dgvVideos.AllowUserToDeleteRows = false;
            dgvVideos.AllowUserToResizeColumns = false;
            dgvVideos.AllowUserToResizeRows = false;
            dataGridViewCellStyle68.BackColor = Color.LightBlue;
            dgvVideos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle68;
            dgvVideos.BackgroundColor = Color.LightBlue;
            dgvVideos.BorderStyle = BorderStyle.None;
            dgvVideos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle69.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle69.BackColor = SystemColors.Control;
            dataGridViewCellStyle69.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle69.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle69.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle69.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle69.WrapMode = DataGridViewTriState.True;
            dgvVideos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle69;
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
            dataGridViewCellStyle70.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle70.BackColor = Color.LightBlue;
            dataGridViewCellStyle70.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle70.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle70.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle70.SelectionForeColor = Color.White;
            Num.DefaultCellStyle = dataGridViewCellStyle70;
            Num.HeaderText = "No.";
            Num.MinimumWidth = 6;
            Num.Name = "Num";
            Num.ReadOnly = true;
            Num.Resizable = DataGridViewTriState.False;
            Num.Width = 48;
            // 
            // VideoID
            // 
            dataGridViewCellStyle71.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle71.BackColor = Color.LightBlue;
            dataGridViewCellStyle71.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle71.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle71.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle71.SelectionForeColor = Color.White;
            VideoID.DefaultCellStyle = dataGridViewCellStyle71;
            VideoID.HeaderText = "VideoID";
            VideoID.MinimumWidth = 6;
            VideoID.Name = "VideoID";
            VideoID.ReadOnly = true;
            VideoID.Resizable = DataGridViewTriState.False;
            VideoID.Width = 152;
            // 
            // UploadedUser
            // 
            dataGridViewCellStyle72.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle72.BackColor = Color.LightBlue;
            dataGridViewCellStyle72.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle72.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle72.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle72.SelectionForeColor = Color.White;
            UploadedUser.DefaultCellStyle = dataGridViewCellStyle72;
            UploadedUser.HeaderText = "Uploader";
            UploadedUser.MinimumWidth = 6;
            UploadedUser.Name = "UploadedUser";
            UploadedUser.ReadOnly = true;
            UploadedUser.Resizable = DataGridViewTriState.False;
            UploadedUser.Width = 152;
            // 
            // UploadedDate
            // 
            dataGridViewCellStyle73.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle73.BackColor = Color.LightBlue;
            dataGridViewCellStyle73.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle73.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle73.Format = "g";
            dataGridViewCellStyle73.NullValue = null;
            dataGridViewCellStyle73.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle73.SelectionForeColor = Color.White;
            UploadedDate.DefaultCellStyle = dataGridViewCellStyle73;
            UploadedDate.HeaderText = "Uploaded Date";
            UploadedDate.MinimumWidth = 6;
            UploadedDate.Name = "UploadedDate";
            UploadedDate.ReadOnly = true;
            UploadedDate.Resizable = DataGridViewTriState.False;
            UploadedDate.Width = 170;
            // 
            // Tiltle
            // 
            dataGridViewCellStyle74.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle74.BackColor = Color.LightBlue;
            dataGridViewCellStyle74.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle74.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle74.NullValue = null;
            dataGridViewCellStyle74.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle74.SelectionForeColor = Color.White;
            dataGridViewCellStyle74.WrapMode = DataGridViewTriState.False;
            Tiltle.DefaultCellStyle = dataGridViewCellStyle74;
            Tiltle.HeaderText = "Title";
            Tiltle.MinimumWidth = 6;
            Tiltle.Name = "Tiltle";
            Tiltle.ReadOnly = true;
            Tiltle.Resizable = DataGridViewTriState.False;
            Tiltle.Width = 461;
            // 
            // Rating
            // 
            dataGridViewCellStyle75.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle75.BackColor = Color.LightBlue;
            dataGridViewCellStyle75.Font = new Font("Cambria", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle75.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle75.NullValue = null;
            dataGridViewCellStyle75.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle75.SelectionForeColor = Color.White;
            Rating.DefaultCellStyle = dataGridViewCellStyle75;
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
            dataGridViewCellStyle76.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle76.BackColor = SystemColors.Control;
            dataGridViewCellStyle76.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle76.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle76.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle76.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle76.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle76;
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
            dataGridViewCellStyle77.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle77.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle77.ForeColor = Color.MidnightBlue;
            NumRoom.DefaultCellStyle = dataGridViewCellStyle77;
            NumRoom.HeaderText = "No.";
            NumRoom.MinimumWidth = 6;
            NumRoom.Name = "NumRoom";
            NumRoom.Resizable = DataGridViewTriState.False;
            NumRoom.Width = 48;
            // 
            // RoomID
            // 
            dataGridViewCellStyle78.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle78.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle78.ForeColor = Color.MidnightBlue;
            RoomID.DefaultCellStyle = dataGridViewCellStyle78;
            RoomID.HeaderText = "RoomID";
            RoomID.MinimumWidth = 6;
            RoomID.Name = "RoomID";
            RoomID.Resizable = DataGridViewTriState.False;
            RoomID.Width = 250;
            // 
            // Host
            // 
            dataGridViewCellStyle79.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle79.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle79.ForeColor = Color.MidnightBlue;
            Host.DefaultCellStyle = dataGridViewCellStyle79;
            Host.HeaderText = "Host";
            Host.MinimumWidth = 6;
            Host.Name = "Host";
            Host.Resizable = DataGridViewTriState.False;
            Host.Width = 260;
            // 
            // StartTime
            // 
            dataGridViewCellStyle80.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle80.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle80.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle80.Format = "T";
            dataGridViewCellStyle80.NullValue = null;
            StartTime.DefaultCellStyle = dataGridViewCellStyle80;
            StartTime.HeaderText = "Start Time";
            StartTime.MinimumWidth = 6;
            StartTime.Name = "StartTime";
            StartTime.Resizable = DataGridViewTriState.False;
            StartTime.Width = 292;
            // 
            // NumOfParticipants
            // 
            dataGridViewCellStyle81.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle81.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle81.ForeColor = Color.MidnightBlue;
            dataGridViewCellStyle81.NullValue = null;
            dataGridViewCellStyle81.WrapMode = DataGridViewTriState.True;
            NumOfParticipants.DefaultCellStyle = dataGridViewCellStyle81;
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