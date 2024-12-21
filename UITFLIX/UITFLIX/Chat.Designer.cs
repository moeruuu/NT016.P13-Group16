namespace UITFLIX
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            abovepanel = new Panel();
            logo = new PictureBox();
            label1 = new Label();
            labelname = new Label();
            labelemail = new Label();
            labelsubject = new Label();
            labelmessage = new Label();
            labelattachment = new Label();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxSubject = new TextBox();
            textBoxAttachmentPath = new TextBox();
            richTextBoxBody = new RichTextBox();
            buttonBrowse = new Button();
            buttonSend = new Button();
            progressBar = new ProgressBar();
            logout = new PictureBox();
            textBoxEmailPassword = new TextBox();
            label2 = new Label();
            iconEye = new FontAwesome.Sharp.IconPictureBox();
            abovepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconEye).BeginInit();
            SuspendLayout();
            // 
            // abovepanel
            // 
            abovepanel.Controls.Add(logo);
            abovepanel.Controls.Add(label1);
            abovepanel.Location = new Point(-1, -2);
            abovepanel.Name = "abovepanel";
            abovepanel.Size = new Size(633, 63);
            abovepanel.TabIndex = 0;
            // 
            // logo
            // 
            logo.Cursor = Cursors.Hand;
            logo.Image = Properties.Resources.UITFLIX;
            logo.Location = new Point(4, 2);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.Size = new Size(59, 61);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 3;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(68, 19);
            label1.Name = "label1";
            label1.Size = new Size(121, 27);
            label1.TabIndex = 2;
            label1.Text = "Contact us";
            // 
            // labelname
            // 
            labelname.AutoSize = true;
            labelname.BackColor = Color.Transparent;
            labelname.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelname.ForeColor = Color.MidnightBlue;
            labelname.Location = new Point(29, 91);
            labelname.Name = "labelname";
            labelname.Size = new Size(101, 23);
            labelname.TabIndex = 3;
            labelname.Text = "Your name";
            // 
            // labelemail
            // 
            labelemail.AutoSize = true;
            labelemail.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelemail.ForeColor = Color.MidnightBlue;
            labelemail.Location = new Point(29, 143);
            labelemail.Name = "labelemail";
            labelemail.Size = new Size(101, 23);
            labelemail.TabIndex = 4;
            labelemail.Text = "Your email";
            // 
            // labelsubject
            // 
            labelsubject.AutoSize = true;
            labelsubject.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelsubject.ForeColor = Color.MidnightBlue;
            labelsubject.Location = new Point(29, 241);
            labelsubject.Name = "labelsubject";
            labelsubject.Size = new Size(73, 23);
            labelsubject.TabIndex = 5;
            labelsubject.Text = "Subject";
            // 
            // labelmessage
            // 
            labelmessage.AutoSize = true;
            labelmessage.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelmessage.ForeColor = Color.MidnightBlue;
            labelmessage.Location = new Point(29, 295);
            labelmessage.Name = "labelmessage";
            labelmessage.Size = new Size(54, 23);
            labelmessage.TabIndex = 6;
            labelmessage.Text = "Body";
            // 
            // labelattachment
            // 
            labelattachment.AutoSize = true;
            labelattachment.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelattachment.ForeColor = Color.MidnightBlue;
            labelattachment.Location = new Point(34, 492);
            labelattachment.Name = "labelattachment";
            labelattachment.Size = new Size(111, 23);
            labelattachment.TabIndex = 7;
            labelattachment.Text = "Attachment";
            // 
            // textBoxName
            // 
            textBoxName.BackColor = SystemColors.Window;
            textBoxName.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxName.ForeColor = Color.MidnightBlue;
            textBoxName.Location = new Point(225, 90);
            textBoxName.Name = "textBoxName";
            textBoxName.ReadOnly = true;
            textBoxName.Size = new Size(279, 29);
            textBoxName.TabIndex = 8;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = SystemColors.Window;
            textBoxEmail.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmail.ForeColor = Color.MidnightBlue;
            textBoxEmail.Location = new Point(225, 142);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(279, 29);
            textBoxEmail.TabIndex = 9;
            // 
            // textBoxSubject
            // 
            textBoxSubject.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSubject.ForeColor = Color.MidnightBlue;
            textBoxSubject.Location = new Point(225, 239);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(279, 29);
            textBoxSubject.TabIndex = 10;
            // 
            // textBoxAttachmentPath
            // 
            textBoxAttachmentPath.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAttachmentPath.ForeColor = Color.MidnightBlue;
            textBoxAttachmentPath.Location = new Point(225, 491);
            textBoxAttachmentPath.Name = "textBoxAttachmentPath";
            textBoxAttachmentPath.ReadOnly = true;
            textBoxAttachmentPath.Size = new Size(279, 29);
            textBoxAttachmentPath.TabIndex = 12;
            // 
            // richTextBoxBody
            // 
            richTextBoxBody.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxBody.ForeColor = Color.MidnightBlue;
            richTextBoxBody.Location = new Point(225, 293);
            richTextBoxBody.Name = "richTextBoxBody";
            richTextBoxBody.Size = new Size(279, 166);
            richTextBoxBody.TabIndex = 13;
            richTextBoxBody.Text = "";
            // 
            // buttonBrowse
            // 
            buttonBrowse.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBrowse.ForeColor = Color.MidnightBlue;
            buttonBrowse.Location = new Point(527, 492);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(94, 29);
            buttonBrowse.TabIndex = 14;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // buttonSend
            // 
            buttonSend.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSend.ForeColor = Color.MidnightBlue;
            buttonSend.Location = new Point(225, 546);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(94, 29);
            buttonSend.TabIndex = 15;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.CadetBlue;
            progressBar.Location = new Point(-1, 609);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(585, 29);
            progressBar.TabIndex = 16;
            progressBar.Visible = false;
            // 
            // logout
            // 
            logout.Cursor = Cursors.Hand;
            logout.Image = (Image)resources.GetObject("logout.Image");
            logout.Location = new Point(586, 592);
            logout.Margin = new Padding(2);
            logout.Name = "logout";
            logout.Size = new Size(46, 46);
            logout.SizeMode = PictureBoxSizeMode.StretchImage;
            logout.TabIndex = 32;
            logout.TabStop = false;
            logout.Click += logout_Click;
            // 
            // textBoxEmailPassword
            // 
            textBoxEmailPassword.BackColor = SystemColors.Window;
            textBoxEmailPassword.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmailPassword.ForeColor = Color.MidnightBlue;
            textBoxEmailPassword.Location = new Point(225, 193);
            textBoxEmailPassword.Name = "textBoxEmailPassword";
            textBoxEmailPassword.Size = new Size(279, 29);
            textBoxEmailPassword.TabIndex = 34;
            textBoxEmailPassword.TextChanged += textBoxEmailPassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(29, 194);
            label2.Name = "label2";
            label2.Size = new Size(189, 23);
            label2.TabIndex = 33;
            label2.Text = "Your email password";
            label2.Click += label2_Click;
            // 
            // iconEye
            // 
            iconEye.BackColor = SystemColors.Window;
            iconEye.Cursor = Cursors.Hand;
            iconEye.ForeColor = Color.MidnightBlue;
            iconEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            iconEye.IconColor = Color.MidnightBlue;
            iconEye.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconEye.IconSize = 24;
            iconEye.Location = new Point(471, 193);
            iconEye.Name = "iconEye";
            iconEye.Size = new Size(33, 24);
            iconEye.TabIndex = 35;
            iconEye.TabStop = false;
            iconEye.Click += iconEye_Click;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(633, 639);
            ControlBox = false;
            Controls.Add(iconEye);
            Controls.Add(textBoxEmailPassword);
            Controls.Add(label2);
            Controls.Add(logout);
            Controls.Add(progressBar);
            Controls.Add(buttonSend);
            Controls.Add(buttonBrowse);
            Controls.Add(richTextBoxBody);
            Controls.Add(textBoxAttachmentPath);
            Controls.Add(textBoxSubject);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Controls.Add(labelattachment);
            Controls.Add(labelmessage);
            Controls.Add(labelsubject);
            Controls.Add(labelemail);
            Controls.Add(labelname);
            Controls.Add(abovepanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Chat";
            Text = "Chat";
            Load += Chat_Load;
            abovepanel.ResumeLayout(false);
            abovepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)logout).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconEye).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel abovepanel;
        private Label label1;
        private PictureBox logo;
        private Label labelname;
        private Label labelemail;
        private Label labelsubject;
        private Label labelmessage;
        private Label labelattachment;
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TextBox textBoxSubject;
        private TextBox textBoxAttachmentPath;
        private RichTextBox richTextBoxBody;
        private Button buttonBrowse;
        private Button buttonSend;
        private ProgressBar progressBar;
        private PictureBox logout;
        private TextBox textBoxEmailPassword;
        private Label label2;
        private FontAwesome.Sharp.IconPictureBox iconEye;
    }
}