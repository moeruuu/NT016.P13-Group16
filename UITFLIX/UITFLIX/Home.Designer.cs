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
            waiting = new Label();
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
            leftside.Name = "leftside";
            leftside.Size = new Size(300, 769);
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
            btncoop.Location = new Point(0, 664);
            btncoop.Name = "btncoop";
            btncoop.Padding = new Padding(10, 0, 20, 0);
            btncoop.Size = new Size(300, 105);
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
            btnupload.Location = new Point(0, 553);
            btnupload.Name = "btnupload";
            btnupload.Padding = new Padding(10, 0, 20, 0);
            btnupload.Size = new Size(300, 105);
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
            btnwatchedvideo.Location = new Point(0, 442);
            btnwatchedvideo.Name = "btnwatchedvideo";
            btnwatchedvideo.Padding = new Padding(10, 0, 20, 0);
            btnwatchedvideo.Size = new Size(300, 105);
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
            btntopvideo.Location = new Point(0, 331);
            btntopvideo.Name = "btntopvideo";
            btntopvideo.Padding = new Padding(10, 0, 20, 0);
            btntopvideo.Size = new Size(300, 105);
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
            btnnewvideo.Location = new Point(0, 220);
            btnnewvideo.Name = "btnnewvideo";
            btnnewvideo.Padding = new Padding(10, 0, 20, 0);
            btnnewvideo.Size = new Size(300, 105);
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
            avatarpanel.Name = "avatarpanel";
            avatarpanel.Size = new Size(300, 214);
            avatarpanel.TabIndex = 0;
            // 
            // Username
            // 
            Username.ActiveLinkColor = Color.MidnightBlue;
            Username.AutoSize = true;
            Username.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Username.LinkColor = Color.White;
            Username.Location = new Point(84, 169);
            Username.Name = "Username";
            Username.Size = new Size(107, 26);
            Username.TabIndex = 3;
            Username.TabStop = true;
            Username.Text = "Username";
            // 
            // Avatar
            // 
            Avatar.BackgroundImageLayout = ImageLayout.Stretch;
            Avatar.Location = new Point(71, 12);
            Avatar.Name = "Avatar";
            Avatar.Size = new Size(140, 140);
            Avatar.SizeMode = PictureBoxSizeMode.Zoom;
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
            toppanel.Location = new Point(300, 0);
            toppanel.Name = "toppanel";
            toppanel.Size = new Size(1042, 150);
            toppanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.search;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(942, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 52);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // searchtb
            // 
            searchtb.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtb.ForeColor = Color.CadetBlue;
            searchtb.Location = new Point(191, 60);
            searchtb.Name = "searchtb";
            searchtb.Size = new Size(726, 43);
            searchtb.TabIndex = 1;
            searchtb.Text = "";
            // 
            // logo
            // 
            logo.Image = Properties.Resources.UITFLIX;
            logo.Location = new Point(27, 12);
            logo.Name = "logo";
            logo.Size = new Size(139, 135);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // btnchoosefile
            // 
            btnchoosefile.Cursor = Cursors.Hand;
            btnchoosefile.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnchoosefile.ForeColor = Color.MidnightBlue;
            btnchoosefile.Location = new Point(334, 170);
            btnchoosefile.Name = "btnchoosefile";
            btnchoosefile.Size = new Size(167, 45);
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
            fileimage.Location = new Point(1044, 176);
            fileimage.Name = "fileimage";
            fileimage.Size = new Size(76, 28);
            fileimage.TabIndex = 22;
            fileimage.Text = "label1";
            fileimage.Visible = false;
            // 
            // chat
            // 
            chat.BackgroundImage = Properties.Resources._5962463;
            chat.BackgroundImageLayout = ImageLayout.Zoom;
            chat.Cursor = Cursors.Hand;
            chat.Location = new Point(983, 9);
            chat.Name = "chat";
            chat.Size = new Size(47, 30);
            chat.TabIndex = 2;
            chat.TabStop = false;
            // 
            // picfilm1
            // 
            picfilm1.BackColor = SystemColors.ButtonHighlight;
            picfilm1.Cursor = Cursors.Hand;
            picfilm1.Location = new Point(394, 194);
            picfilm1.Name = "picfilm1";
            picfilm1.Size = new Size(150, 150);
            picfilm1.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm1.TabIndex = 3;
            picfilm1.TabStop = false;
            picfilm1.Visible = false;
            // 
            // picfilm2
            // 
            picfilm2.BackColor = SystemColors.ButtonHighlight;
            picfilm2.Cursor = Cursors.Hand;
            picfilm2.Location = new Point(739, 194);
            picfilm2.Name = "picfilm2";
            picfilm2.Size = new Size(150, 150);
            picfilm2.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm2.TabIndex = 4;
            picfilm2.TabStop = false;
            picfilm2.Visible = false;
            // 
            // picfilm3
            // 
            picfilm3.BackColor = SystemColors.ButtonHighlight;
            picfilm3.Cursor = Cursors.Hand;
            picfilm3.Location = new Point(1105, 194);
            picfilm3.Name = "picfilm3";
            picfilm3.Size = new Size(150, 150);
            picfilm3.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm3.TabIndex = 5;
            picfilm3.TabStop = false;
            picfilm3.Visible = false;
            // 
            // picfilm6
            // 
            picfilm6.BackColor = SystemColors.ButtonHighlight;
            picfilm6.Cursor = Cursors.Hand;
            picfilm6.Location = new Point(1105, 481);
            picfilm6.Name = "picfilm6";
            picfilm6.Size = new Size(150, 150);
            picfilm6.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm6.TabIndex = 8;
            picfilm6.TabStop = false;
            picfilm6.Visible = false;
            // 
            // picfilm5
            // 
            picfilm5.BackColor = SystemColors.ButtonHighlight;
            picfilm5.Cursor = Cursors.Hand;
            picfilm5.Location = new Point(739, 481);
            picfilm5.Name = "picfilm5";
            picfilm5.Size = new Size(150, 150);
            picfilm5.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm5.TabIndex = 7;
            picfilm5.TabStop = false;
            picfilm5.Visible = false;
            // 
            // picfilm4
            // 
            picfilm4.BackColor = SystemColors.ButtonHighlight;
            picfilm4.Cursor = Cursors.Hand;
            picfilm4.Location = new Point(394, 481);
            picfilm4.Name = "picfilm4";
            picfilm4.Size = new Size(150, 150);
            picfilm4.SizeMode = PictureBoxSizeMode.StretchImage;
            picfilm4.TabIndex = 6;
            picfilm4.TabStop = false;
            picfilm4.Visible = false;
            // 
            // filmname1
            // 
            filmname1.AutoSize = true;
            filmname1.Cursor = Cursors.Hand;
            filmname1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filmname1.ForeColor = SystemColors.ButtonHighlight;
            filmname1.Location = new Point(394, 347);
            filmname1.Name = "filmname1";
            filmname1.Size = new Size(62, 23);
            filmname1.TabIndex = 9;
            filmname1.Text = "label1";
            filmname1.Visible = false;
            // 
            // event1
            // 
            event1.AutoSize = true;
            event1.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event1.ForeColor = SystemColors.ButtonHighlight;
            event1.Location = new Point(394, 381);
            event1.Name = "event1";
            event1.Size = new Size(62, 23);
            event1.TabIndex = 10;
            event1.Text = "label2";
            event1.Visible = false;
            // 
            // event2
            // 
            event2.AutoSize = true;
            event2.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event2.ForeColor = SystemColors.ButtonHighlight;
            event2.Location = new Point(739, 381);
            event2.Name = "event2";
            event2.Size = new Size(62, 23);
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
            filmname2.Location = new Point(739, 347);
            filmname2.Name = "filmname2";
            filmname2.Size = new Size(62, 23);
            filmname2.TabIndex = 11;
            filmname2.Text = "label4";
            filmname2.Visible = false;
            // 
            // event3
            // 
            event3.AutoSize = true;
            event3.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event3.ForeColor = SystemColors.ButtonHighlight;
            event3.Location = new Point(1105, 381);
            event3.Name = "event3";
            event3.Size = new Size(62, 23);
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
            filmname3.Location = new Point(1105, 347);
            filmname3.Name = "filmname3";
            filmname3.Size = new Size(62, 23);
            filmname3.TabIndex = 13;
            filmname3.Text = "label6";
            filmname3.Visible = false;
            // 
            // event4
            // 
            event4.AutoSize = true;
            event4.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event4.ForeColor = SystemColors.ButtonHighlight;
            event4.Location = new Point(394, 669);
            event4.Name = "event4";
            event4.Size = new Size(62, 23);
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
            filmname4.Location = new Point(394, 635);
            filmname4.Name = "filmname4";
            filmname4.Size = new Size(62, 23);
            filmname4.TabIndex = 15;
            filmname4.Text = "label8";
            filmname4.Visible = false;
            // 
            // event5
            // 
            event5.AutoSize = true;
            event5.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event5.ForeColor = SystemColors.ButtonHighlight;
            event5.Location = new Point(739, 669);
            event5.Name = "event5";
            event5.Size = new Size(62, 23);
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
            filmname5.Location = new Point(739, 635);
            filmname5.Name = "filmname5";
            filmname5.Size = new Size(73, 23);
            filmname5.TabIndex = 17;
            filmname5.Text = "label10";
            filmname5.Visible = false;
            // 
            // event6
            // 
            event6.AutoSize = true;
            event6.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            event6.ForeColor = SystemColors.ButtonHighlight;
            event6.Location = new Point(1105, 669);
            event6.Name = "event6";
            event6.Size = new Size(73, 23);
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
            filmname6.Location = new Point(1105, 635);
            filmname6.Name = "filmname6";
            filmname6.Size = new Size(73, 23);
            filmname6.TabIndex = 19;
            filmname6.Text = "label12";
            filmname6.Visible = false;
            // 
            // tenphim
            // 
            tenphim.AutoSize = true;
            tenphim.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tenphim.ForeColor = Color.MidnightBlue;
            tenphim.Location = new Point(394, 248);
            tenphim.Name = "tenphim";
            tenphim.Size = new Size(107, 28);
            tenphim.TabIndex = 23;
            tenphim.Text = "Tên phim";
            tenphim.Visible = false;
            // 
            // noidung
            // 
            noidung.AutoSize = true;
            noidung.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noidung.ForeColor = Color.MidnightBlue;
            noidung.Location = new Point(394, 315);
            noidung.Name = "noidung";
            noidung.Size = new Size(104, 28);
            noidung.TabIndex = 24;
            noidung.Text = "Nội dung";
            noidung.Visible = false;
            // 
            // tbnamefilm
            // 
            tbnamefilm.Font = new Font("Cambria", 11F);
            tbnamefilm.ForeColor = Color.MidnightBlue;
            tbnamefilm.Location = new Point(550, 248);
            tbnamefilm.Name = "tbnamefilm";
            tbnamefilm.Size = new Size(640, 33);
            tbnamefilm.TabIndex = 25;
            tbnamefilm.Visible = false;
            // 
            // tbdescription
            // 
            tbdescription.Font = new Font("Cambria", 11F);
            tbdescription.ForeColor = Color.MidnightBlue;
            tbdescription.Location = new Point(550, 320);
            tbdescription.Name = "tbdescription";
            tbdescription.Size = new Size(640, 260);
            tbdescription.TabIndex = 26;
            tbdescription.Text = "";
            tbdescription.Visible = false;
            // 
            // btnuploadvideo
            // 
            btnuploadvideo.Cursor = Cursors.Hand;
            btnuploadvideo.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnuploadvideo.ForeColor = Color.MidnightBlue;
            btnuploadvideo.Location = new Point(795, 597);
            btnuploadvideo.Name = "btnuploadvideo";
            btnuploadvideo.Size = new Size(167, 45);
            btnuploadvideo.TabIndex = 27;
            btnuploadvideo.Text = "Upload";
            btnuploadvideo.UseVisualStyleBackColor = true;
            btnuploadvideo.Visible = false;
            btnuploadvideo.Click += btnuploadvideo_Click;
            // 
            // progressupload
            // 
            progressupload.Location = new Point(6, 9);
            progressupload.Name = "progressupload";
            progressupload.Size = new Size(640, 29);
            progressupload.TabIndex = 28;
            // 
            // tbidroom
            // 
            tbidroom.Font = new Font("Cambria", 11F);
            tbidroom.ForeColor = Color.MidnightBlue;
            tbidroom.Location = new Point(632, 359);
            tbidroom.Name = "tbidroom";
            tbidroom.Size = new Size(417, 33);
            tbidroom.TabIndex = 29;
            tbidroom.Visible = false;
            // 
            // idroom
            // 
            idroom.AutoSize = true;
            idroom.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idroom.ForeColor = Color.MidnightBlue;
            idroom.Location = new Point(785, 314);
            idroom.Name = "idroom";
            idroom.Size = new Size(108, 28);
            idroom.TabIndex = 30;
            idroom.Text = "ID ROOM";
            idroom.Visible = false;
            // 
            // btnidroom
            // 
            btnidroom.Cursor = Cursors.Hand;
            btnidroom.Font = new Font("Cambria", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnidroom.ForeColor = Color.MidnightBlue;
            btnidroom.Location = new Point(762, 408);
            btnidroom.Name = "btnidroom";
            btnidroom.Size = new Size(176, 45);
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
            linkcreateroom.Location = new Point(327, 735);
            linkcreateroom.Name = "linkcreateroom";
            linkcreateroom.Size = new Size(171, 23);
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
            btnchooseimage.Location = new Point(837, 169);
            btnchooseimage.Name = "btnchooseimage";
            btnchooseimage.Size = new Size(167, 45);
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
            filevideo.Location = new Point(549, 177);
            filevideo.Name = "filevideo";
            filevideo.Size = new Size(76, 28);
            filevideo.TabIndex = 34;
            filevideo.Text = "label1";
            filevideo.Visible = false;
            // 
            // information
            // 
            information.AutoSize = true;
            information.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            information.ForeColor = SystemColors.ButtonHighlight;
            information.Location = new Point(327, 169);
            information.Name = "information";
            information.Size = new Size(297, 28);
            information.TabIndex = 35;
            information.Text = "Hiện tại chưa có video nào...";
            information.Visible = false;
            // 
            // bottompanel
            // 
            bottompanel.BackColor = Color.PowderBlue;
            bottompanel.Controls.Add(waiting);
            bottompanel.Controls.Add(progressupload);
            bottompanel.Controls.Add(chat);
            bottompanel.Dock = DockStyle.Bottom;
            bottompanel.Location = new Point(300, 725);
            bottompanel.Name = "bottompanel";
            bottompanel.Size = new Size(1042, 44);
            bottompanel.TabIndex = 36;
            // 
            // waiting
            // 
            waiting.AutoSize = true;
            waiting.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            waiting.ForeColor = Color.MidnightBlue;
            waiting.Location = new Point(6, 15);
            waiting.Name = "waiting";
            waiting.Size = new Size(170, 23);
            waiting.TabIndex = 29;
            waiting.Text = "Waiting for video...";
            waiting.Visible = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1342, 769);
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
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
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
    }
}
