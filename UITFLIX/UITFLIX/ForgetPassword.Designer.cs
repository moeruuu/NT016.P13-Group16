namespace UITFLIX
{
    partial class ForgetPassword
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
            txtCfPass = new TextBox();
            txtNewPass = new TextBox();
            txtEmail = new TextBox();
            lbcfpass = new Label();
            lbNewpass = new Label();
            lbEmail = new Label();
            btnSend = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtCfPass
            // 
            txtCfPass.Font = new Font("Cambria", 10F);
            txtCfPass.ForeColor = Color.CadetBlue;
            txtCfPass.Location = new Point(231, 105);
            txtCfPass.Margin = new Padding(2);
            txtCfPass.Name = "txtCfPass";
            txtCfPass.Size = new Size(368, 27);
            txtCfPass.TabIndex = 25;
            // 
            // txtNewPass
            // 
            txtNewPass.Font = new Font("Cambria", 10F);
            txtNewPass.ForeColor = Color.CadetBlue;
            txtNewPass.Location = new Point(231, 68);
            txtNewPass.Margin = new Padding(2);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(368, 27);
            txtNewPass.TabIndex = 24;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Cambria", 10F);
            txtEmail.ForeColor = Color.CadetBlue;
            txtEmail.Location = new Point(231, 36);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(368, 27);
            txtEmail.TabIndex = 23;
            // 
            // lbcfpass
            // 
            lbcfpass.AutoSize = true;
            lbcfpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbcfpass.ForeColor = Color.White;
            lbcfpass.Location = new Point(36, 107);
            lbcfpass.Margin = new Padding(2, 0, 2, 0);
            lbcfpass.Name = "lbcfpass";
            lbcfpass.Size = new Size(175, 20);
            lbcfpass.TabIndex = 22;
            lbcfpass.Text = "Confirm new password";
            // 
            // lbNewpass
            // 
            lbNewpass.AutoSize = true;
            lbNewpass.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNewpass.ForeColor = Color.White;
            lbNewpass.Location = new Point(36, 70);
            lbNewpass.Margin = new Padding(2, 0, 2, 0);
            lbNewpass.Name = "lbNewpass";
            lbNewpass.Size = new Size(115, 20);
            lbNewpass.TabIndex = 21;
            lbNewpass.Text = "New password";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.ForeColor = Color.White;
            lbEmail.Location = new Point(36, 38);
            lbEmail.Margin = new Padding(2, 0, 2, 0);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(51, 20);
            lbEmail.TabIndex = 20;
            lbEmail.Text = "Email";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(505, 143);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 26;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(390, 143);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ForgetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(641, 184);
            Controls.Add(btnCancel);
            Controls.Add(btnSend);
            Controls.Add(txtCfPass);
            Controls.Add(txtNewPass);
            Controls.Add(txtEmail);
            Controls.Add(lbcfpass);
            Controls.Add(lbNewpass);
            Controls.Add(lbEmail);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgetPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCfPass;
        private TextBox txtNewPass;
        private TextBox txtEmail;
        private Label lbcfpass;
        private Label lbNewpass;
        private Label lbEmail;
        private Button btnSend;
        private Button btnCancel;
    }
}