namespace UITFLIX
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            leftside = new Panel();
            btncoop = new FontAwesome.Sharp.IconButton();
            btnupload = new FontAwesome.Sharp.IconButton();
            btnwatchedvideo = new FontAwesome.Sharp.IconButton();
            btntopvideo = new FontAwesome.Sharp.IconButton();
            btnnewvideo = new FontAwesome.Sharp.IconButton();
            avatarpanel = new Panel();
            Username = new LinkLabel();
            Avatar = new PictureBox();
            toppanel = new Panel();
            btnSearch = new PictureBox();
            searchtb = new RichTextBox();
            logo = new PictureBox();
            btnchoosefile = new Button();
            fileimage = new Label();
            chat = new PictureBox();
            tenphim = new Label();
            noidung = new Label();
            tbnamefilm = new TextBox();
            tbdescription = new RichTextBox();
            btnuploadvideo = new Button();
            progressupload = new ProgressBar();
            tbidroom = new TextBox();
            idroom = new Label();
            btnidroom = new Button();
            linkcreateroom = new LinkLabel();
            btnchooseimage = new Button();
            filevideo = new Label();
            information = new Label();
            bottompanel = new Panel();
            pictureBoxDonate = new PictureBox();
            iconDeleteVideo = new FontAwesome.Sharp.IconPictureBox();
            logout = new PictureBox();
            waiting = new Label();
            tag = new Label();
            cbtag = new ComboBox();
            fpnVideos = new FlowLayoutPanel();
            leftside.SuspendLayout();
            avatarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avatar).BeginInit();
            toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chat).BeginInit();
            bottompanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDonate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconDeleteVideo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            SuspendLayout();
            // 
            // leftside
            // 
            leftside.BackColor = Color.CadetBlue;
            leftside.Controls.Add(btncoop);
            leftside.Controls.Add(btnupload);
            leftside.Controls.Add(btnwatchedvideo);
            leftside.Controls.Add(btntopvideo);
            leftside.Controls.Add(btnnewvideo);
            leftside.Controls.Add(avatarpanel);
            leftside.Dock = DockStyle.Left;
            leftside.ForeColor = Color.Black;
            leftside.Location = new Point(0, 0);
            leftside.Margin = new Padding(2);
            leftside.Name = "leftside";
            leftside.Size = new Size(240, 615);
            leftside.TabIndex = 0;
            // 
            // btncoop
            // 
            btncoop.BackColor = Color.CadetBlue;
            btncoop.FlatAppearance.BorderSize = 0;
            btncoop.FlatStyle = FlatStyle.Flat;
            btncoop.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btncoop.ForeColor = Color.White;
            btncoop.IconChar = FontAwesome.Sharp.IconChar.Eye;
            btncoop.IconColor = Color.White;
            btncoop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btncoop.ImageAlign = ContentAlignment.MiddleLeft;
            btncoop.Location = new Point(0, 531);
            btncoop.Margin = new Padding(2);
            btncoop.Name = "btncoop";
            btncoop.Padding = new Padding(8, 0, 16, 0);
            btncoop.Size = new Size(241, 84);
            btncoop.TabIndex = 6;
            btncoop.Text = "Watch Together";
            btncoop.TextImageRelation = TextImageRelation.ImageBeforeText;
            btncoop.UseVisualStyleBackColor = false;
            btncoop.Click += btncoop_Click;
            // 
            // btnupload
            // 
            btnupload.BackColor = Color.CadetBlue;
            btnupload.FlatAppearance.BorderSize = 0;
            btnupload.FlatStyle = FlatStyle.Flat;
            btnupload.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnupload.ForeColor = Color.White;
            btnupload.IconChar = FontAwesome.Sharp.IconChar.ArrowUp;
            btnupload.IconColor = Color.White;
            btnupload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnupload.ImageAlign = ContentAlignment.MiddleLeft;
            btnupload.Location = new Point(0, 442);
            btnupload.Margin = new Padding(2);
            btnupload.Name = "btnupload";
            btnupload.Padding = new Padding(8, 0, 16, 0);
            btnupload.Size = new Size(241, 84);
            btnupload.TabIndex = 5;
            btnupload.Text = "Upload Video";
            btnupload.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnupload.UseVisualStyleBackColor = false;
            btnupload.Click += btnupload_Click;
            // 
            // btnwatchedvideo
            // 
            btnwatchedvideo.BackColor = Color.CadetBlue;
            btnwatchedvideo.FlatAppearance.BorderSize = 0;
            btnwatchedvideo.FlatStyle = FlatStyle.Flat;
            btnwatchedvideo.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnwatchedvideo.ForeColor = Color.White;
            btnwatchedvideo.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            btnwatchedvideo.IconColor = Color.White;
            btnwatchedvideo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnwatchedvideo.ImageAlign = ContentAlignment.MiddleLeft;
            btnwatchedvideo.Location = new Point(0, 354);
            btnwatchedvideo.Margin = new Padding(2);
            btnwatchedvideo.Name = "btnwatchedvideo";
            btnwatchedvideo.Padding = new Padding(8, 0, 16, 0);
            btnwatchedvideo.Size = new Size(241, 84);
            btnwatchedvideo.TabIndex = 4;
            btnwatchedvideo.Text = "Watched Videos";
            btnwatchedvideo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnwatchedvideo.UseVisualStyleBackColor = false;
            btnwatchedvideo.Click += btnwatchedvideo_Click;
            // 
            // btntopvideo
            // 
            btntopvideo.BackColor = Color.CadetBlue;
            btntopvideo.FlatAppearance.BorderSize = 0;
            btntopvideo.FlatStyle = FlatStyle.Flat;
            btntopvideo.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btntopvideo.ForeColor = Color.White;
            btntopvideo.IconChar = FontAwesome.Sharp.IconChar.Star;
            btntopvideo.IconColor = Color.White;
            btntopvideo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btntopvideo.ImageAlign = ContentAlignment.MiddleLeft;
            btntopvideo.Location = new Point(0, 265);
            btntopvideo.Margin = new Padding(2);
            btntopvideo.Name = "btntopvideo";
            btntopvideo.Padding = new Padding(8, 0, 16, 0);
            btntopvideo.Size = new Size(241, 84);
            btntopvideo.TabIndex = 3;
            btntopvideo.Text = "Top Rated Videos";
            btntopvideo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btntopvideo.UseVisualStyleBackColor = false;
            btntopvideo.Click += btntopvideo_Click;
            // 
            // btnnewvideo
            // 
            btnnewvideo.BackColor = Color.CadetBlue;
            btnnewvideo.FlatAppearance.BorderSize = 0;
            btnnewvideo.FlatStyle = FlatStyle.Flat;
            btnnewvideo.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnnewvideo.ForeColor = Color.White;
            btnnewvideo.IconChar = FontAwesome.Sharp.IconChar.Neos;
            btnnewvideo.IconColor = Color.White;
            btnnewvideo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnnewvideo.ImageAlign = ContentAlignment.MiddleLeft;
            btnnewvideo.Location = new Point(0, 176);
            btnnewvideo.Margin = new Padding(2);
            btnnewvideo.Name = "btnnewvideo";
            btnnewvideo.Padding = new Padding(8, 0, 16, 0);
            btnnewvideo.Size = new Size(241, 84);
            btnnewvideo.TabIndex = 2;
            btnnewvideo.Text = "New videos";
            btnnewvideo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnnewvideo.UseVisualStyleBackColor = false;
            btnnewvideo.Click += btnnewvideo_Click;
            // 
            // avatarpanel
            // 
            avatarpanel.Controls.Add(Username);
            avatarpanel.Controls.Add(Avatar);
            avatarpanel.Dock = DockStyle.Top;
            avatarpanel.Location = new Point(0, 0);
            avatarpanel.Margin = new Padding(2);
            avatarpanel.Name = "avatarpanel";
            avatarpanel.Size = new Size(240, 171);
            avatarpanel.TabIndex = 0;
            // 
            // Username
            // 
            Username.ActiveLinkColor = Color.MidnightBlue;
            Username.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Username.AutoSize = true;
            Username.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Username.LinkColor = Color.White;
            Username.Location = new Point(75, 135);
            Username.Margin = new Padding(2, 0, 2, 0);
            Username.Name = "Username";
            Username.Size = new Size(92, 22);
            Username.TabIndex = 3;
            Username.TabStop = true;
            Username.Text = "Username";
            Username.LinkClicked += Username_LinkClicked;
            // 
            // Avatar
            // 
            Avatar.BackgroundImageLayout = ImageLayout.Stretch;
            Avatar.Location = new Point(64, 10);
            Avatar.Margin = new Padding(2);
            Avatar.Name = "Avatar";
            Avatar.Size = new Size(112, 112);
            Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            Avatar.TabIndex = 2;
            Avatar.TabStop = false;
            // 
            // toppanel
            // 
            toppanel.BackColor = Color.PowderBlue;
            toppanel.Controls.Add(btnSearch);
            toppanel.Controls.Add(searchtb);
            toppanel.Controls.Add(logo);
            toppanel.Dock = DockStyle.Top;
            toppanel.Location = new Point(240, 0);
            toppanel.Margin = new Padding(2);
            toppanel.Name = "toppanel";
            toppanel.Size = new Size(834, 120);
            toppanel.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackgroundImage = Properties.Resources.search;
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Location = new Point(746, 41);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(40, 42);
            btnSearch.TabIndex = 2;
            btnSearch.TabStop = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // searchtb
            // 
            searchtb.BackColor = Color.White;
            searchtb.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtb.ForeColor = Color.CadetBlue;
            searchtb.Location = new Point(137, 44);
            searchtb.Margin = new Padding(2);
            searchtb.Multiline = false;
            searchtb.Name = "searchtb";
            searchtb.Size = new Size(598, 35);
            searchtb.TabIndex = 1;
            searchtb.Text = "";
            searchtb.Enter += searchtb_Enter;
            searchtb.KeyDown += searchtb_KeyDown;
            searchtb.Leave += searchtb_Leave;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.UITFLIX;
            logo.Location = new Point(22, 10);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.Size = new Size(111, 108);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // btnchoosefile
            // 
            btnchoosefile.Cursor = Cursors.Hand;
            btnchoosefile.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnchoosefile.ForeColor = Color.MidnightBlue;
            btnchoosefile.Location = new Point(267, 136);
            btnchoosefile.Margin = new Padding(2);
            btnchoosefile.Name = "btnchoosefile";
            btnchoosefile.Size = new Size(134, 36);
            btnchoosefile.TabIndex = 21;
            btnchoosefile.Text = "Selete file";
            btnchoosefile.UseVisualStyleBackColor = true;
            btnchoosefile.Visible = false;
            btnchoosefile.Click += btnchoosefile_Click;
            // 
            // fileimage
            // 
            fileimage.AutoSize = true;
            fileimage.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileimage.ForeColor = Color.MidnightBlue;
            fileimage.Location = new Point(835, 141);
            fileimage.Margin = new Padding(2, 0, 2, 0);
            fileimage.Name = "fileimage";
            fileimage.Size = new Size(99, 23);
            fileimage.TabIndex = 22;
            fileimage.Text = "File Image";
            fileimage.Visible = false;
            // 
            // chat
            // 
            chat.BackgroundImage = Properties.Resources._5962463;
            chat.BackgroundImageLayout = ImageLayout.Zoom;
            chat.Cursor = Cursors.Hand;
            chat.Location = new Point(757, 6);
            chat.Margin = new Padding(2);
            chat.Name = "chat";
            chat.Size = new Size(38, 24);
            chat.TabIndex = 2;
            chat.TabStop = false;
            chat.Click += chat_Click;
            // 
            // tenphim
            // 
            tenphim.AutoSize = true;
            tenphim.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tenphim.ForeColor = Color.MidnightBlue;
            tenphim.Location = new Point(315, 198);
            tenphim.Margin = new Padding(2, 0, 2, 0);
            tenphim.Name = "tenphim";
            tenphim.Size = new Size(50, 23);
            tenphim.TabIndex = 23;
            tenphim.Text = "Title";
            tenphim.Visible = false;
            // 
            // noidung
            // 
            noidung.AutoSize = true;
            noidung.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noidung.ForeColor = Color.MidnightBlue;
            noidung.Location = new Point(315, 253);
            noidung.Margin = new Padding(2, 0, 2, 0);
            noidung.Name = "noidung";
            noidung.Size = new Size(111, 23);
            noidung.TabIndex = 24;
            noidung.Text = "Description";
            noidung.Visible = false;
            // 
            // tbnamefilm
            // 
            tbnamefilm.Font = new Font("Cambria", 11F);
            tbnamefilm.ForeColor = Color.MidnightBlue;
            tbnamefilm.Location = new Point(440, 198);
            tbnamefilm.Margin = new Padding(2);
            tbnamefilm.Name = "tbnamefilm";
            tbnamefilm.Size = new Size(330, 29);
            tbnamefilm.TabIndex = 25;
            tbnamefilm.Visible = false;
            // 
            // tbdescription
            // 
            tbdescription.Font = new Font("Cambria", 11F);
            tbdescription.ForeColor = Color.MidnightBlue;
            tbdescription.Location = new Point(440, 256);
            tbdescription.Margin = new Padding(2);
            tbdescription.Name = "tbdescription";
            tbdescription.Size = new Size(570, 209);
            tbdescription.TabIndex = 26;
            tbdescription.Text = "";
            tbdescription.Visible = false;
            // 
            // btnuploadvideo
            // 
            btnuploadvideo.Cursor = Cursors.Hand;
            btnuploadvideo.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnuploadvideo.ForeColor = Color.MidnightBlue;
            btnuploadvideo.Location = new Point(670, 479);
            btnuploadvideo.Margin = new Padding(2);
            btnuploadvideo.Name = "btnuploadvideo";
            btnuploadvideo.Size = new Size(134, 36);
            btnuploadvideo.TabIndex = 27;
            btnuploadvideo.Text = "Upload";
            btnuploadvideo.UseVisualStyleBackColor = true;
            btnuploadvideo.Visible = false;
            btnuploadvideo.Click += btnuploadvideo_Click;
            // 
            // progressupload
            // 
            progressupload.Location = new Point(5, 7);
            progressupload.Margin = new Padding(2);
            progressupload.Name = "progressupload";
            progressupload.Size = new Size(683, 23);
            progressupload.TabIndex = 28;
            // 
            // tbidroom
            // 
            tbidroom.Font = new Font("Cambria", 11F);
            tbidroom.ForeColor = Color.MidnightBlue;
            tbidroom.Location = new Point(506, 287);
            tbidroom.Margin = new Padding(2);
            tbidroom.Name = "tbidroom";
            tbidroom.Size = new Size(334, 29);
            tbidroom.TabIndex = 29;
            tbidroom.Visible = false;
            // 
            // idroom
            // 
            idroom.AutoSize = true;
            idroom.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idroom.ForeColor = Color.MidnightBlue;
            idroom.Location = new Point(628, 251);
            idroom.Margin = new Padding(2, 0, 2, 0);
            idroom.Name = "idroom";
            idroom.Size = new Size(87, 23);
            idroom.TabIndex = 30;
            idroom.Text = "ID ROOM";
            idroom.Visible = false;
            // 
            // btnidroom
            // 
            btnidroom.Cursor = Cursors.Hand;
            btnidroom.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnidroom.ForeColor = Color.MidnightBlue;
            btnidroom.Location = new Point(610, 326);
            btnidroom.Margin = new Padding(2);
            btnidroom.Name = "btnidroom";
            btnidroom.Size = new Size(141, 36);
            btnidroom.TabIndex = 31;
            btnidroom.Text = "Join";
            btnidroom.UseVisualStyleBackColor = true;
            btnidroom.Visible = false;
            btnidroom.Click += btnidroom_Click;
            // 
            // linkcreateroom
            // 
            linkcreateroom.ActiveLinkColor = Color.Snow;
            linkcreateroom.AutoSize = true;
            linkcreateroom.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkcreateroom.ForeColor = Color.MidnightBlue;
            linkcreateroom.LinkColor = Color.MidnightBlue;
            linkcreateroom.Location = new Point(262, 588);
            linkcreateroom.Margin = new Padding(2, 0, 2, 0);
            linkcreateroom.Name = "linkcreateroom";
            linkcreateroom.Size = new Size(145, 20);
            linkcreateroom.TabIndex = 32;
            linkcreateroom.TabStop = true;
            linkcreateroom.Text = "Create a new room";
            linkcreateroom.Visible = false;
            linkcreateroom.LinkClicked += linkcreateroom_LinkClicked;
            // 
            // btnchooseimage
            // 
            btnchooseimage.Cursor = Cursors.Hand;
            btnchooseimage.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnchooseimage.ForeColor = Color.MidnightBlue;
            btnchooseimage.Location = new Point(670, 135);
            btnchooseimage.Margin = new Padding(2);
            btnchooseimage.Name = "btnchooseimage";
            btnchooseimage.Size = new Size(134, 36);
            btnchooseimage.TabIndex = 33;
            btnchooseimage.Text = "Selete image";
            btnchooseimage.UseVisualStyleBackColor = true;
            btnchooseimage.Visible = false;
            btnchooseimage.Click += btnchooseimage_Click;
            // 
            // filevideo
            // 
            filevideo.AutoSize = true;
            filevideo.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filevideo.ForeColor = Color.MidnightBlue;
            filevideo.Location = new Point(439, 142);
            filevideo.Margin = new Padding(2, 0, 2, 0);
            filevideo.Name = "filevideo";
            filevideo.Size = new Size(96, 23);
            filevideo.TabIndex = 34;
            filevideo.Text = "File Video";
            filevideo.Visible = false;
            // 
            // information
            // 
            information.AutoSize = true;
            information.Font = new Font("Cambria", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            information.ForeColor = SystemColors.ButtonHighlight;
            information.Location = new Point(413, 338);
            information.Margin = new Padding(2, 0, 2, 0);
            information.Name = "information";
            information.Size = new Size(488, 23);
            information.TabIndex = 35;
            information.Text = "Currently, there are no videos matching your search...";
            information.Visible = false;
            // 
            // bottompanel
            // 
            bottompanel.BackColor = Color.PowderBlue;
            bottompanel.Controls.Add(pictureBoxDonate);
            bottompanel.Controls.Add(iconDeleteVideo);
            bottompanel.Controls.Add(logout);
            bottompanel.Controls.Add(waiting);
            bottompanel.Controls.Add(progressupload);
            bottompanel.Controls.Add(chat);
            bottompanel.Dock = DockStyle.Bottom;
            bottompanel.Location = new Point(240, 580);
            bottompanel.Margin = new Padding(2);
            bottompanel.Name = "bottompanel";
            bottompanel.Size = new Size(834, 35);
            bottompanel.TabIndex = 36;
            // 
            // pictureBoxDonate
            // 
            pictureBoxDonate.BackgroundImage = Properties.Resources.charity;
            pictureBoxDonate.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxDonate.Image = Properties.Resources.donate;
            pictureBoxDonate.Location = new Point(722, 4);
            pictureBoxDonate.Name = "pictureBoxDonate";
            pictureBoxDonate.Size = new Size(34, 27);
            pictureBoxDonate.TabIndex = 33;
            pictureBoxDonate.TabStop = false;
            pictureBoxDonate.Click += pictureBoxDonate_Click;
            // 
            // iconDeleteVideo
            // 
            iconDeleteVideo.BackColor = Color.PowderBlue;
            iconDeleteVideo.Cursor = Cursors.Hand;
            iconDeleteVideo.ForeColor = Color.DarkRed;
            iconDeleteVideo.IconChar = FontAwesome.Sharp.IconChar.X;
            iconDeleteVideo.IconColor = Color.DarkRed;
            iconDeleteVideo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconDeleteVideo.IconSize = 25;
            iconDeleteVideo.Location = new Point(693, 6);
            iconDeleteVideo.Name = "iconDeleteVideo";
            iconDeleteVideo.Size = new Size(25, 25);
            iconDeleteVideo.TabIndex = 32;
            iconDeleteVideo.TabStop = false;
            iconDeleteVideo.Visible = false;
            iconDeleteVideo.Click += iconDeleteVideo_Click;
            // 
            // logout
            // 
            logout.Cursor = Cursors.Hand;
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(799, 5);
            logout.Margin = new Padding(2);
            logout.Name = "logout";
            logout.Size = new Size(28, 28);
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.TabIndex = 31;
            logout.TabStop = false;
            logout.Click += logout_Click;
            // 
            // waiting
            // 
            waiting.AutoSize = true;
            waiting.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            waiting.ForeColor = Color.MidnightBlue;
            waiting.Location = new Point(5, 7);
            waiting.Margin = new Padding(2, 0, 2, 0);
            waiting.Name = "waiting";
            waiting.Size = new Size(143, 20);
            waiting.TabIndex = 29;
            waiting.Text = "Waiting for video...";
            waiting.Visible = false;
            // 
            // tag
            // 
            tag.AutoSize = true;
            tag.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tag.ForeColor = Color.MidnightBlue;
            tag.Location = new Point(787, 200);
            tag.Margin = new Padding(2, 0, 2, 0);
            tag.Name = "tag";
            tag.Size = new Size(61, 23);
            tag.TabIndex = 37;
            tag.Text = "Genre";
            tag.Visible = false;
            // 
            // cbtag
            // 
            cbtag.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbtag.ForeColor = Color.MidnightBlue;
            cbtag.FormattingEnabled = true;
            cbtag.Items.AddRange(new object[] { "Animation", "Beauty", "Cinema", "Education", "Entertainment", "Food", "Gaming", "Music", "News", "Sports", "Technology", "Vlog" });
            cbtag.Location = new Point(863, 198);
            cbtag.Margin = new Padding(2);
            cbtag.Name = "cbtag";
            cbtag.Size = new Size(146, 28);
            cbtag.Sorted = true;
            cbtag.TabIndex = 38;
            cbtag.Visible = false;
            // 
            // fpnVideos
            // 
            fpnVideos.AutoScroll = true;
            fpnVideos.Location = new Point(288, 123);
            fpnVideos.Name = "fpnVideos";
            fpnVideos.Size = new Size(786, 457);
            fpnVideos.TabIndex = 39;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1074, 615);
            ControlBox = false;
            Controls.Add(btnidroom);
            Controls.Add(cbtag);
            Controls.Add(tag);
            Controls.Add(bottompanel);
            Controls.Add(information);
            Controls.Add(filevideo);
            Controls.Add(btnchooseimage);
            Controls.Add(linkcreateroom);
            Controls.Add(btnchoosefile);
            Controls.Add(fileimage);
            Controls.Add(idroom);
            Controls.Add(tbidroom);
            Controls.Add(btnuploadvideo);
            Controls.Add(tbnamefilm);
            Controls.Add(noidung);
            Controls.Add(tenphim);
            Controls.Add(toppanel);
            Controls.Add(leftside);
            Controls.Add(tbdescription);
            Controls.Add(fpnVideos);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Home";
            Text = "Home";
            FormClosing += Home_FormClosing;
            leftside.ResumeLayout(false);
            avatarpanel.ResumeLayout(false);
            avatarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avatar).EndInit();
            toppanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)chat).EndInit();
            bottompanel.ResumeLayout(false);
            bottompanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDonate).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconDeleteVideo).EndInit();
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel leftside;
        private Panel toppanel;
        private Panel avatarpanel;
        private FontAwesome.Sharp.IconButton btncoop;
        private FontAwesome.Sharp.IconButton btnupload;
        private FontAwesome.Sharp.IconButton btnwatchedvideo;
        private FontAwesome.Sharp.IconButton btntopvideo;
        private FontAwesome.Sharp.IconButton btnnewvideo;
        private PictureBox Avatar;
        private PictureBox logo;
        private RichTextBox searchtb;
        private PictureBox btnSearch;
        private PictureBox chat;
        private Button btnchoosefile;
        private Label fileimage;
        private Label tenphim;
        private Label noidung;
        private TextBox tbnamefilm;
        private RichTextBox tbdescription;
        private Button btnuploadvideo;
        private ProgressBar progressupload;
        private TextBox tbidroom;
        private Label idroom;
        private Button btnidroom;
        private LinkLabel linkcreateroom;
        private Button btnchooseimage;
        private Label filevideo;
        private LinkLabel Username;
        private Label information;
        private Panel bottompanel;
        private Label waiting;
        private Label tag;
        private ComboBox cbtag;
        private PictureBox logout;
        private FlowLayoutPanel fpnVideos;
        private FontAwesome.Sharp.IconPictureBox iconDeleteVideo;
        private PictureBox pictureBoxDonate;
    }
}
