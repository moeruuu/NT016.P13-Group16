namespace UITFLIX
{
    partial class EmailDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailDetails));
            panelInfo = new Panel();
            pbAvatar = new PictureBox();
            label1 = new Label();
            lbName = new Label();
            pbLogo = new PictureBox();
            logout = new PictureBox();
            labelFrom = new Label();
            labelSubject = new Label();
            webView2Body = new Microsoft.Web.WebView2.WinForms.WebView2();
            labelDate = new Label();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView2Body).BeginInit();
            SuspendLayout();
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
            panelInfo.Size = new Size(912, 81);
            panelInfo.TabIndex = 6;
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
            label1.BackColor = Color.CadetBlue;
            label1.Font = new Font("Palatino Linotype", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightBlue;
            label1.Location = new Point(82, 18);
            label1.Name = "label1";
            label1.Size = new Size(130, 46);
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
            // logout
            // 
            logout.BackColor = Color.Transparent;
            logout.Cursor = Cursors.Hand;
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(882, 571);
            logout.Margin = new Padding(2);
            logout.Name = "logout";
            logout.Size = new Size(30, 31);
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.TabIndex = 7;
            logout.TabStop = false;
            logout.Click += logout_Click;
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.BackColor = Color.Transparent;
            labelFrom.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFrom.ForeColor = Color.DarkCyan;
            labelFrom.Location = new Point(38, 102);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(59, 23);
            labelFrom.TabIndex = 8;
            labelFrom.Text = "From";
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.BackColor = Color.Transparent;
            labelSubject.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubject.ForeColor = Color.DarkCyan;
            labelSubject.Location = new Point(38, 139);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(77, 23);
            labelSubject.TabIndex = 9;
            labelSubject.Text = "Subject";
            // 
            // webView2Body
            // 
            webView2Body.AllowExternalDrop = true;
            webView2Body.CreationProperties = null;
            webView2Body.DefaultBackgroundColor = Color.White;
            webView2Body.ForeColor = Color.CadetBlue;
            webView2Body.Location = new Point(28, 215);
            webView2Body.Name = "webView2Body";
            webView2Body.Size = new Size(853, 344);
            webView2Body.TabIndex = 11;
            webView2Body.ZoomFactor = 1D;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.BackColor = Color.Transparent;
            labelDate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDate.ForeColor = Color.DarkCyan;
            labelDate.Location = new Point(38, 177);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(53, 23);
            labelDate.TabIndex = 12;
            labelDate.Text = "Date";
            // 
            // EmailDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(912, 604);
            ControlBox = false;
            Controls.Add(labelDate);
            Controls.Add(webView2Body);
            Controls.Add(labelSubject);
            Controls.Add(labelFrom);
            Controls.Add(logout);
            Controls.Add(panelInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmailDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Email Details";
            TransparencyKey = Color.Transparent;
            Load += EmailDetails_Load;
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView2Body).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelInfo;
        private PictureBox pbAvatar;
        private Label label1;
        private Label lbName;
        private PictureBox pbLogo;
        private PictureBox logout;
        private Label labelFrom;
        private Label labelSubject;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Body;
        private Label labelDate;
    }
}