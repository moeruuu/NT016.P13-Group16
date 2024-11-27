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
            pictureBox1 = new PictureBox();
            searchtb = new RichTextBox();
            logo = new PictureBox();
            btnchoosefile = new Button();
            fileimage = new Label();
            chat = new PictureBox();
            picfilm1 = new PictureBox();
            picfilm2 = new PictureBox();
            picfilm3 = new PictureBox();
            picfilm6 = new PictureBox();
            picfilm5 = new PictureBox();
            picfilm4 = new PictureBox();
            filmname1 = new Label();
            event1 = new Label();
            event2 = new Label();
            filmname2 = new Label();
            event3 = new Label();
            filmname3 = new Label();
            event4 = new Label();
            filmname4 = new Label();
            event5 = new Label();
            filmname5 = new Label();
            event6 = new Label();
            filmname6 = new Label();
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
            logout = new PictureBox();
            cbpage = new ComboBox();
            waiting = new Label();
            tag = new Label();
            cbtag = new ComboBox();
            leftside.SuspendLayout();
            avatarpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avatar).BeginInit();
            toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picfilm1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picfilm2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picfilm3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picfilm6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picfilm5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picfilm4).BeginInit();
            bottompanel.SuspendLayout();
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
            btncoop.Size = new Size(240, 84);
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
            btnupload.Size = new Size(240, 84);
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
            btnwatchedvideo.Size = new Size(240, 84);
            btnwatchedvideo.TabIndex = 4;
            btnwatchedvideo.Text = "Watched Video";
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
            btntopvideo.Size = new Size(240, 84);
            btntopvideo.TabIndex = 3;
            btntopvideo.Text = "Top Rated Video";
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
            btnnewvideo.Size = new Size(240, 84);
            btnnewvideo.TabIndex = 2;
            btnnewvideo.Text = "New video";
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
            Username.Location = new Point(67, 135);
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
            Avatar.Location = new Point(57, 10);
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
            toppanel.Controls.Add(pictureBox1);
            toppanel.Controls.Add(searchtb);
            toppanel.Controls.Add(logo);
            toppanel.Dock = DockStyle.Top;
            toppanel.Location = new Point(240, 0);
            toppanel.Margin = new Padding(2);
            toppanel.Name = "toppanel";
            toppanel.Size = new Size(834, 120);
            toppanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.search;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(754, 41);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 42);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // searchtb
            // 
            searchtb.BackColor = Color.White;
            searchtb.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtb.ForeColor = Color.CadetBlue;
            searchtb.Location = new Point(153, 48);
            searchtb.Margin = new Padding(2);
            searchtb.Name = "searchtb";
            searchtb.Size = new Size(582, 35);
            searchtb.TabIndex = 1;
            searchtb.Text = "";
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
            btnchoosefile.Text = "Chọn tệp";
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
            fileimage.Size = new Size(62, 23);
            fileimage.TabIndex = 22;
            fileimage.Text = "label1";
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
            // 
            // picfilm1
            // 
            picfilm1.BackColor = SystemColors.ButtonHighlight;
            picfilm1.Cursor = Cursors.Hand;
            picfilm1.Location = new Point(315, 155);
            picfilm1.Margin = new Padding(2);
            picfilm1.Name = "picfilm1";
            picfilm1.Size = new Size(120, 120);
            picfilm1.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm1.TabIndex = 3;
            picfilm1.TabStop = false;
            picfilm1.Visible = false;
            picfilm1.MouseEnter += picfilm1_MouseEnter;
            picfilm1.MouseLeave += picfilm1_MouseLeave;
            // 
            // picfilm2
            // 
            picfilm2.BackColor = SystemColors.ButtonHighlight;
            picfilm2.Cursor = Cursors.Hand;
            picfilm2.Location = new Point(591, 155);
            picfilm2.Margin = new Padding(2);
            picfilm2.Name = "picfilm2";
            picfilm2.Size = new Size(120, 120);
            picfilm2.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm2.TabIndex = 4;
            picfilm2.TabStop = false;
            picfilm2.Visible = false;
            picfilm2.MouseEnter += picfilm2_MouseEnter;
            picfilm2.MouseLeave += picfilm2_MouseLeave;
            // 
            // picfilm3
            // 
            picfilm3.BackColor = SystemColors.ButtonHighlight;
            picfilm3.Cursor = Cursors.Hand;
            picfilm3.Location = new Point(884, 155);
            picfilm3.Margin = new Padding(2);
            picfilm3.Name = "picfilm3";
            picfilm3.Size = new Size(120, 120);
            picfilm3.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm3.TabIndex = 5;
            picfilm3.TabStop = false;
            picfilm3.Visible = false;
            picfilm3.MouseEnter += picfilm3_MouseEnter;
            picfilm3.MouseLeave += picfilm3_MouseLeave;
            // 
            // picfilm6
            // 
            picfilm6.BackColor = SystemColors.ButtonHighlight;
            picfilm6.Cursor = Cursors.Hand;
            picfilm6.Location = new Point(884, 385);
            picfilm6.Margin = new Padding(2);
            picfilm6.Name = "picfilm6";
            picfilm6.Size = new Size(120, 120);
            picfilm6.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm6.TabIndex = 8;
            picfilm6.TabStop = false;
            picfilm6.Visible = false;
            picfilm6.MouseEnter += picfilm6_MouseEnter;
            picfilm6.MouseLeave += picfilm6_MouseLeave;
            // 
            // picfilm5
            // 
            picfilm5.BackColor = SystemColors.ButtonHighlight;
            picfilm5.Cursor = Cursors.Hand;
            picfilm5.Location = new Point(591, 385);
            picfilm5.Margin = new Padding(2);
            picfilm5.Name = "picfilm5";
            picfilm5.Size = new Size(120, 120);
            picfilm5.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm5.TabIndex = 7;
            picfilm5.TabStop = false;
            picfilm5.Visible = false;
            picfilm5.MouseEnter += picfilm5_MouseEnter;
            picfilm5.MouseLeave += picfilm5_MouseLeave;
            // 
            // picfilm4
            // 
            picfilm4.BackColor = SystemColors.ButtonHighlight;
            picfilm4.Cursor = Cursors.Hand;
            picfilm4.Location = new Point(315, 385);
            picfilm4.Margin = new Padding(2);
            picfilm4.Name = "picfilm4";
            picfilm4.Size = new Size(120, 120);
            picfilm4.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm4.TabIndex = 6;
            picfilm4.TabStop = false;
            picfilm4.Visible = false;
            picfilm4.MouseEnter += picfilm4_MouseEnter;
            picfilm4.MouseLeave += picfilm4_MouseLeave;
            // 
            // filmname1
            // 
            filmname1.AutoSize = true;
            filmname1.Cursor = Cursors.Hand;
            filmname1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname1.ForeColor = SystemColors.ButtonHighlight;
            filmname1.Location = new Point(315, 278);
            filmname1.Margin = new Padding(2, 0, 2, 0);
            filmname1.Name = "filmname1";
            filmname1.Size = new Size(53, 20);
            filmname1.TabIndex = 9;
            filmname1.Text = "label1";
            filmname1.Visible = false;
            // 
            // event1
            // 
            event1.AutoSize = true;
            event1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event1.ForeColor = SystemColors.ButtonHighlight;
            event1.Location = new Point(315, 305);
            event1.Margin = new Padding(2, 0, 2, 0);
            event1.Name = "event1";
            event1.Size = new Size(53, 20);
            event1.TabIndex = 10;
            event1.Text = "label2";
            event1.Visible = false;
            // 
            // event2
            // 
            event2.AutoSize = true;
            event2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event2.ForeColor = SystemColors.ButtonHighlight;
            event2.Location = new Point(591, 305);
            event2.Margin = new Padding(2, 0, 2, 0);
            event2.Name = "event2";
            event2.Size = new Size(53, 20);
            event2.TabIndex = 12;
            event2.Text = "label3";
            event2.Visible = false;
            // 
            // filmname2
            // 
            filmname2.AutoSize = true;
            filmname2.Cursor = Cursors.Hand;
            filmname2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname2.ForeColor = SystemColors.ButtonHighlight;
            filmname2.Location = new Point(591, 278);
            filmname2.Margin = new Padding(2, 0, 2, 0);
            filmname2.Name = "filmname2";
            filmname2.Size = new Size(53, 20);
            filmname2.TabIndex = 11;
            filmname2.Text = "label4";
            filmname2.Visible = false;
            // 
            // event3
            // 
            event3.AutoSize = true;
            event3.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event3.ForeColor = SystemColors.ButtonHighlight;
            event3.Location = new Point(884, 305);
            event3.Margin = new Padding(2, 0, 2, 0);
            event3.Name = "event3";
            event3.Size = new Size(53, 20);
            event3.TabIndex = 14;
            event3.Text = "label5";
            event3.Visible = false;
            // 
            // filmname3
            // 
            filmname3.AutoSize = true;
            filmname3.Cursor = Cursors.Hand;
            filmname3.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname3.ForeColor = SystemColors.ButtonHighlight;
            filmname3.Location = new Point(884, 278);
            filmname3.Margin = new Padding(2, 0, 2, 0);
            filmname3.Name = "filmname3";
            filmname3.Size = new Size(53, 20);
            filmname3.TabIndex = 13;
            filmname3.Text = "label6";
            filmname3.Visible = false;
            // 
            // event4
            // 
            event4.AutoSize = true;
            event4.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event4.ForeColor = SystemColors.ButtonHighlight;
            event4.Location = new Point(315, 535);
            event4.Margin = new Padding(2, 0, 2, 0);
            event4.Name = "event4";
            event4.Size = new Size(53, 20);
            event4.TabIndex = 16;
            event4.Text = "label7";
            event4.Visible = false;
            // 
            // filmname4
            // 
            filmname4.AutoSize = true;
            filmname4.Cursor = Cursors.Hand;
            filmname4.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname4.ForeColor = SystemColors.ButtonHighlight;
            filmname4.Location = new Point(315, 508);
            filmname4.Margin = new Padding(2, 0, 2, 0);
            filmname4.Name = "filmname4";
            filmname4.Size = new Size(53, 20);
            filmname4.TabIndex = 15;
            filmname4.Text = "label8";
            filmname4.Visible = false;
            // 
            // event5
            // 
            event5.AutoSize = true;
            event5.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event5.ForeColor = SystemColors.ButtonHighlight;
            event5.Location = new Point(591, 535);
            event5.Margin = new Padding(2, 0, 2, 0);
            event5.Name = "event5";
            event5.Size = new Size(53, 20);
            event5.TabIndex = 18;
            event5.Text = "label9";
            event5.Visible = false;
            // 
            // filmname5
            // 
            filmname5.AutoSize = true;
            filmname5.Cursor = Cursors.Hand;
            filmname5.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname5.ForeColor = SystemColors.ButtonHighlight;
            filmname5.Location = new Point(591, 508);
            filmname5.Margin = new Padding(2, 0, 2, 0);
            filmname5.Name = "filmname5";
            filmname5.Size = new Size(62, 20);
            filmname5.TabIndex = 17;
            filmname5.Text = "label10";
            filmname5.Visible = false;
            // 
            // event6
            // 
            event6.AutoSize = true;
            event6.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event6.ForeColor = SystemColors.ButtonHighlight;
            event6.Location = new Point(884, 535);
            event6.Margin = new Padding(2, 0, 2, 0);
            event6.Name = "event6";
            event6.Size = new Size(62, 20);
            event6.TabIndex = 20;
            event6.Text = "label11";
            event6.Visible = false;
            // 
            // filmname6
            // 
            filmname6.AutoSize = true;
            filmname6.Cursor = Cursors.Hand;
            filmname6.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname6.ForeColor = SystemColors.ButtonHighlight;
            filmname6.Location = new Point(884, 508);
            filmname6.Margin = new Padding(2, 0, 2, 0);
            filmname6.Name = "filmname6";
            filmname6.Size = new Size(62, 20);
            filmname6.TabIndex = 19;
            filmname6.Text = "label12";
            filmname6.Visible = false;
            // 
            // tenphim
            // 
            tenphim.AutoSize = true;
            tenphim.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tenphim.ForeColor = Color.MidnightBlue;
            tenphim.Location = new Point(315, 198);
            tenphim.Margin = new Padding(2, 0, 2, 0);
            tenphim.Name = "tenphim";
            tenphim.Size = new Size(90, 23);
            tenphim.TabIndex = 23;
            tenphim.Text = "Tên phim";
            tenphim.Visible = false;
            // 
            // noidung
            // 
            noidung.AutoSize = true;
            noidung.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noidung.ForeColor = Color.MidnightBlue;
            noidung.Location = new Point(315, 252);
            noidung.Margin = new Padding(2, 0, 2, 0);
            noidung.Name = "noidung";
            noidung.Size = new Size(88, 23);
            noidung.TabIndex = 24;
            noidung.Text = "Nội dung";
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
            progressupload.Size = new Size(512, 23);
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
            btnchooseimage.Text = "Chọn ảnh";
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
            filevideo.Size = new Size(62, 23);
            filevideo.TabIndex = 34;
            filevideo.Text = "label1";
            filevideo.Visible = false;
            // 
            // information
            // 
            information.AutoSize = true;
            information.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            information.ForeColor = SystemColors.ButtonHighlight;
            information.Location = new Point(262, 135);
            information.Margin = new Padding(2, 0, 2, 0);
            information.Name = "information";
            information.Size = new Size(248, 23);
            information.TabIndex = 35;
            information.Text = "Hiện tại chưa có video nào...";
            information.Visible = false;
            // 
            // bottompanel
            // 
            bottompanel.BackColor = Color.PowderBlue;
            bottompanel.Controls.Add(logout);
            bottompanel.Controls.Add(cbpage);
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
            // logout
            // 
            logout.Cursor = Cursors.Hand;
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(799, 5);
            logout.Margin = new Padding(2, 2, 2, 2);
            logout.Name = "logout";
            logout.Size = new Size(28, 28);
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.TabIndex = 31;
            logout.TabStop = false;
            logout.Click += logout_Click;
            // 
            // cbpage
            // 
            cbpage.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbpage.ForeColor = Color.MidnightBlue;
            cbpage.FormattingEnabled = true;
            cbpage.Location = new Point(709, 6);
            cbpage.Margin = new Padding(2);
            cbpage.Name = "cbpage";
            cbpage.Size = new Size(45, 25);
            cbpage.TabIndex = 30;
            cbpage.Visible = false;
            cbpage.SelectedIndexChanged += cbpage_SelectedIndexChanged;
            // 
            // waiting
            // 
            waiting.AutoSize = true;
            waiting.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            waiting.ForeColor = Color.MidnightBlue;
            waiting.Location = new Point(5, 12);
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
            tag.Location = new Point(782, 199);
            tag.Margin = new Padding(2, 0, 2, 0);
            tag.Name = "tag";
            tag.Size = new Size(79, 23);
            tag.TabIndex = 37;
            tag.Text = "Thể loại";
            tag.Visible = false;
            // 
            // cbtag
            // 
            cbtag.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbtag.ForeColor = Color.MidnightBlue;
            cbtag.FormattingEnabled = true;
            cbtag.Items.AddRange(new object[] { "Âm nhạc", "Ẩm thực", "Giải Trí", "Hoạt hình", "Học tập", "Mỹ phẩm", "Review", "Vlog" });
            cbtag.Location = new Point(863, 198);
            cbtag.Margin = new Padding(2);
            cbtag.Name = "cbtag";
            cbtag.Size = new Size(146, 28);
            cbtag.Sorted = true;
            cbtag.TabIndex = 38;
            cbtag.Visible = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1074, 615);
            Controls.Add(cbtag);
            Controls.Add(tag);
            Controls.Add(bottompanel);
            Controls.Add(information);
            Controls.Add(filevideo);
            Controls.Add(btnchooseimage);
            Controls.Add(linkcreateroom);
            Controls.Add(btnchoosefile);
            Controls.Add(fileimage);
            Controls.Add(btnidroom);
            Controls.Add(idroom);
            Controls.Add(tbidroom);
            Controls.Add(tbdescription);
            Controls.Add(btnuploadvideo);
            Controls.Add(tbnamefilm);
            Controls.Add(noidung);
            Controls.Add(tenphim);
            Controls.Add(event6);
            Controls.Add(filmname6);
            Controls.Add(event5);
            Controls.Add(filmname5);
            Controls.Add(event4);
            Controls.Add(filmname4);
            Controls.Add(event3);
            Controls.Add(filmname3);
            Controls.Add(event2);
            Controls.Add(filmname2);
            Controls.Add(event1);
            Controls.Add(filmname1);
            Controls.Add(picfilm6);
            Controls.Add(picfilm5);
            Controls.Add(picfilm4);
            Controls.Add(picfilm3);
            Controls.Add(picfilm2);
            Controls.Add(picfilm1);
            Controls.Add(toppanel);
            Controls.Add(leftside);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Home";
            Text = "Home";
            leftside.ResumeLayout(false);
            avatarpanel.ResumeLayout(false);
            avatarpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Avatar).EndInit();
            toppanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)chat).EndInit();
            ((System.ComponentModel.ISupportInitialize)picfilm1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picfilm2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picfilm3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picfilm6).EndInit();
            ((System.ComponentModel.ISupportInitialize)picfilm5).EndInit();
            ((System.ComponentModel.ISupportInitialize)picfilm4).EndInit();
            bottompanel.ResumeLayout(false);
            bottompanel.PerformLayout();
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
        private PictureBox pictureBox1;
        private PictureBox chat;
        private PictureBox picfilm1;
        private PictureBox picfilm2;
        private PictureBox picfilm3;
        private PictureBox picfilm6;
        private PictureBox picfilm5;
        private PictureBox picfilm4;
        private Label filmname1;
        private Label event1;
        private Label event2;
        private Label filmname2;
        private Label event3;
        private Label filmname3;
        private Label event4;
        private Label filmname4;
        private Label event5;
        private Label filmname5;
        private Label event6;
        private Label filmname6;
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
        private ComboBox cbpage;
        private Label tag;
        private ComboBox cbtag;
        private PictureBox logout;
    }
}
