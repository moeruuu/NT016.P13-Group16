﻿namespace UITFLIX
{
    partial class VerifyOTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyOTP));
            tbotp = new TextBox();
            label1 = new Label();
            btnverify = new Button();
            SuspendLayout();
            // 
            // tbotp
            // 
            tbotp.Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbotp.ForeColor = Color.FromArgb(0, 64, 64);
            tbotp.Location = new Point(83, 68);
            tbotp.Margin = new Padding(2, 2, 2, 2);
            tbotp.Name = "tbotp";
            tbotp.Size = new Size(315, 27);
            tbotp.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(83, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(51, 23);
            label1.TabIndex = 1;
            label1.Text = "OTP:";
            // 
            // btnverify
            // 
            btnverify.Font = new Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnverify.ForeColor = Color.FromArgb(0, 64, 64);
            btnverify.Location = new Point(156, 105);
            btnverify.Margin = new Padding(2, 2, 2, 2);
            btnverify.Name = "btnverify";
            btnverify.Size = new Size(190, 27);
            btnverify.TabIndex = 2;
            btnverify.Text = "Xác nhận";
            btnverify.UseVisualStyleBackColor = true;
            btnverify.Click += btnverify_Click;
            // 
            // VerifyOTP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(464, 170);
            Controls.Add(btnverify);
            Controls.Add(label1);
            Controls.Add(tbotp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "VerifyOTP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VerifyOTP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbotp;
        private Label label1;
        private Button btnverify;
    }
}