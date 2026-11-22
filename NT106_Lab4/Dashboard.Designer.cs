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
        lblTitle.Size = new Size(700, 55);
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
        pnlContainer.Location = new Point(40, 95);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Size = new Size(620, 250);
        pnlContainer.TabIndex = 2;
        // 
        // btnBai1
        // 
        btnBai1.Font = new Font("Segoe UI", 10F);
        btnBai1.Location = new Point(20, 15);
        btnBai1.Name = "btnBai1";
        btnBai1.Size = new Size(259, 42);
        btnBai1.TabIndex = 0;
        btnBai1.Text = "Bài 1";
        btnBai1.UseVisualStyleBackColor = true;
        btnBai1.Click += btnBai1_Click;
        // 
        // btnBai2
        // 
        btnBai2.Font = new Font("Segoe UI", 10F);
        btnBai2.Location = new Point(351, 15);
        btnBai2.Name = "btnBai2";
        btnBai2.Size = new Size(255, 42);
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
        btnBai3.Size = new Size(259, 48);
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
        btnBai4.Location = new Point(351, 75);
        btnBai4.Name = "btnBai4";
        btnBai4.Size = new Size(255, 48);
        btnBai4.TabIndex = 3;
        btnBai4.Text = "Bài 4 - Quản lý phòng vé";
        btnBai4.UseVisualStyleBackColor = false;
        btnBai4.Click += btnBai4_Click;
        // 
        // btnBai7
        // 
        btnBai7.Font = new Font("Segoe UI", 10F);
        btnBai7.Location = new Point(20, 149);
        btnBai7.Name = "btnBai7";
        btnBai7.Size = new Size(259, 42);
        btnBai7.TabIndex = 6;
        btnBai7.Text = "Bài 7";
        btnBai7.UseVisualStyleBackColor = true;
        btnBai7.Click += btnOther_Click;
        // 
        // label1
        // 
        label1.Dock = DockStyle.Top;
        label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.FromArgb(24, 76, 120);
        label1.Location = new Point(0, 55);
        label1.Name = "label1";
        label1.Size = new Size(700, 37);
        label1.TabIndex = 3;
        label1.Text = "LAB04 - NT106.R14.2 ";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Dashboard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(700, 395);
        Controls.Add(label1);
        Controls.Add(pnlContainer);
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
    private Panel pnlContainer;
    private Button btnBai1;
    private Button btnBai2;
    private Button btnBai3;
    private Button btnBai4;
    private Button btnBai7;
    private Label label1;
}
