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
            buttonGenerate = new Button();
            pictureBoxQRCode = new PictureBox();
            progressBarDonate = new ProgressBar();
            richTextBoxNote = new RichTextBox();
            panelQR = new Panel();
            labelQRCode = new Label();
            labelThank = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            panelQR.SuspendLayout();
            SuspendLayout();
            // 
            // labelAccountNum
            // 
            labelAccountNum.AutoSize = true;
            labelAccountNum.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountNum.ForeColor = Color.MidnightBlue;
            labelAccountNum.Location = new Point(15, 91);
            labelAccountNum.Name = "labelAccountNum";
            labelAccountNum.Size = new Size(148, 21);
            labelAccountNum.TabIndex = 0;
            labelAccountNum.Text = "Account number";
            // 
            // labelAccountName
            // 
            labelAccountName.AutoSize = true;
            labelAccountName.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAccountName.ForeColor = Color.MidnightBlue;
            labelAccountName.Location = new Point(15, 148);
            labelAccountName.Name = "labelAccountName";
            labelAccountName.Size = new Size(128, 21);
            labelAccountName.TabIndex = 1;
            labelAccountName.Text = "Account name";
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAmount.ForeColor = Color.MidnightBlue;
            labelAmount.Location = new Point(15, 206);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(151, 21);
            labelAmount.TabIndex = 2;
            labelAmount.Text = "Transfer amount";
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNote.ForeColor = Color.MidnightBlue;
            labelNote.Location = new Point(15, 270);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(124, 21);
            labelNote.TabIndex = 3;
            labelNote.Text = "Transfer note";
            // 
            // textBoxAccountNum
            // 
            textBoxAccountNum.Enabled = false;
            textBoxAccountNum.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountNum.ForeColor = Color.MidnightBlue;
            textBoxAccountNum.Location = new Point(170, 91);
            textBoxAccountNum.Name = "textBoxAccountNum";
            textBoxAccountNum.ReadOnly = true;
            textBoxAccountNum.Size = new Size(255, 27);
            textBoxAccountNum.TabIndex = 4;
            // 
            // textBoxAccountName
            // 
            textBoxAccountName.Enabled = false;
            textBoxAccountName.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAccountName.ForeColor = Color.MidnightBlue;
            textBoxAccountName.Location = new Point(170, 146);
            textBoxAccountName.Name = "textBoxAccountName";
            textBoxAccountName.ReadOnly = true;
            textBoxAccountName.Size = new Size(255, 27);
            textBoxAccountName.TabIndex = 5;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Cursor = Cursors.IBeam;
            textBoxAmount.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAmount.ForeColor = Color.MidnightBlue;
            textBoxAmount.Location = new Point(170, 204);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(255, 27);
            textBoxAmount.TabIndex = 6;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Cursor = Cursors.Hand;
            buttonGenerate.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonGenerate.ForeColor = Color.MidnightBlue;
            buttonGenerate.Location = new Point(170, 415);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(176, 29);
            buttonGenerate.TabIndex = 8;
            buttonGenerate.Text = "Generate QR Code";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.BackColor = Color.LightBlue;
            pictureBoxQRCode.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxQRCode.Location = new Point(18, 36);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(295, 302);
            pictureBoxQRCode.TabIndex = 9;
            pictureBoxQRCode.TabStop = false;
            // 
            // progressBarDonate
            // 
            progressBarDonate.Location = new Point(-6, 460);
            progressBarDonate.Name = "progressBarDonate";
            progressBarDonate.Size = new Size(817, 29);
            progressBarDonate.TabIndex = 10;
            progressBarDonate.Visible = false;
            // 
            // richTextBoxNote
            // 
            richTextBoxNote.Cursor = Cursors.IBeam;
            richTextBoxNote.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxNote.ForeColor = Color.MidnightBlue;
            richTextBoxNote.Location = new Point(170, 268);
            richTextBoxNote.Name = "richTextBoxNote";
            richTextBoxNote.Size = new Size(255, 120);
            richTextBoxNote.TabIndex = 7;
            richTextBoxNote.Text = "";
            // 
            // panelQR
            // 
            panelQR.BackColor = Color.LightBlue;
            panelQR.BorderStyle = BorderStyle.FixedSingle;
            panelQR.Controls.Add(labelQRCode);
            panelQR.Controls.Add(pictureBoxQRCode);
            panelQR.ForeColor = Color.White;
            panelQR.Location = new Point(457, 64);
            panelQR.Name = "panelQR";
            panelQR.Size = new Size(331, 367);
            panelQR.TabIndex = 12;
            // 
            // labelQRCode
            // 
            labelQRCode.AutoSize = true;
            labelQRCode.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelQRCode.ForeColor = Color.MidnightBlue;
            labelQRCode.Location = new Point(-1, -1);
            labelQRCode.Name = "labelQRCode";
            labelQRCode.Size = new Size(86, 23);
            labelQRCode.TabIndex = 0;
            labelQRCode.Text = "QR Code";
            // 
            // labelThank
            // 
            labelThank.AutoSize = true;
            labelThank.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelThank.ForeColor = Color.Teal;
            labelThank.Location = new Point(66, 16);
            labelThank.Name = "labelThank";
            labelThank.Size = new Size(685, 23);
            labelThank.TabIndex = 13;
            labelThank.Text = "Support us by scanning the QR code. We deeply appreciate your support<3";
            // 
            // Donate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 490);
            Controls.Add(labelThank);
            Controls.Add(richTextBoxNote);
            Controls.Add(progressBarDonate);
            Controls.Add(buttonGenerate);
            Controls.Add(textBoxAmount);
            Controls.Add(textBoxAccountName);
            Controls.Add(textBoxAccountNum);
            Controls.Add(labelNote);
            Controls.Add(labelAmount);
            Controls.Add(labelAccountName);
            Controls.Add(labelAccountNum);
            Controls.Add(panelQR);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Donate";
            Text = "Donate";
            Load += Donate_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            panelQR.ResumeLayout(false);
            panelQR.PerformLayout();
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
        private Button buttonGenerate;
        private PictureBox pictureBoxQRCode;
        private ProgressBar progressBarDonate;
        private RichTextBox richTextBoxNote;
        private Panel panelQR;
        private Label labelQRCode;
        private Label labelThank;
    }
}