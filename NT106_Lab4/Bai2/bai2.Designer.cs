namespace Lab04___Bai2
{
    partial class bai2
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
            txtUrl = new TextBox();
            txtFilePath = new TextBox();
            rtbContent = new RichTextBox();
            btnDownload = new Button();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(43, 41);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(333, 27);
            txtUrl.TabIndex = 0;
            txtUrl.Text = "http://uit.edu.vn";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(43, 86);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(333, 27);
            txtFilePath.TabIndex = 1;
            txtFilePath.Text = "E:\\uit.html";
            // 
            // rtbContent
            // 
            rtbContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbContent.BackColor = Color.White;
            rtbContent.Location = new Point(43, 138);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            rtbContent.Size = new Size(463, 254);
            rtbContent.TabIndex = 2;
            rtbContent.Text = "";
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(192, 255, 255);
            btnDownload.FlatStyle = FlatStyle.Popup;
            btnDownload.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownload.Location = new Point(401, 41);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(105, 27);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
            // 
            // bai2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(544, 428);
            Controls.Add(btnDownload);
            Controls.Add(rtbContent);
            Controls.Add(txtFilePath);
            Controls.Add(txtUrl);
            Name = "bai2";
            Text = "bai2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUrl;
        private TextBox txtFilePath;
        private RichTextBox rtbContent;
        private Button btnDownload;
    }
}