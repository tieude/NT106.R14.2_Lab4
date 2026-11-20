namespace NT106_Lab4;

partial class Dashboard
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
        lblTitle = new Label();
        lblSubtitle = new Label();
        pnlContainer = new Panel();
        btnBai1 = new Button();
        btnBai2 = new Button();
        btnBai3 = new Button();
        btnBai4 = new Button();
        btnBai5 = new Button();
        btnBai6 = new Button();
        btnBai7 = new Button();
        lblFooter = new Label();
        pnlContainer.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(24, 76, 120);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(584, 55);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "THỰC HÀNH MẠNG MÁY TÍNH - LAB 4";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitle
        // 
        lblSubtitle.Dock = DockStyle.Top;
        lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
        lblSubtitle.ForeColor = Color.DimGray;
        lblSubtitle.Location = new Point(0, 55);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(584, 25);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Chương trình điều hướng các bài thực hành Lab 4";
        lblSubtitle.TextAlign = ContentAlignment.TopCenter;
        // 
        // pnlContainer
        // 
        pnlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlContainer.Controls.Add(btnBai1);
        pnlContainer.Controls.Add(btnBai2);
        pnlContainer.Controls.Add(btnBai3);
        pnlContainer.Controls.Add(btnBai4);
        pnlContainer.Controls.Add(btnBai5);
        pnlContainer.Controls.Add(btnBai6);
        pnlContainer.Controls.Add(btnBai7);
        pnlContainer.Location = new Point(40, 95);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Size = new Size(504, 250);
        pnlContainer.TabIndex = 2;
        // 
        // btnBai1
        // 
        btnBai1.Font = new Font("Segoe UI", 10F);
        btnBai1.Location = new Point(20, 15);
        btnBai1.Name = "btnBai1";
        btnBai1.Size = new Size(215, 42);
        btnBai1.TabIndex = 0;
        btnBai1.Text = "Bài 1";
        btnBai1.UseVisualStyleBackColor = true;
        btnBai1.Click += btnOther_Click;
        // 
        // btnBai2
        // 
        btnBai2.Font = new Font("Segoe UI", 10F);
        btnBai2.Location = new Point(265, 15);
        btnBai2.Name = "btnBai2";
        btnBai2.Size = new Size(215, 42);
        btnBai2.TabIndex = 1;
        btnBai2.Text = "Bài 2";
        btnBai2.UseVisualStyleBackColor = true;
        btnBai2.Click += btnOther_Click;
        // 
        // btnBai3
        // 
        btnBai3.BackColor = Color.FromArgb(41, 128, 185);
        btnBai3.FlatStyle = FlatStyle.Flat;
        btnBai3.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnBai3.ForeColor = Color.White;
        btnBai3.Location = new Point(20, 75);
        btnBai3.Name = "btnBai3";
        btnBai3.Size = new Size(460, 48);
        btnBai3.TabIndex = 2;
        btnBai3.Text = "Bài 3 - Web Browser (WebView2)";
        btnBai3.UseVisualStyleBackColor = false;
        btnBai3.Click += btnBai3_Click;
        // 
        // btnBai4
        // 
        btnBai4.Font = new Font("Segoe UI", 10F);
        btnBai4.Location = new Point(20, 140);
        btnBai4.Name = "btnBai4";
        btnBai4.Size = new Size(215, 42);
        btnBai4.TabIndex = 3;
        btnBai4.Text = "Bài 4";
        btnBai4.UseVisualStyleBackColor = true;
        btnBai4.Click += btnOther_Click;
        // 
        // btnBai5
        // 
        btnBai5.Font = new Font("Segoe UI", 10F);
        btnBai5.Location = new Point(265, 140);
        btnBai5.Name = "btnBai5";
        btnBai5.Size = new Size(215, 42);
        btnBai5.TabIndex = 4;
        btnBai5.Text = "Bài 5";
        btnBai5.UseVisualStyleBackColor = true;
        btnBai5.Click += btnOther_Click;
        // 
        // btnBai6
        // 
        btnBai6.Font = new Font("Segoe UI", 10F);
        btnBai6.Location = new Point(20, 195);
        btnBai6.Name = "btnBai6";
        btnBai6.Size = new Size(215, 42);
        btnBai6.TabIndex = 5;
        btnBai6.Text = "Bài 6";
        btnBai6.UseVisualStyleBackColor = true;
        btnBai6.Click += btnOther_Click;
        // 
        // btnBai7
        // 
        btnBai7.Font = new Font("Segoe UI", 10F);
        btnBai7.Location = new Point(265, 195);
        btnBai7.Name = "btnBai7";
        btnBai7.Size = new Size(215, 42);
        btnBai7.TabIndex = 6;
        btnBai7.Text = "Bài 7";
        btnBai7.UseVisualStyleBackColor = true;
        btnBai7.Click += btnOther_Click;
        // 
        // lblFooter
        // 
        lblFooter.Dock = DockStyle.Bottom;
        lblFooter.Font = new Font("Segoe UI", 9F);
        lblFooter.ForeColor = Color.Gray;
        lblFooter.Location = new Point(0, 360);
        lblFooter.Name = "lblFooter";
        lblFooter.Size = new Size(584, 25);
        lblFooter.TabIndex = 3;
        lblFooter.Text = "Chọn \"Bài 3 - Web Browser\" để mở ứng dụng duyệt web.";
        lblFooter.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Dashboard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(584, 395);
        Controls.Add(lblFooter);
        Controls.Add(pnlContainer);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Dashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dashboard - NT106 Lab 4";
        pnlContainer.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Label lblTitle;
    private Label lblSubtitle;
    private Panel pnlContainer;
    private Button btnBai1;
    private Button btnBai2;
    private Button btnBai3;
    private Button btnBai4;
    private Button btnBai5;
    private Button btnBai6;
    private Button btnBai7;
    private Label lblFooter;
}
