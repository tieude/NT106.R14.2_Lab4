using Microsoft.Web.WebView2.WinForms;

namespace NT106_Lab4.Bai_4;

partial class ChiTiet_Phim
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
        lblTitle = new Label();
        lblUrl = new Label();
        btnClose = new Button();
        webViewDetail = new WebView2();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)webViewDetail).BeginInit();
        SuspendLayout();

        // pnlTop
        pnlTop.BackColor = SystemColors.Window;
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Controls.Add(lblUrl);
        pnlTop.Controls.Add(btnClose);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(984, 108);
        pnlTop.TabIndex = 0;

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Sitka Text Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.Brown;
        lblTitle.Location = new Point(365, 9);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(254, 43);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "CHI TIẾT PHIM";

        // lblUrl
        lblUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblUrl.AutoEllipsis = true;
        lblUrl.BorderStyle = BorderStyle.FixedSingle;
        lblUrl.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblUrl.ForeColor = SystemColors.ControlText;
        lblUrl.Location = new Point(15, 62);
        lblUrl.Name = "lblUrl";
        lblUrl.Padding = new Padding(6, 0, 6, 0);
        lblUrl.Size = new Size(815, 34);
        lblUrl.TabIndex = 1;
        lblUrl.Text = "Đang tải chi tiết phim...";
        lblUrl.TextAlign = ContentAlignment.MiddleLeft;

        // btnClose
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.BackColor = SystemColors.ScrollBar;
        btnClose.Cursor = Cursors.Hand;
        btnClose.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnClose.ForeColor = SystemColors.ControlText;
        btnClose.Location = new Point(842, 60);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(126, 38);
        btnClose.TabIndex = 2;
        btnClose.Text = "Đóng";
        btnClose.UseVisualStyleBackColor = false;
        btnClose.Click += btnClose_Click;

        // webViewDetail
        webViewDetail.AllowExternalDrop = true;
        webViewDetail.DefaultBackgroundColor = Color.White;
        webViewDetail.Dock = DockStyle.Fill;
        webViewDetail.Location = new Point(0, 108);
        webViewDetail.Name = "webViewDetail";
        webViewDetail.Size = new Size(984, 553);
        webViewDetail.TabIndex = 1;

        // ChiTiet_Phim
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Window;
        ClientSize = new Size(984, 661);
        Controls.Add(webViewDetail);
        Controls.Add(pnlTop);
        Name = "ChiTiet_Phim";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Chi tiết phim";
        Load += ChiTiet_Phim_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)webViewDetail).EndInit();
        ResumeLayout(false);
    }

    private Panel pnlTop;
    private Label lblTitle;
    private Label lblUrl;
    private Button btnClose;
    private WebView2 webViewDetail;
}
