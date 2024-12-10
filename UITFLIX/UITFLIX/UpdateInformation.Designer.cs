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
            panel1.Size = new Size(622, 50);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(55, 7);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(125, 32);
            label3.TabIndex = 1;
            label3.Text = "SETTINGS";
            // 
            // logo
            // 
            logo.Cursor = Cursors.Hand;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(0, 0);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.Size = new Size(50, 50);
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
            panel2.Location = new Point(0, 50);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(622, 62);
            panel2.TabIndex = 1;
            // 
            // underlineinf
            // 
            underlineinf.BackColor = Color.DarkSlateGray;
            underlineinf.Location = new Point(0, 55);
            underlineinf.Margin = new Padding(2);
            underlineinf.Name = "underlineinf";
            underlineinf.Size = new Size(306, 8);
            underlineinf.TabIndex = 3;
            underlineinf.Visible = false;
            // 
            // underlinepass
            // 
            underlinepass.BackColor = Color.DarkSlateGray;
            underlinepass.Location = new Point(305, 55);
            underlinepass.Margin = new Padding(2);
            underlinepass.Name = "underlinepass";
            underlinepass.Size = new Size(321, 8);
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
            btnpass.Location = new Point(305, 0);
            btnpass.Margin = new Padding(2);
            btnpass.Name = "btnpass";
            btnpass.Size = new Size(318, 62);
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
            btninformation.Size = new Size(309, 62);
            btninformation.TabIndex = 0;
            btninformation.Text = "Information";
            btninformation.TextImageRelation = TextImageRelation.ImageBeforeText;
            btninformation.UseVisualStyleBackColor = false;
            btninformation.Click += btninformation_Click;
            // 
            // Avatar
            // 
            Avatar.Location = new Point(17, 153);
            Avatar.Margin = new Padding(2);
            Avatar.Name = "Avatar";
            Avatar.Size = new Size(136, 136);
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
            lbFullname.Location = new Point(172, 156);
            lbFullname.Margin = new Padding(2, 0, 2, 0);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(76, 20);
            lbFullname.TabIndex = 4;
            lbFullname.Text = "Fullname";
            lbFullname.Visible = false;
            // 
            // lbBio
            // 
            lbBio.AutoSize = true;
            lbBio.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBio.ForeColor = Color.White;
            lbBio.Location = new Point(172, 185);
            lbBio.Margin = new Padding(2, 0, 2, 0);
            lbBio.Name = "lbBio";
            lbBio.Size = new Size(33, 20);
            lbBio.TabIndex = 5;
            lbBio.Text = "Bio";
            lbBio.Visible = false;
            // 
            // txtFullname
            // 
            txtFullname.Font = new Font("Cambria", 10F);
            txtFullname.ForeColor = Color.CadetBlue;
            txtFullname.Location = new Point(249, 153);
            txtFullname.Margin = new Padding(2);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(331, 27);
            txtFullname.TabIndex = 6;
            txtFullname.Visible = false;
            // 
            // txtBio
            // 
            txtBio.Font = new Font("Cambria", 10F);
            txtBio.ForeColor = Color.CadetBlue;
            txtBio.Location = new Point(249, 185);
            txtBio.Margin = new Padding(2);
            txtBio.Name = "txtBio";
            txtBio.Size = new Size(331, 108);
            txtBio.TabIndex = 7;
            txtBio.Text = "";
            txtBio.Visible = false;
            // 
            // btnSavePwd
            // 
            btnSavePwd.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSavePwd.ForeColor = Color.DarkSlateGray;
            btnSavePwd.Location = new Point(453, 301);
            btnSavePwd.Margin = new Padding(2);
            btnSavePwd.Name = "btnSavePwd";
            btnSavePwd.Size = new Size(126, 27);
            btnSavePwd.TabIndex = 8;
            btnSavePwd.Text = "Save";
            btnSavePwd.UseVisualStyleBackColor = true;
            btnSavePwd.Visible = false;
            btnSavePwd.Click += btnSavePwd_Click;
            // 
            // lbOldpass
            // 
            lbOldpass.AutoSize = true;
            lbOldpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbOldpass.ForeColor = Color.White;
            lbOldpass.Location = new Point(17, 167);
            lbOldpass.Margin = new Padding(2, 0, 2, 0);
            lbOldpass.Name = "lbOldpass";
            lbOldpass.Size = new Size(107, 20);
            lbOldpass.TabIndex = 9;
            lbOldpass.Text = "Old password";
            lbOldpass.Visible = false;
            // 
            // lbNewpass
            // 
            lbNewpass.AutoSize = true;
            lbNewpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNewpass.ForeColor = Color.White;
            lbNewpass.Location = new Point(17, 199);
            lbNewpass.Margin = new Padding(2, 0, 2, 0);
            lbNewpass.Name = "lbNewpass";
            lbNewpass.Size = new Size(115, 20);
            lbNewpass.TabIndex = 10;
            lbNewpass.Text = "New password";
            lbNewpass.Visible = false;
            // 
            // lbcfpass
            // 
            lbcfpass.AutoSize = true;
            lbcfpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbcfpass.ForeColor = Color.White;
            lbcfpass.Location = new Point(17, 236);
            lbcfpass.Margin = new Padding(2, 0, 2, 0);
            lbcfpass.Name = "lbcfpass";
            lbcfpass.Size = new Size(175, 20);
            lbcfpass.TabIndex = 11;
            lbcfpass.Text = "Confirm new password";
            lbcfpass.Visible = false;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Cambria", 10F);
            txtPass.ForeColor = Color.CadetBlue;
            txtPass.Location = new Point(212, 165);
            txtPass.Margin = new Padding(2);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(368, 27);
            txtPass.TabIndex = 12;
            txtPass.Visible = false;
            txtPass.Enter += txtPass_Enter;
            txtPass.Leave += txtPass_Leave;
            // 
            // txtNewPass
            // 
            txtNewPass.Font = new Font("Cambria", 10F);
            txtNewPass.ForeColor = Color.CadetBlue;
            txtNewPass.Location = new Point(212, 197);
            txtNewPass.Margin = new Padding(2);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(368, 27);
            txtNewPass.TabIndex = 13;
            txtNewPass.Visible = false;
            txtNewPass.Enter += txtNewPass_Enter;
            txtNewPass.Leave += txtNewPass_Leave;
            // 
            // txtCfPass
            // 
            txtCfPass.Font = new Font("Cambria", 10F);
            txtCfPass.ForeColor = Color.CadetBlue;
            txtCfPass.Location = new Point(212, 234);
            txtCfPass.Margin = new Padding(2);
            txtCfPass.Name = "txtCfPass";
            txtCfPass.Size = new Size(368, 27);
            txtCfPass.TabIndex = 14;
            txtCfPass.Visible = false;
            txtCfPass.Enter += txtCfPass_Enter;
            txtCfPass.Leave += txtCfPass_Leave;
            // 
            // btnChangeAva
            // 
            btnChangeAva.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangeAva.ForeColor = Color.CadetBlue;
            btnChangeAva.IconChar = FontAwesome.Sharp.IconChar.None;
            btnChangeAva.IconColor = Color.Black;
            btnChangeAva.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChangeAva.Location = new Point(17, 298);
            btnChangeAva.Margin = new Padding(2);
            btnChangeAva.Name = "btnChangeAva";
            btnChangeAva.Size = new Size(136, 27);
            btnChangeAva.TabIndex = 15;
            btnChangeAva.Text = "Change Avatar";
            btnChangeAva.UseVisualStyleBackColor = true;
            btnChangeAva.Click += btnChangeAva_Click;
            // 
            // btnUpdateInfo
            // 
            btnUpdateInfo.Font = new Font("Cambria", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateInfo.ForeColor = Color.DarkSlateGray;
            btnUpdateInfo.Location = new Point(453, 301);
            btnUpdateInfo.Margin = new Padding(2);
            btnUpdateInfo.Name = "btnUpdateInfo";
            btnUpdateInfo.Size = new Size(126, 27);
            btnUpdateInfo.TabIndex = 16;
            btnUpdateInfo.Text = "Update";
            btnUpdateInfo.UseVisualStyleBackColor = true;
            btnUpdateInfo.Visible = false;
            btnUpdateInfo.Click += btnUpdateInfo_Click;
            // 
            // UpdateInformation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(622, 338);
            Controls.Add(btnChangeAva);
            Controls.Add(txtCfPass);
            Controls.Add(txtNewPass);
            Controls.Add(txtPass);
            Controls.Add(lbcfpass);
            Controls.Add(lbNewpass);
            Controls.Add(lbOldpass);
            Controls.Add(txtBio);
            Controls.Add(txtFullname);
            Controls.Add(lbBio);
            Controls.Add(lbFullname);
            Controls.Add(Avatar);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnUpdateInfo);
            Controls.Add(btnSavePwd);
            ForeColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.None;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
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