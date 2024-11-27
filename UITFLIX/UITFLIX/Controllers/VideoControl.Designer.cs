namespace UITFLIX.Controllers
{
    partial class VideoControl
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
            lbSub = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.Enabled = false;
            pbImage.Location = new Point(7, 3);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(160, 160);
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Enabled = false;
            lbTitle.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.MidnightBlue;
            lbTitle.Location = new Point(61, 166);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(53, 23);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "Title";
            // 
            // lbSub
            // 
            lbSub.AutoSize = true;
            lbSub.Enabled = false;
            lbSub.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSub.ForeColor = Color.MidnightBlue;
            lbSub.Location = new Point(71, 196);
            lbSub.Name = "lbSub";
            lbSub.Size = new Size(30, 17);
            lbSub.TabIndex = 2;
            lbSub.Text = "sub";
            // 
            // VideoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lbSub);
            Controls.Add(lbTitle);
            Controls.Add(pbImage);
            Name = "VideoControl";
            Size = new Size(174, 224);
            Enter += VideoControl_Enter;
            Leave += VideoControl_Leave;
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImage;
        private Label lbTitle;
        private Label lbSub;
    }
}
