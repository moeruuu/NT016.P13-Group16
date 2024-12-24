namespace UITFLIX
{
    partial class Donate
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
            labelAccountNum = new Label();
            labelAccountName = new Label();
            labelAmount = new Label();
            labelNote = new Label();
            textBoxAccountNum = new TextBox();
            textBoxAccountName = new TextBox();
            textBoxAmount = new TextBox();
            textBoxNote = new TextBox();
            buttonGenerate = new Button();
            pictureBoxQRCode = new PictureBox();
            progressBarDonate = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            SuspendLayout();
            // 
            // labelAccountNum
            // 
            labelAccountNum.AutoSize = true;
            labelAccountNum.Location = new Point(32, 41);
            labelAccountNum.Name = "labelAccountNum";
            labelAccountNum.Size = new Size(121, 20);
            labelAccountNum.TabIndex = 0;
            labelAccountNum.Text = "Account Number";
            // 
            // labelAccountName
            // 
            labelAccountName.AutoSize = true;
            labelAccountName.Location = new Point(32, 96);
            labelAccountName.Name = "labelAccountName";
            labelAccountName.Size = new Size(107, 20);
            labelAccountName.TabIndex = 1;
            labelAccountName.Text = "Account Name";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(36, 148);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(62, 20);
            labelAmount.TabIndex = 2;
            labelAmount.Text = "Amount";
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(38, 192);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(42, 20);
            labelNote.TabIndex = 3;
            labelNote.Text = "Note";
            // 
            // textBoxAccountNum
            // 
            textBoxAccountNum.Location = new Point(204, 36);
            textBoxAccountNum.Name = "textBoxAccountNum";
            textBoxAccountNum.Size = new Size(125, 27);
            textBoxAccountNum.TabIndex = 4;
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Location = new Point(204, 97);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.Size = new Size(125, 27);
            textBoxAccountName.TabIndex = 5;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(204, 148);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(125, 27);
            textBoxAmount.TabIndex = 6;
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(204, 207);
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(125, 27);
            textBoxNote.TabIndex = 7;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(163, 289);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(150, 29);
            buttonGenerate.TabIndex = 8;
            buttonGenerate.Text = "Generate QR Code";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxQRCode.Location = new Point(456, 36);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(295, 324);
            pictureBoxQRCode.TabIndex = 9;
            pictureBoxQRCode.TabStop = false;
            // 
            // progressBarDonate
            // 
            progressBarDonate.Location = new Point(-9, 431);
            progressBarDonate.Name = "progressBarDonate";
            progressBarDonate.Size = new Size(817, 29);
            progressBarDonate.TabIndex = 10;
            // 
            // Donate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBarDonate);
            Controls.Add(pictureBoxQRCode);
            Controls.Add(buttonGenerate);
            Controls.Add(textBoxNote);
            Controls.Add(textBoxAmount);
            Controls.Add(textBoxAccountName);
            Controls.Add(textBoxAccountNum);
            Controls.Add(labelNote);
            Controls.Add(labelAmount);
            Controls.Add(labelAccountName);
            Controls.Add(labelAccountNum);
            Name = "Donate";
            Text = "Donate";
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAccountNum;
        private Label labelAccountName;
        private Label labelAmount;
        private Label labelNote;
        private TextBox textBoxAccountNum;
        private TextBox textBoxAccountName;
        private TextBox textBoxAmount;
        private TextBox textBoxNote;
        private Button buttonGenerate;
        private PictureBox pictureBoxQRCode;
        private ProgressBar progressBarDonate;
    }
}