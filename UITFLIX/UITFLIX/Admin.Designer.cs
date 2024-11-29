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
            tab1 = new TabControl();
            tabEmail = new TabPage();
            btnReload = new Button();
            tabUser = new TabPage();
            btnDeleteUser = new Button();
            dgvUsers = new DataGridView();
            ColID = new DataGridViewTextBoxColumn();
            ColFullname = new DataGridViewTextBoxColumn();
            ColUsername = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColIsonline = new DataGridViewTextBoxColumn();
            tabVideo = new TabPage();
            btnDeleteVideo = new Button();
            dgvVideo = new DataGridView();
            CoIVideoID = new DataGridViewTextBoxColumn();
            ColTag = new DataGridViewTextBoxColumn();
            ColVideoName = new DataGridViewTextBoxColumn();
            ColDate = new DataGridViewTextBoxColumn();
            lblName = new Label();
            logout = new PictureBox();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            dgvEmail = new DataGridView();
            panel1 = new Panel();
            tab1.SuspendLayout();
            tabEmail.SuspendLayout();
            tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmail).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tab1
            // 
            tab1.Controls.Add(tabEmail);
            tab1.Controls.Add(tabUser);
            tab1.Controls.Add(tabVideo);
            tab1.Dock = DockStyle.Top;
            tab1.Location = new Point(0, 0);
            tab1.Name = "tab1";
            tab1.SelectedIndex = 0;
            tab1.Size = new Size(1188, 767);
            tab1.TabIndex = 1;
            tab1.Tag = "";
            // 
            // tabEmail
            // 
            tabEmail.BackColor = Color.Azure;
            tabEmail.Controls.Add(btnReload);
            tabEmail.Controls.Add(dgvEmail);
            tabEmail.Location = new Point(4, 34);
            tabEmail.Name = "tabEmail";
            tabEmail.Padding = new Padding(3);
            tabEmail.Size = new Size(1180, 729);
            tabEmail.TabIndex = 0;
            tabEmail.Text = "Emails";
            // 
            // btnReload
            // 
            btnReload.BackColor = SystemColors.ButtonHighlight;
            btnReload.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReload.ForeColor = Color.MidnightBlue;
            btnReload.Location = new Point(1048, 6);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(124, 38);
            btnReload.TabIndex = 3;
            btnReload.Text = "ReLoad";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // tabUser
            // 
            tabUser.BackColor = Color.Azure;
            tabUser.Controls.Add(btnDeleteUser);
            tabUser.Controls.Add(dgvUsers);
            tabUser.Location = new Point(4, 34);
            tabUser.Name = "tabUser";
            tabUser.Padding = new Padding(3);
            tabUser.Size = new Size(1180, 729);
            tabUser.TabIndex = 1;
            tabUser.Text = "Users ";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = SystemColors.ButtonHighlight;
            btnDeleteUser.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.ForeColor = Color.MidnightBlue;
            btnDeleteUser.Location = new Point(1048, 6);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(124, 38);
            btnDeleteUser.TabIndex = 4;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { ColID, ColFullname, ColUsername, ColEmail, ColIsonline });
            dgvUsers.Dock = DockStyle.Bottom;
            dgvUsers.GridColor = Color.White;
            dgvUsers.Location = new Point(3, 67);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1174, 659);
            dgvUsers.TabIndex = 2;
            // 
            // ColID
            // 
            ColID.HeaderText = "ID";
            ColID.MinimumWidth = 8;
            ColID.Name = "ColID";
            ColID.Width = 150;
            // 
            // ColFullname
            // 
            ColFullname.HeaderText = "Fullname";
            ColFullname.MinimumWidth = 8;
            ColFullname.Name = "ColFullname";
            ColFullname.Width = 200;
            // 
            // ColUsername
            // 
            ColUsername.HeaderText = "Username";
            ColUsername.MinimumWidth = 8;
            ColUsername.Name = "ColUsername";
            ColUsername.Width = 200;
            // 
            // ColEmail
            // 
            ColEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColEmail.HeaderText = "Email";
            ColEmail.MinimumWidth = 8;
            ColEmail.Name = "ColEmail";
            // 
            // ColIsonline
            // 
            ColIsonline.HeaderText = "IsOnline";
            ColIsonline.MinimumWidth = 8;
            ColIsonline.Name = "ColIsonline";
            ColIsonline.Width = 150;
            // 
            // tabVideo
            // 
            tabVideo.BackColor = Color.Azure;
            tabVideo.Controls.Add(btnDeleteVideo);
            tabVideo.Controls.Add(dgvVideo);
            tabVideo.Location = new Point(4, 34);
            tabVideo.Name = "tabVideo";
            tabVideo.Padding = new Padding(3);
            tabVideo.Size = new Size(1180, 729);
            tabVideo.TabIndex = 2;
            tabVideo.Text = "Videos";
            // 
            // btnDeleteVideo
            // 
            btnDeleteVideo.BackColor = SystemColors.ButtonHighlight;
            btnDeleteVideo.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteVideo.ForeColor = Color.MidnightBlue;
            btnDeleteVideo.Location = new Point(1048, 6);
            btnDeleteVideo.Name = "btnDeleteVideo";
            btnDeleteVideo.Size = new Size(124, 38);
            btnDeleteVideo.TabIndex = 5;
            btnDeleteVideo.Text = "Delete";
            btnDeleteVideo.UseVisualStyleBackColor = false;
            // 
            // dgvVideo
            // 
            dgvVideo.BackgroundColor = SystemColors.ButtonHighlight;
            dgvVideo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideo.Columns.AddRange(new DataGridViewColumn[] { CoIVideoID, ColTag, ColVideoName, ColDate });
            dgvVideo.Dock = DockStyle.Bottom;
            dgvVideo.GridColor = Color.White;
            dgvVideo.Location = new Point(3, 67);
            dgvVideo.Name = "dgvVideo";
            dgvVideo.RowHeadersWidth = 62;
            dgvVideo.Size = new Size(1174, 659);
            dgvVideo.TabIndex = 3;
            // 
            // CoIVideoID
            // 
            CoIVideoID.HeaderText = "ID";
            CoIVideoID.MinimumWidth = 8;
            CoIVideoID.Name = "CoIVideoID";
            CoIVideoID.Width = 150;
            // 
            // ColTag
            // 
            ColTag.HeaderText = "Tag";
            ColTag.MinimumWidth = 8;
            ColTag.Name = "ColTag";
            ColTag.Width = 150;
            // 
            // ColVideoName
            // 
            ColVideoName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColVideoName.HeaderText = "Video Name";
            ColVideoName.MinimumWidth = 8;
            ColVideoName.Name = "ColVideoName";
            // 
            // ColDate
            // 
            ColDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColDate.HeaderText = "Date";
            ColDate.MinimumWidth = 8;
            ColDate.Name = "ColDate";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.MidnightBlue;
            lblName.Location = new Point(12, 8);
            lblName.Name = "lblName";
            lblName.Size = new Size(97, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Welcome, ";
            // 
            // logout
            // 
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(1151, 7);
            logout.Name = "logout";
            logout.Size = new Size(30, 30);
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.TabIndex = 3;
            logout.TabStop = false;
            logout.Click += logout_Click;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "DateTime";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // Column3
            // 
            Column3.HeaderText = "Subject";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 400;
            // 
            // Column2
            // 
            Column2.HeaderText = "From";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 300;
            // 
            // dgvEmail
            // 
            dgvEmail.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEmail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmail.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column4 });
            dgvEmail.Dock = DockStyle.Bottom;
            dgvEmail.GridColor = Color.White;
            dgvEmail.Location = new Point(3, 67);
            dgvEmail.Name = "dgvEmail";
            dgvEmail.RowHeadersWidth = 62;
            dgvEmail.Size = new Size(1174, 659);
            dgvEmail.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightBlue;
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(logout);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 766);
            panel1.Name = "panel1";
            panel1.Size = new Size(1188, 40);
            panel1.TabIndex = 4;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1188, 806);
            Controls.Add(panel1);
            Controls.Add(tab1);
            Cursor = Cursors.Hand;
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            tab1.ResumeLayout(false);
            tabEmail.ResumeLayout(false);
            tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVideo).EndInit();
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmail).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tab1;
        private TabPage tabEmail;
        private TabPage tabUser;
        private TabPage tabVideo;
        private Button btnSend;
        private Button btnLogout;
        private Button btnReload;
        private DataGridView dgvUsers;
        private Button btnDeleteUser;
        private DataGridViewTextBoxColumn ColID;
        private DataGridViewTextBoxColumn ColFullname;
        private DataGridViewTextBoxColumn ColUsername;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColIsonline;
        private Button btnDeleteVideo;
        private DataGridView dgvVideo;
        private DataGridViewTextBoxColumn CoIVideoID;
        private DataGridViewTextBoxColumn ColTag;
        private DataGridViewTextBoxColumn ColVideoName;
        private DataGridViewTextBoxColumn ColDate;
        private Label lblName;
        private PictureBox logout;
        private DataGridView dgvEmail;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Panel panel1;
    }
}