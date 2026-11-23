namespace NT106_Lab4.Bai3;

partial class ViewSourceHTML
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlTop = new Panel();
        lblUrl = new Label();
        lblStats = new Label();
        chkWordWrap = new CheckBox();
        btnCopy = new Button();
        txtSource = new RichTextBox();
        statusStrip = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        pnlTop.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.FromArgb(242, 244, 247);
        pnlTop.Controls.Add(btnCopy);
        pnlTop.Controls.Add(chkWordWrap);
        pnlTop.Controls.Add(lblStats);
        pnlTop.Controls.Add(lblUrl);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(884, 46);
        pnlTop.TabIndex = 0;
        // 
        // lblUrl
        // 
        lblUrl.AutoEllipsis = true;
        lblUrl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblUrl.Location = new Point(12, 13);
        lblUrl.Name = "lblUrl";
        lblUrl.Size = new Size(420, 20);
        lblUrl.TabIndex = 0;
        lblUrl.Text = "URL: ";
        // 
        // lblStats
        // 
        lblStats.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblStats.Font = new Font("Segoe UI", 9F);
        lblStats.ForeColor = Color.DimGray;
        lblStats.Location = new Point(440, 13);
        lblStats.Name = "lblStats";
        lblStats.Size = new Size(160, 20);
        lblStats.TabIndex = 1;
        lblStats.Text = "0 ký tự | 0 dòng";
        lblStats.TextAlign = ContentAlignment.MiddleRight;
        // 
        // chkWordWrap
        // 
        chkWordWrap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        chkWordWrap.AutoSize = true;
        chkWordWrap.Font = new Font("Segoe UI", 9F);
        chkWordWrap.Location = new Point(615, 14);
        chkWordWrap.Name = "chkWordWrap";
        chkWordWrap.Size = new Size(137, 19);
        chkWordWrap.TabIndex = 2;
        chkWordWrap.Text = "Tự xuống dòng (Wrap)";
        chkWordWrap.UseVisualStyleBackColor = true;
        chkWordWrap.CheckedChanged += chkWordWrap_CheckedChanged;
        // 
        // btnCopy
        // 
        btnCopy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCopy.BackColor = Color.FromArgb(41, 128, 185);
        btnCopy.FlatStyle = FlatStyle.Flat;
        btnCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCopy.ForeColor = Color.White;
        btnCopy.Location = new Point(765, 8);
        btnCopy.Name = "btnCopy";
        btnCopy.Size = new Size(105, 30);
        btnCopy.TabIndex = 3;
        btnCopy.Text = "Sao chép";
        btnCopy.UseVisualStyleBackColor = false;
        btnCopy.Click += btnCopy_Click;
        // 
        // txtSource
        // 
        txtSource.BackColor = Color.FromArgb(250, 250, 250);
        txtSource.BorderStyle = BorderStyle.None;
        txtSource.Dock = DockStyle.Fill;
        txtSource.Font = new Font("Consolas", 10F);
        txtSource.ForeColor = Color.FromArgb(33, 37, 41);
        txtSource.Location = new Point(0, 46);
        txtSource.Name = "txtSource";
        txtSource.ReadOnly = true;
        txtSource.ScrollBars = RichTextBoxScrollBars.Both;
        txtSource.Size = new Size(884, 510);
        txtSource.TabIndex = 1;
        txtSource.Text = "";
        txtSource.WordWrap = false;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip.Location = new Point(0, 556);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(884, 22);
        statusStrip.TabIndex = 2;
        statusStrip.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(80, 17);
        lblStatus.Text = "HTML Source";
        // 
        // ViewSourceHTML
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 578);
        Controls.Add(txtSource);
        Controls.Add(statusStrip);
        Controls.Add(pnlTop);
        MinimumSize = new Size(600, 400);
        Name = "ViewSourceHTML";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mã nguồn HTML - View Source";
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel pnlTop;
    private Label lblUrl;
    private Label lblStats;
    private CheckBox chkWordWrap;
    private Button btnCopy;
    private RichTextBox txtSource;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatus;
}
