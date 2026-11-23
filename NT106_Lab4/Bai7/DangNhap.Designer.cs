namespace NT106_Lab4.Bai7
{
    partial class DangNhap
    {
        private System.ComponentModel.IContainer? components = null;
        private Label lblDkTaiKhoan = null!;
        private Label lblDkMatKhau = null!;
        private Label lblDkNhapLai = null!;
        private Label lblDkEmail = null!;
        private Label lblDkHo = null!;
        private Label lblDkTen = null!;
        private Label lblDkSDT = null!;
        private Label lblDkNgaySinh = null!;
        private Label lblDkGioiTinh = null!;

        private Label lblTieuDe = null!;
        private TabControl tabMain = null!;
        private TabPage tabLogin = null!;
        private TabPage tabRegister = null!;
        private Label lblTaiKhoan = null!;
        private Label lblMatKhau = null!;
        private TextBox txtTaiKhoan = null!;
        private TextBox txtMatKhau = null!;
        private Button btnDangNhap = null!;
        private TextBox txtDKTaiKhoan = null!;
        private TextBox txtDKMatKhau = null!;
        private TextBox txtNhapLai = null!;
        private TextBox txtEmail = null!;
        private TextBox txtHo = null!;
        private TextBox txtTen = null!;
        private TextBox txtSDT = null!;
        private DateTimePicker dtNgaySinh = null!;
        private ComboBox cboGioiTinh = null!;
        private Button btnDangKy = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            tabMain = new TabControl();
            tabLogin = new TabPage();
            tabRegister = new TabPage();
            lblTaiKhoan = new Label();
            lblMatKhau = new Label();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            txtDKTaiKhoan = new TextBox();
            txtDKMatKhau = new TextBox();
            txtNhapLai = new TextBox();
            txtEmail = new TextBox();
            txtHo = new TextBox();
            txtTen = new TextBox();
            txtSDT = new TextBox();
            dtNgaySinh = new DateTimePicker();
            cboGioiTinh = new ComboBox();
            btnDangKy = new Button();
            tabMain.SuspendLayout();
            tabLogin.SuspendLayout();
            tabRegister.SuspendLayout();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.Location = new Point(27, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "HÔM NAY ĂN GÌ?";

            tabMain.Controls.Add(tabLogin);
            tabMain.Controls.Add(tabRegister);
            tabMain.Location = new Point(25, 62);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(490, 480);
            tabMain.TabIndex = 0;

            tabLogin.Location = new Point(4, 29);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(3);
            tabLogin.Size = new Size(482, 447);
            tabLogin.Text = "Đăng nhập";
            tabLogin.UseVisualStyleBackColor = true;

            tabRegister.Location = new Point(4, 29);
            tabRegister.Name = "tabRegister";
            tabRegister.Padding = new Padding(3);
            tabRegister.Size = new Size(482, 447);
            tabRegister.Text = "Đăng ký";
            tabRegister.UseVisualStyleBackColor = true;

            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new Point(40, 50);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Text = "Tài khoản:";

            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(40, 100);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Text = "Mật khẩu:";

            txtTaiKhoan.Location = new Point(142, 45);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(275, 27);

            txtMatKhau.Location = new Point(142, 95);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(275, 27);
            txtMatKhau.UseSystemPasswordChar = true;

            btnDangNhap.Location = new Point(142, 150);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(135, 36);
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;

            lblDkTaiKhoan = new Label();
            lblDkTaiKhoan.AutoSize = true;
            lblDkTaiKhoan.Location = new Point(25, 24);
            lblDkTaiKhoan.Name = "lblDkTaiKhoan";
            lblDkTaiKhoan.Text = "Tài khoản:";
            tabRegister.Controls.Add(lblDkTaiKhoan);
            txtDKTaiKhoan.Location = new Point(150, 20);
            txtDKTaiKhoan.Name = "txtDKTaiKhoan";
            txtDKTaiKhoan.Size = new Size(294, 27);
            tabRegister.Controls.Add(txtDKTaiKhoan);

            lblDkMatKhau = new Label();
            lblDkMatKhau.AutoSize = true;
            lblDkMatKhau.Location = new Point(25, 65);
            lblDkMatKhau.Name = "lblDkMatKhau";
            lblDkMatKhau.Text = "Mật khẩu:";
            tabRegister.Controls.Add(lblDkMatKhau);
            txtDKMatKhau.Location = new Point(150, 61);
            txtDKMatKhau.Name = "txtDKMatKhau";
            txtDKMatKhau.Size = new Size(294, 27);
            txtDKMatKhau.UseSystemPasswordChar = true;
            tabRegister.Controls.Add(txtDKMatKhau);

            lblDkNhapLai = new Label();
            lblDkNhapLai.AutoSize = true;
            lblDkNhapLai.Location = new Point(25, 106);
            lblDkNhapLai.Name = "lblDkNhapLai";
            lblDkNhapLai.Text = "Nhập lại MK:";
            tabRegister.Controls.Add(lblDkNhapLai);
            txtNhapLai.Location = new Point(150, 102);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(294, 27);
            txtNhapLai.UseSystemPasswordChar = true;
            tabRegister.Controls.Add(txtNhapLai);

            lblDkEmail = new Label();
            lblDkEmail.AutoSize = true;
            lblDkEmail.Location = new Point(25, 147);
            lblDkEmail.Name = "lblDkEmail";
            lblDkEmail.Text = "Email:";
            tabRegister.Controls.Add(lblDkEmail);
            txtEmail.Location = new Point(150, 143);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(294, 27);
            tabRegister.Controls.Add(txtEmail);

            lblDkHo = new Label();
            lblDkHo.AutoSize = true;
            lblDkHo.Location = new Point(25, 188);
            lblDkHo.Name = "lblDkHo";
            lblDkHo.Text = "Họ:";
            tabRegister.Controls.Add(lblDkHo);
            txtHo.Location = new Point(150, 184);
            txtHo.Name = "txtHo";
            txtHo.Size = new Size(294, 27);
            tabRegister.Controls.Add(txtHo);

            lblDkTen = new Label();
            lblDkTen.AutoSize = true;
            lblDkTen.Location = new Point(25, 229);
            lblDkTen.Name = "lblDkTen";
            lblDkTen.Text = "Tên:";
            tabRegister.Controls.Add(lblDkTen);
            txtTen.Location = new Point(150, 225);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(294, 27);
            tabRegister.Controls.Add(txtTen);

            lblDkSDT = new Label();
            lblDkSDT.AutoSize = true;
            lblDkSDT.Location = new Point(25, 270);
            lblDkSDT.Name = "lblDkSDT";
            lblDkSDT.Text = "Số điện thoại:";
            tabRegister.Controls.Add(lblDkSDT);
            txtSDT.Location = new Point(150, 266);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(294, 27);
            tabRegister.Controls.Add(txtSDT);

            lblDkNgaySinh = new Label();
            lblDkNgaySinh.AutoSize = true;
            lblDkNgaySinh.Location = new Point(25, 311);
            lblDkNgaySinh.Name = "lblDkNgaySinh";
            lblDkNgaySinh.Text = "Ngày sinh:";
            tabRegister.Controls.Add(lblDkNgaySinh);
            dtNgaySinh.Location = new Point(150, 307);
            dtNgaySinh.Name = "dtNgaySinh";
            dtNgaySinh.Size = new Size(294, 27);
            dtNgaySinh.Format = DateTimePickerFormat.Short;
            dtNgaySinh.MaxDate = DateTime.Today;
            tabRegister.Controls.Add(dtNgaySinh);

            lblDkGioiTinh = new Label();
            lblDkGioiTinh.AutoSize = true;
            lblDkGioiTinh.Location = new Point(25, 352);
            lblDkGioiTinh.Name = "lblDkGioiTinh";
            lblDkGioiTinh.Text = "Giới tính:";
            tabRegister.Controls.Add(lblDkGioiTinh);
            cboGioiTinh.Location = new Point(150, 348);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(294, 27);
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            tabRegister.Controls.Add(cboGioiTinh);

            btnDangKy.Location = new Point(150, 395);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(135, 36);
            btnDangKy.Text = "Tạo tài khoản";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            tabRegister.Controls.Add(btnDangKy);

            tabLogin.Controls.Add(lblTaiKhoan);
            tabLogin.Controls.Add(lblMatKhau);
            tabLogin.Controls.Add(txtTaiKhoan);
            tabLogin.Controls.Add(txtMatKhau);
            tabLogin.Controls.Add(btnDangNhap);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 560);
            Controls.Add(lblTieuDe);
            Controls.Add(tabMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 7 - Đăng nhập / Đăng ký";
            tabMain.ResumeLayout(false);
            tabLogin.ResumeLayout(false);
            tabLogin.PerformLayout();
            tabRegister.ResumeLayout(false);
            tabRegister.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
