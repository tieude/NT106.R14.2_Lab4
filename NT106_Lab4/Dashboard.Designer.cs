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
        pnlContainer = new Panel();
        btnBai1 = new Button();
        btnBai2 = new Button();
        btnBai3 = new Button();
        btnBai4 = new Button();
        btnBai7 = new Button();
        label1 = new Label();
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
        lblTitle.Size = new Size(800, 99);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "THỰC HÀNH LẬP TRÌNH MẠNG CĂN BẢN";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlContainer
        // 
        pnlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlContainer.Controls.Add(btnBai1);
        pnlContainer.Controls.Add(btnBai2);
        pnlContainer.Controls.Add(btnBai3);
        pnlContainer.Controls.Add(btnBai4);
        pnlContainer.Controls.Add(btnBai7);
        pnlContainer.Location = new Point(45, 181);
        pnlContainer.Margin = new Padding(3, 4, 3, 4);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Size = new Size(709, 333);
        pnlContainer.TabIndex = 2;
        // 
        // btnBai1
        // 
        btnBai1.Font = new Font("Segoe UI", 10F);
        btnBai1.Location = new Point(23, 20);
        btnBai1.Margin = new Padding(3, 4, 3, 4);
        btnBai1.Name = "btnBai1";
        btnBai1.Size = new Size(296, 56);
        btnBai1.TabIndex = 0;
        btnBai1.Text = "Bài 1";
        btnBai1.UseVisualStyleBackColor = true;
        btnBai1.Click += btnBai1_Click;
        // 
        // btnBai2
        // 
        btnBai2.Font = new Font("Segoe UI", 10F);
        btnBai2.Location = new Point(401, 20);
        btnBai2.Margin = new Padding(3, 4, 3, 4);
        btnBai2.Name = "btnBai2";
        btnBai2.Size = new Size(291, 56);
        btnBai2.TabIndex = 1;
        btnBai2.Text = "Bài 2";
        btnBai2.UseVisualStyleBackColor = true;
        btnBai2.Click += btnBai2_Click;
        // 
        // btnBai3
        // 
        btnBai3.BackColor = Color.FromArgb(41, 128, 185);
        btnBai3.FlatStyle = FlatStyle.Flat;
        btnBai3.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        btnBai3.ForeColor = Color.White;
        btnBai3.Location = new Point(23, 100);
        btnBai3.Margin = new Padding(3, 4, 3, 4);
        btnBai3.Name = "btnBai3";
        btnBai3.Size = new Size(296, 64);
        btnBai3.TabIndex = 2;
        btnBai3.Text = "Bài 3 - Web Browser (WebView2)";
        btnBai3.UseVisualStyleBackColor = false;
        btnBai3.Click += btnBai3_Click;
        // 
        // btnBai4
        // 
        btnBai4.BackColor = Color.FromArgb(41, 128, 185);
        btnBai4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnBai4.ForeColor = Color.White;
        btnBai4.Location = new Point(401, 100);
        btnBai4.Margin = new Padding(3, 4, 3, 4);
        btnBai4.Name = "btnBai4";
        btnBai4.Size = new Size(291, 64);
        btnBai4.TabIndex = 3;
        btnBai4.Text = "Bài 4 - Quản lý phòng vé";
        btnBai4.UseVisualStyleBackColor = false;
        btnBai4.Click += btnBai4_Click;
        // 
        // btnBai7
        // 
        btnBai7.Font = new Font("Segoe UI", 10F);
        btnBai7.Location = new Point(198, 192);
        btnBai7.Margin = new Padding(3, 4, 3, 4);
        btnBai7.Name = "btnBai7";
        btnBai7.Size = new Size(296, 56);
        btnBai7.TabIndex = 6;
        btnBai7.Text = "Bài 7";
        btnBai7.UseVisualStyleBackColor = true;
        btnBai7.Click += btnBai7_Click;
        // 
        // label1
        // 
        label1.Dock = DockStyle.Top;
        label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.FromArgb(24, 76, 120);
        label1.Location = new Point(0, 99);
        label1.Name = "label1";
        label1.Size = new Size(800, 49);
        label1.TabIndex = 3;
        label1.Text = "LAB04 - NT106.R14.2 ";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Dashboard
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(800, 527);
        Controls.Add(label1);
        Controls.Add(pnlContainer);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Name = "Dashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dashboard - NT106 Lab 4";
        pnlContainer.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Label lblTitle;
    private Panel pnlContainer;
    private Button btnBai1;
    private Button btnBai2;
    private Button btnBai3;
    private Button btnBai4;
    private Button btnBai7;
    private Label label1;
}
