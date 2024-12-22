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
            richTextBoxBody = new RichTextBox();
            buttonSend = new Button();
            progressBar = new ProgressBar();
            textBoxEmailPassword = new TextBox();
            label2 = new Label();
            iconEye = new FontAwesome.Sharp.IconPictureBox();
            iconUpload = new FontAwesome.Sharp.IconPictureBox();
            linkinstruction = new LinkLabel();
            textBoxAttachmentPath = new TextBox();
            abovepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconEye).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconUpload).BeginInit();
            SuspendLayout();
            // 
            // abovepanel
            // 
            abovepanel.BackColor = Color.PowderBlue;
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
            textBoxName.Size = new Size(346, 29);
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
            textBoxEmail.Size = new Size(346, 29);
            textBoxEmail.TabIndex = 9;
            // 
            // textBoxSubject
            // 
            textBoxSubject.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSubject.ForeColor = Color.MidnightBlue;
            textBoxSubject.Location = new Point(225, 239);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(346, 29);
            textBoxSubject.TabIndex = 10;
            // 
            // richTextBoxBody
            // 
            richTextBoxBody.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxBody.ForeColor = Color.MidnightBlue;
            richTextBoxBody.Location = new Point(225, 293);
            richTextBoxBody.Name = "richTextBoxBody";
            richTextBoxBody.Size = new Size(346, 166);
            richTextBoxBody.TabIndex = 13;
            richTextBoxBody.Text = "";
            // 
            // buttonSend
            // 
            buttonSend.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSend.ForeColor = Color.MidnightBlue;
            buttonSend.Location = new Point(427, 538);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(144, 32);
            buttonSend.TabIndex = 15;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.CadetBlue;
            progressBar.Location = new Point(3, 598);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(633, 29);
            progressBar.TabIndex = 16;
            progressBar.Visible = false;
            // 
            // textBoxEmailPassword
            // 
            textBoxEmailPassword.BackColor = SystemColors.Window;
            textBoxEmailPassword.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmailPassword.ForeColor = Color.MidnightBlue;
            textBoxEmailPassword.Location = new Point(225, 193);
            textBoxEmailPassword.Name = "textBoxEmailPassword";
            textBoxEmailPassword.PasswordChar = '*';
            textBoxEmailPassword.Size = new Size(346, 29);
            textBoxEmailPassword.TabIndex = 34;
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
            // 
            // iconEye
            // 
            iconEye.BackColor = SystemColors.Window;
            iconEye.Cursor = Cursors.Hand;
            iconEye.ForeColor = Color.MidnightBlue;
            iconEye.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            iconEye.IconColor = Color.MidnightBlue;
            iconEye.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconEye.IconSize = 27;
            iconEye.Location = new Point(544, 193);
            iconEye.Name = "iconEye";
            iconEye.Size = new Size(27, 27);
            iconEye.TabIndex = 35;
            iconEye.TabStop = false;
            iconEye.Click += iconEye_Click;
            // 
            // iconUpload
            // 
            iconUpload.BackColor = Color.LightBlue;
            iconUpload.Cursor = Cursors.Hand;
            iconUpload.ForeColor = Color.MidnightBlue;
            iconUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            iconUpload.IconColor = Color.MidnightBlue;
            iconUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconUpload.IconSize = 28;
            iconUpload.Location = new Point(577, 492);
            iconUpload.Name = "iconUpload";
            iconUpload.Size = new Size(28, 28);
            iconUpload.TabIndex = 36;
            iconUpload.TabStop = false;
            iconUpload.Click += iconUpload_Click;
            // 
            // linkinstruction
            // 
            linkinstruction.AutoSize = true;
            linkinstruction.Font = new Font("Cambria", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkinstruction.LinkColor = Color.MidnightBlue;
            linkinstruction.Location = new Point(225, 545);
            linkinstruction.Name = "linkinstruction";
            linkinstruction.Size = new Size(188, 21);
            linkinstruction.TabIndex = 37;
            linkinstruction.TabStop = true;
            linkinstruction.Text = "How to get pass email?";
            linkinstruction.LinkClicked += linkinstruction_LinkClicked;
            // 
            // textBoxAttachmentPath
            // 
            textBoxAttachmentPath.BackColor = SystemColors.Control;
            textBoxAttachmentPath.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAttachmentPath.Location = new Point(225, 492);
            textBoxAttachmentPath.Name = "textBoxAttachmentPath";
            textBoxAttachmentPath.Size = new Size(346, 27);
            textBoxAttachmentPath.TabIndex = 38;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(633, 629);
            Controls.Add(textBoxAttachmentPath);
            Controls.Add(linkinstruction);
            Controls.Add(iconUpload);
            Controls.Add(iconEye);
            Controls.Add(textBoxEmailPassword);
            Controls.Add(label2);
            Controls.Add(progressBar);
            Controls.Add(buttonSend);
            Controls.Add(richTextBoxBody);
            Controls.Add(textBoxSubject);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Controls.Add(labelattachment);
            Controls.Add(labelmessage);
            Controls.Add(labelsubject);
            Controls.Add(labelemail);
            Controls.Add(labelname);
            Controls.Add(abovepanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Chat";
            Text = "Chat";
            Load += Chat_Load;
            abovepanel.ResumeLayout(false);
            abovepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconEye).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconUpload).EndInit();
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
        private RichTextBox richTextBoxBody;
        private Button buttonSend;
        private ProgressBar progressBar;
        private TextBox textBoxEmailPassword;
        private Label label2;
        private FontAwesome.Sharp.IconPictureBox iconEye;
        private FontAwesome.Sharp.IconPictureBox iconUpload;
        private LinkLabel linkinstruction;
        private TextBox textBoxAttachmentPath;
    }
}