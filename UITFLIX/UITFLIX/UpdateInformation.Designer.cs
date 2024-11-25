namespace UITFLIX
{
    partial class UpdateInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateInformation));
            panel1 = new Panel();
            label3 = new Label();
            logo = new PictureBox();
            panel2 = new Panel();
            underlineinf = new Panel();
            underlinepass = new Panel();
            btnpass = new FontAwesome.Sharp.IconButton();
            btninformation = new FontAwesome.Sharp.IconButton();
            Avatar = new PictureBox();
            lbFullname = new Label();
            lbBio = new Label();
            txtFullname = new TextBox();
            txtBio = new RichTextBox();
            btnSavePwd = new Button();
            lbOldpass = new Label();
            lbNewpass = new Label();
            lbcfpass = new Label();
            txtPass = new TextBox();
            txtNewPass = new TextBox();
            txtCfPass = new TextBox();
            btnChangeAva = new FontAwesome.Sharp.IconButton();
            btnUpdateInfo = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Avatar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(logo);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.CadetBlue;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(778, 62);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(69, 9);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(148, 38);
            label3.TabIndex = 1;
            label3.Text = "SETTINGS";
            // 
            // logo
            // 
            logo.Cursor = Cursors.WaitCursor;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(0, 0);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.Size = new Size(62, 62);
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.TabIndex = 0;
            logo.TabStop = false;
            logo.Click += logo_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(underlineinf);
            panel2.Controls.Add(underlinepass);
            panel2.Controls.Add(btnpass);
            panel2.Controls.Add(btninformation);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 62);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(778, 78);
            panel2.TabIndex = 1;
            // 
            // underlineinf
            // 
            underlineinf.BackColor = Color.DarkSlateGray;
            underlineinf.Location = new Point(0, 69);
            underlineinf.Margin = new Padding(2);
            underlineinf.Name = "underlineinf";
            underlineinf.Size = new Size(382, 10);
            underlineinf.TabIndex = 3;
            underlineinf.Visible = false;
            // 
            // underlinepass
            // 
            underlinepass.BackColor = Color.DarkSlateGray;
            underlinepass.Location = new Point(381, 69);
            underlinepass.Margin = new Padding(2);
            underlinepass.Name = "underlinepass";
            underlinepass.Size = new Size(401, 10);
            underlinepass.TabIndex = 2;
            underlinepass.Visible = false;
            // 
            // btnpass
            // 
            btnpass.BackColor = Color.White;
            btnpass.FlatAppearance.BorderSize = 0;
            btnpass.FlatStyle = FlatStyle.Flat;
            btnpass.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnpass.ForeColor = Color.CadetBlue;
            btnpass.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            btnpass.IconColor = Color.CadetBlue;
            btnpass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnpass.Location = new Point(381, 0);
            btnpass.Margin = new Padding(2);
            btnpass.Name = "btnpass";
            btnpass.Size = new Size(398, 78);
            btnpass.TabIndex = 1;
            btnpass.Text = "Password";
            btnpass.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnpass.UseVisualStyleBackColor = false;
            btnpass.Click += btnpass_Click;
            // 
            // btninformation
            // 
            btninformation.BackColor = Color.White;
            btninformation.FlatAppearance.BorderSize = 0;
            btninformation.FlatStyle = FlatStyle.Flat;
            btninformation.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btninformation.ForeColor = Color.CadetBlue;
            btninformation.IconChar = FontAwesome.Sharp.IconChar.User;
            btninformation.IconColor = Color.CadetBlue;
            btninformation.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btninformation.Location = new Point(0, 0);
            btninformation.Margin = new Padding(2);
            btninformation.Name = "btninformation";
            btninformation.Size = new Size(386, 78);
            btninformation.TabIndex = 0;
            btninformation.Text = "Information";
            btninformation.TextImageRelation = TextImageRelation.ImageBeforeText;
            btninformation.UseVisualStyleBackColor = false;
            btninformation.Click += btninformation_Click;
            // 
            // Avatar
            // 
            Avatar.Location = new Point(21, 191);
            Avatar.Margin = new Padding(2);
            Avatar.Name = "Avatar";
            Avatar.Size = new Size(170, 170);
            Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            Avatar.TabIndex = 2;
            Avatar.TabStop = false;
            Avatar.Visible = false;
            // 
            // lbFullname
            // 
            lbFullname.AutoSize = true;
            lbFullname.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFullname.ForeColor = Color.White;
            lbFullname.Location = new Point(215, 195);
            lbFullname.Margin = new Padding(2, 0, 2, 0);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(90, 23);
            lbFullname.TabIndex = 4;
            lbFullname.Text = "Fullname";
            lbFullname.Visible = false;
            // 
            // lbBio
            // 
            lbBio.AutoSize = true;
            lbBio.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBio.ForeColor = Color.White;
            lbBio.Location = new Point(215, 231);
            lbBio.Margin = new Padding(2, 0, 2, 0);
            lbBio.Name = "lbBio";
            lbBio.Size = new Size(39, 23);
            lbBio.TabIndex = 5;
            lbBio.Text = "Bio";
            lbBio.Visible = false;
            // 
            // txtFullname
            // 
            txtFullname.Font = new Font("Cambria", 10F);
            txtFullname.ForeColor = Color.CadetBlue;
            txtFullname.Location = new Point(311, 191);
            txtFullname.Margin = new Padding(2);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(413, 31);
            txtFullname.TabIndex = 6;
            txtFullname.Visible = false;
            // 
            // txtBio
            // 
            txtBio.Font = new Font("Cambria", 10F);
            txtBio.ForeColor = Color.CadetBlue;
            txtBio.Location = new Point(311, 231);
            txtBio.Margin = new Padding(2);
            txtBio.Name = "txtBio";
            txtBio.Size = new Size(413, 134);
            txtBio.TabIndex = 7;
            txtBio.Text = "";
            txtBio.Visible = false;
            txtBio.Enter += txtBio_Enter;
            // 
            // btnSavePwd
            // 
            btnSavePwd.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSavePwd.ForeColor = Color.DarkSlateGray;
            btnSavePwd.Location = new Point(566, 376);
            btnSavePwd.Margin = new Padding(2);
            btnSavePwd.Name = "btnSavePwd";
            btnSavePwd.Size = new Size(158, 34);
            btnSavePwd.TabIndex = 8;
            btnSavePwd.Text = "Save";
            btnSavePwd.UseVisualStyleBackColor = true;
            btnSavePwd.Visible = false;
            // 
            // lbOldpass
            // 
            lbOldpass.AutoSize = true;
            lbOldpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbOldpass.ForeColor = Color.White;
            lbOldpass.Location = new Point(21, 209);
            lbOldpass.Margin = new Padding(2, 0, 2, 0);
            lbOldpass.Name = "lbOldpass";
            lbOldpass.Size = new Size(127, 23);
            lbOldpass.TabIndex = 9;
            lbOldpass.Text = "Old password";
            lbOldpass.Visible = false;
            // 
            // lbNewpass
            // 
            lbNewpass.AutoSize = true;
            lbNewpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNewpass.ForeColor = Color.White;
            lbNewpass.Location = new Point(21, 249);
            lbNewpass.Margin = new Padding(2, 0, 2, 0);
            lbNewpass.Name = "lbNewpass";
            lbNewpass.Size = new Size(137, 23);
            lbNewpass.TabIndex = 10;
            lbNewpass.Text = "New password";
            lbNewpass.Visible = false;
            // 
            // lbcfpass
            // 
            lbcfpass.AutoSize = true;
            lbcfpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbcfpass.ForeColor = Color.White;
            lbcfpass.Location = new Point(21, 295);
            lbcfpass.Margin = new Padding(2, 0, 2, 0);
            lbcfpass.Name = "lbcfpass";
            lbcfpass.Size = new Size(208, 23);
            lbcfpass.TabIndex = 11;
            lbcfpass.Text = "Confirm new password";
            lbcfpass.Visible = false;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Cambria", 10F);
            txtPass.ForeColor = Color.CadetBlue;
            txtPass.Location = new Point(265, 206);
            txtPass.Margin = new Padding(2);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(459, 31);
            txtPass.TabIndex = 12;
            txtPass.Visible = false;
            // 
            // txtNewPass
            // 
            txtNewPass.Font = new Font("Cambria", 10F);
            txtNewPass.ForeColor = Color.CadetBlue;
            txtNewPass.Location = new Point(265, 246);
            txtNewPass.Margin = new Padding(2);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(459, 31);
            txtNewPass.TabIndex = 13;
            txtNewPass.Visible = false;
            // 
            // txtCfPass
            // 
            txtCfPass.Font = new Font("Cambria", 10F);
            txtCfPass.ForeColor = Color.CadetBlue;
            txtCfPass.Location = new Point(265, 292);
            txtCfPass.Margin = new Padding(2);
            txtCfPass.Name = "txtCfPass";
            txtCfPass.Size = new Size(459, 31);
            txtCfPass.TabIndex = 14;
            txtCfPass.Visible = false;
            // 
            // btnChangeAva
            // 
            btnChangeAva.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeAva.ForeColor = Color.CadetBlue;
            btnChangeAva.IconChar = FontAwesome.Sharp.IconChar.None;
            btnChangeAva.IconColor = Color.Black;
            btnChangeAva.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChangeAva.Location = new Point(21, 372);
            btnChangeAva.Margin = new Padding(2);
            btnChangeAva.Name = "btnChangeAva";
            btnChangeAva.Size = new Size(170, 34);
            btnChangeAva.TabIndex = 15;
            btnChangeAva.Text = "Change Avatar";
            btnChangeAva.UseVisualStyleBackColor = true;
            btnChangeAva.Click += btnChangeAva_Click;
            // 
            // btnUpdateInfo
            // 
            btnUpdateInfo.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateInfo.ForeColor = Color.DarkSlateGray;
            btnUpdateInfo.Location = new Point(566, 376);
            btnUpdateInfo.Margin = new Padding(2);
            btnUpdateInfo.Name = "btnUpdateInfo";
            btnUpdateInfo.Size = new Size(158, 34);
            btnUpdateInfo.TabIndex = 16;
            btnUpdateInfo.Text = "Update";
            btnUpdateInfo.UseVisualStyleBackColor = true;
            btnUpdateInfo.Visible = false;
            btnUpdateInfo.Click += btnUpdateInfo_Click;
            // 
            // UpdateInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(778, 422);
            Controls.Add(btnUpdateInfo);
            Controls.Add(btnChangeAva);
            Controls.Add(txtCfPass);
            Controls.Add(txtNewPass);
            Controls.Add(txtPass);
            Controls.Add(lbcfpass);
            Controls.Add(lbNewpass);
            Controls.Add(lbOldpass);
            Controls.Add(btnSavePwd);
            Controls.Add(txtBio);
            Controls.Add(txtFullname);
            Controls.Add(lbBio);
            Controls.Add(lbFullname);
            Controls.Add(Avatar);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.LightBlue;
            Margin = new Padding(2);
            Name = "UpdateInformation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateInformation";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Avatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnpass;
        private FontAwesome.Sharp.IconButton btninformation;
        private Panel underlineinf;
        private Panel underlinepass;
        private PictureBox Avatar;
        private Label lbFullname;
        private Label lbBio;
        private TextBox txtFullname;
        private RichTextBox txtBio;
        private Button btnSavePwd;
        private Label label3;
        private PictureBox logo;
        private Label lbOldpass;
        private Label lbNewpass;
        private Label lbcfpass;
        private TextBox txtPass;
        private TextBox txtNewPass;
        private TextBox txtCfPass;
        private FontAwesome.Sharp.IconButton btnChangeAva;
        private Button btnUpdateInfo;
    }
}