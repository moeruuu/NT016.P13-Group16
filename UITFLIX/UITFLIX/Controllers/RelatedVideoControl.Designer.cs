namespace UITFLIX.Controllers
{
    partial class RelatedVideoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbImage = new PictureBox();
            lbTitle = new Label();
            lbRate = new Label();
            lbUploadDate = new Label();
            lbTag = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.Enabled = false;
            pbImage.Location = new Point(12, 3);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(120, 120);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Enabled = false;
            lbTitle.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.MidnightBlue;
            lbTitle.Location = new Point(141, 10);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(53, 23);
            lbTitle.TabIndex = 2;
            lbTitle.Text = "Title";
            // 
            // lbRate
            // 
            lbRate.AutoSize = true;
            lbRate.Enabled = false;
            lbRate.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbRate.ForeColor = Color.MidnightBlue;
            lbRate.Location = new Point(141, 40);
            lbRate.Name = "lbRate";
            lbRate.Size = new Size(36, 17);
            lbRate.TabIndex = 3;
            lbRate.Text = "Rate";
            // 
            // lbUploadDate
            // 
            lbUploadDate.AutoSize = true;
            lbUploadDate.Enabled = false;
            lbUploadDate.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUploadDate.ForeColor = Color.MidnightBlue;
            lbUploadDate.Location = new Point(141, 65);
            lbUploadDate.Name = "lbUploadDate";
            lbUploadDate.Size = new Size(74, 17);
            lbUploadDate.TabIndex = 4;
            lbUploadDate.Text = "UploaDate";
            // 
            // lbTag
            // 
            lbTag.AutoSize = true;
            lbTag.Enabled = false;
            lbTag.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTag.ForeColor = Color.MidnightBlue;
            lbTag.Location = new Point(141, 90);
            lbTag.Name = "lbTag";
            lbTag.Size = new Size(40, 17);
            lbTag.TabIndex = 5;
            lbTag.Text = "[Tag]";
            // 
            // RelatedVideoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lbTag);
            Controls.Add(lbUploadDate);
            Controls.Add(lbRate);
            Controls.Add(lbTitle);
            Controls.Add(pbImage);
            Cursor = Cursors.Hand;
            Name = "RelatedVideoControl";
            Size = new Size(326, 127);
            MouseEnter += RelatedVideoControl_MouseEnter;
            MouseLeave += RelatedVideoControl_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImage;
        private Label lbTitle;
        private Label lbRate;
        private Label lbUploadDate;
        private Label lbTag;
    }
}
