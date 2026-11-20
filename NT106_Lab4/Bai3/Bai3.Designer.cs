namespace NT106_Lab4.Bai3;

partial class Bai3
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
        pnlControls = new Panel();
        btnLoad = new Button();
        txtUrl = new TextBox();
        btnReload = new Button();
        lblStatus = new Label();
        btnViewSource = new Button();
        btnDownFiles = new Button();
        btnDownResources = new Button();
        statusStrip = new StatusStrip();
        lblStatusStrip = new ToolStripStatusLabel();
        progressBar = new ToolStripProgressBar();
        webView = new Microsoft.Web.WebView2.WinForms.WebView2();
        pnlControls.SuspendLayout();
        statusStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
        SuspendLayout();
        // 
        // pnlControls
        // 
        pnlControls.BackColor = Color.FromArgb(246, 248, 250);
        pnlControls.Controls.Add(btnDownResources);
        pnlControls.Controls.Add(btnDownFiles);
        pnlControls.Controls.Add(btnViewSource);
        pnlControls.Controls.Add(lblStatus);
        pnlControls.Controls.Add(btnReload);
        pnlControls.Controls.Add(txtUrl);
        pnlControls.Controls.Add(btnLoad);
        pnlControls.Dock = DockStyle.Top;
        pnlControls.Location = new Point(0, 0);
        pnlControls.Name = "pnlControls";
        pnlControls.Size = new Size(1064, 88);
        pnlControls.TabIndex = 0;
        // 
        // btnLoad
        // 
        btnLoad.BackColor = Color.FromArgb(41, 128, 185);
        btnLoad.FlatStyle = FlatStyle.Flat;
        btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLoad.ForeColor = Color.White;
        btnLoad.Location = new Point(12, 12);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(78, 30);
        btnLoad.TabIndex = 0;
        btnLoad.Text = "Load";
        btnLoad.UseVisualStyleBackColor = false;
        btnLoad.Click += btnLoad_Click;
        // 
        // txtUrl
        // 
        txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtUrl.Font = new Font("Segoe UI", 10F);
        txtUrl.Location = new Point(96, 15);
        txtUrl.Name = "txtUrl";
        txtUrl.Size = new Size(868, 25);
        txtUrl.TabIndex = 1;
        txtUrl.Text = "https://uit.edu.vn/";
        txtUrl.KeyDown += txtUrl_KeyDown;
        // 
        // btnReload
        // 
        btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnReload.BackColor = Color.FromArgb(235, 240, 245);
        btnReload.FlatStyle = FlatStyle.Flat;
        btnReload.Font = new Font("Segoe UI", 9F);
        btnReload.Location = new Point(974, 12);
        btnReload.Name = "btnReload";
        btnReload.Size = new Size(78, 30);
        btnReload.TabIndex = 2;
        btnReload.Text = "reload";
        btnReload.UseVisualStyleBackColor = false;
        btnReload.Click += btnReload_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoEllipsis = true;
        lblStatus.Font = new Font("Segoe UI", 9F);
        lblStatus.ForeColor = Color.DimGray;
        lblStatus.Location = new Point(12, 54);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(620, 24);
        lblStatus.TabIndex = 3;
        lblStatus.Text = "Sẵn sàng";
        // 
        // btnViewSource
        // 
        btnViewSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnViewSource.BackColor = Color.FromArgb(235, 240, 245);
        btnViewSource.FlatStyle = FlatStyle.Flat;
        btnViewSource.Font = new Font("Segoe UI", 9F);
        btnViewSource.Location = new Point(646, 48);
        btnViewSource.Name = "btnViewSource";
        btnViewSource.Size = new Size(110, 30);
        btnViewSource.TabIndex = 4;
        btnViewSource.Text = "View Source";
        btnViewSource.UseVisualStyleBackColor = false;
        btnViewSource.Click += btnViewSource_Click;
        // 
        // btnDownFiles
        // 
        btnDownFiles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDownFiles.BackColor = Color.FromArgb(235, 240, 245);
        btnDownFiles.FlatStyle = FlatStyle.Flat;
        btnDownFiles.Font = new Font("Segoe UI", 9F);
        btnDownFiles.Location = new Point(766, 48);
        btnDownFiles.Name = "btnDownFiles";
        btnDownFiles.Size = new Size(120, 30);
        btnDownFiles.TabIndex = 5;
        btnDownFiles.Text = "Down Files";
        btnDownFiles.UseVisualStyleBackColor = false;
        btnDownFiles.Click += btnDownFiles_Click;
        // 
        // btnDownResources
        // 
        btnDownResources.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDownResources.BackColor = Color.FromArgb(235, 240, 245);
        btnDownResources.FlatStyle = FlatStyle.Flat;
        btnDownResources.Font = new Font("Segoe UI", 9F);
        btnDownResources.Location = new Point(896, 48);
        btnDownResources.Name = "btnDownResources";
        btnDownResources.Size = new Size(156, 30);
        btnDownResources.TabIndex = 6;
        btnDownResources.Text = "Down Resources";
        btnDownResources.UseVisualStyleBackColor = false;
        btnDownResources.Click += btnDownResources_Click;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatusStrip, progressBar });
        statusStrip.Location = new Point(0, 659);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1064, 22);
        statusStrip.TabIndex = 2;
        // 
        // lblStatusStrip
        // 
        lblStatusStrip.Name = "lblStatusStrip";
        lblStatusStrip.Size = new Size(947, 17);
        lblStatusStrip.Spring = true;
        lblStatusStrip.Text = "Trạng thái: Khởi động";
        lblStatusStrip.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // progressBar
        // 
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(100, 16);
        progressBar.Visible = false;
        // 
        // webView
        // 
        webView.AllowExternalDrop = true;
        webView.CreationProperties = null;
        webView.DefaultBackgroundColor = Color.White;
        webView.Dock = DockStyle.Fill;
        webView.Location = new Point(0, 88);
        webView.Name = "webView";
        webView.Size = new Size(1064, 571);
        webView.TabIndex = 1;
        webView.ZoomFactor = 1D;
        // 
        // Bai3
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1064, 681);
        Controls.Add(webView);
        Controls.Add(statusStrip);
        Controls.Add(pnlControls);
        MinimumSize = new Size(800, 500);
        Name = "Bai3";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bai3 - Web Browser";
        Load += Bai3_Load;
        pnlControls.ResumeLayout(false);
        pnlControls.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)webView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel pnlControls;
    private Button btnLoad;
    private TextBox txtUrl;
    private Button btnReload;
    private Label lblStatus;
    private Button btnViewSource;
    private Button btnDownFiles;
    private Button btnDownResources;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatusStrip;
    private ToolStripProgressBar progressBar;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView;
}
