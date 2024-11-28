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
            tab1 = new TabControl();
            tabEmail = new TabPage();
            lblName = new Label();
            btnReload = new Button();
            dgvEmail = new DataGridView();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            tabUser = new TabPage();
            label1 = new Label();
            button1 = new Button();
            dgvUsers = new DataGridView();
            ColID = new DataGridViewTextBoxColumn();
            ColFullname = new DataGridViewTextBoxColumn();
            ColUsername = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColIsonline = new DataGridViewTextBoxColumn();
            tabVideo = new TabPage();
            label2 = new Label();
            button2 = new Button();
            dgvVideo = new DataGridView();
            CoIVideoID = new DataGridViewTextBoxColumn();
            ColTag = new DataGridViewTextBoxColumn();
            ColVideoName = new DataGridViewTextBoxColumn();
            ColDate = new DataGridViewTextBoxColumn();
            tab1.SuspendLayout();
            tabEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmail).BeginInit();
            tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideo).BeginInit();
            SuspendLayout();
            // 
            // tab1
            // 
            tab1.Controls.Add(tabEmail);
            tab1.Controls.Add(tabUser);
            tab1.Controls.Add(tabVideo);
            tab1.Dock = DockStyle.Fill;
            tab1.Location = new Point(0, 0);
            tab1.Name = "tab1";
            tab1.SelectedIndex = 0;
            tab1.Size = new Size(1188, 751);
            tab1.TabIndex = 1;
            tab1.Tag = "";
            // 
            // tabEmail
            // 
            tabEmail.BackColor = Color.Azure;
            tabEmail.Controls.Add(lblName);
            tabEmail.Controls.Add(btnReload);
            tabEmail.Controls.Add(dgvEmail);
            tabEmail.Location = new Point(4, 34);
            tabEmail.Name = "tabEmail";
            tabEmail.Padding = new Padding(3);
            tabEmail.Size = new Size(1180, 713);
            tabEmail.TabIndex = 0;
            tabEmail.Text = "Emails";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.DarkCyan;
            lblName.Location = new Point(3, 3);
            lblName.Name = "lblName";
            lblName.Size = new Size(112, 32);
            lblName.TabIndex = 4;
            lblName.Text = "Welcom,";
            // 
            // btnReload
            // 
            btnReload.BackColor = SystemColors.ButtonFace;
            btnReload.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReload.ForeColor = SystemColors.ActiveCaptionText;
            btnReload.Location = new Point(1029, 18);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(124, 46);
            btnReload.TabIndex = 3;
            btnReload.Text = "ReLoad";
            btnReload.UseVisualStyleBackColor = false;
            // 
            // dgvEmail
            // 
            dgvEmail.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEmail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmail.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column4 });
            dgvEmail.Dock = DockStyle.Bottom;
            dgvEmail.GridColor = Color.White;
            dgvEmail.Location = new Point(3, 98);
            dgvEmail.Name = "dgvEmail";
            dgvEmail.RowHeadersWidth = 62;
            dgvEmail.Size = new Size(1174, 612);
            dgvEmail.TabIndex = 1;
            // 
            // Column2
            // 
            Column2.HeaderText = "From";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 300;
            // 
            // Column3
            // 
            Column3.HeaderText = "Subject";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 400;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "DateTime";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // tabUser
            // 
            tabUser.BackColor = Color.Azure;
            tabUser.Controls.Add(label1);
            tabUser.Controls.Add(button1);
            tabUser.Controls.Add(dgvUsers);
            tabUser.Location = new Point(4, 34);
            tabUser.Name = "tabUser";
            tabUser.Padding = new Padding(3);
            tabUser.Size = new Size(1180, 713);
            tabUser.TabIndex = 1;
            tabUser.Text = "Users ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(112, 32);
            label1.TabIndex = 5;
            label1.Text = "Welcom,";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(1029, 28);
            button1.Name = "button1";
            button1.Size = new Size(124, 46);
            button1.TabIndex = 4;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { ColID, ColFullname, ColUsername, ColEmail, ColIsonline });
            dgvUsers.Dock = DockStyle.Bottom;
            dgvUsers.GridColor = Color.White;
            dgvUsers.Location = new Point(3, 98);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1174, 612);
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
            tabVideo.Controls.Add(label2);
            tabVideo.Controls.Add(button2);
            tabVideo.Controls.Add(dgvVideo);
            tabVideo.Location = new Point(4, 34);
            tabVideo.Name = "tabVideo";
            tabVideo.Padding = new Padding(3);
            tabVideo.Size = new Size(1180, 713);
            tabVideo.TabIndex = 2;
            tabVideo.Text = "Videos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(112, 32);
            label2.TabIndex = 6;
            label2.Text = "Welcom,";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(1027, 21);
            button2.Name = "button2";
            button2.Size = new Size(124, 46);
            button2.TabIndex = 5;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            // 
            // dgvVideo
            // 
            dgvVideo.BackgroundColor = SystemColors.ButtonHighlight;
            dgvVideo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVideo.Columns.AddRange(new DataGridViewColumn[] { CoIVideoID, ColTag, ColVideoName, ColDate });
            dgvVideo.Dock = DockStyle.Bottom;
            dgvVideo.GridColor = Color.White;
            dgvVideo.Location = new Point(3, 98);
            dgvVideo.Name = "dgvVideo";
            dgvVideo.RowHeadersWidth = 62;
            dgvVideo.Size = new Size(1174, 612);
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
            // Admin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(1188, 751);
            Controls.Add(tab1);
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            tab1.ResumeLayout(false);
            tabEmail.ResumeLayout(false);
            tabEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmail).EndInit();
            tabUser.ResumeLayout(false);
            tabUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabVideo.ResumeLayout(false);
            tabVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tab1;
        private TabPage tabEmail;
        private TabPage tabUser;
        private TabPage tabVideo;
        private DataGridView dgvEmail;
        private Button btnSend;
        private Button btnLogout;
        private Button btnReload;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button1;
        private DataGridViewTextBoxColumn ColID;
        private DataGridViewTextBoxColumn ColFullname;
        private DataGridViewTextBoxColumn ColUsername;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColIsonline;
        private Button button2;
        private DataGridView dgvVideo;
        private Label lblName;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn CoIVideoID;
        private DataGridViewTextBoxColumn ColTag;
        private DataGridViewTextBoxColumn ColVideoName;
        private DataGridViewTextBoxColumn ColDate;
    }
}