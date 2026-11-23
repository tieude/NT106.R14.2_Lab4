namespace NT106_Lab4.Bai7
{
    partial class Bai7
    {
        private System.ComponentModel.IContainer? components = null;
        private Label lblTieuDe = null!;
        private Label lblTaiKhoan = null!;
        private Label lblDanhSach = null!;
        private Label lblSoMon = null!;
        private Label lblTrang = null!;
        private Label lblChiTiet = null!;
        private Label lblMonDangChon = null!;
        private ComboBox cboDanhSach = null!;
        private Button btnNgauNhien = null!;
        private Button btnThem = null!;
        private Button btnXoa = null!;
        private Button btnDangXuat = null!;
        private Button btnTruoc = null!;
        private Button btnSau = null!;
        private DataGridView dgvMonAn = null!;
        private DataGridViewImageColumn colAnh = null!;
        private DataGridViewTextBoxColumn colTen = null!;
        private DataGridViewTextBoxColumn colGia = null!;
        private DataGridViewTextBoxColumn colDiaChi = null!;
        private DataGridViewTextBoxColumn colNguoiThem = null!;
        private PictureBox picMonAn = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblTaiKhoan = new Label();
            lblDanhSach = new Label();
            lblSoMon = new Label();
            lblTrang = new Label();
            lblChiTiet = new Label();
            lblMonDangChon = new Label();
            cboDanhSach = new ComboBox();
            btnNgauNhien = new Button();
            btnThem = new Button();
            btnXoa = new Button();
            btnDangXuat = new Button();
            btnTruoc = new Button();
            btnSau = new Button();
            dgvMonAn = new DataGridView();
            colAnh = new DataGridViewImageColumn();
            colTen = new DataGridViewTextBoxColumn();
            colGia = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            colNguoiThem = new DataGridViewTextBoxColumn();
            picMonAn = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picMonAn).BeginInit();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "HÔM NAY ĂN GÌ?";
            //
            // lblTaiKhoan
            //
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new Point(22, 61);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Text = "Tài khoản:";
            //
            // lblDanhSach
            //
            lblDanhSach.AutoSize = true;
            lblDanhSach.Location = new Point(22, 107);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Text = "Danh sách:";
            //
            // cboDanhSach
            //
            cboDanhSach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhSach.FormattingEnabled = true;
            cboDanhSach.Items.AddRange(new object[] { "Tất cả món ăn", "Món của tôi" });
            cboDanhSach.Location = new Point(105, 102);
            cboDanhSach.Name = "cboDanhSach";
            cboDanhSach.Size = new Size(195, 28);
            cboDanhSach.SelectedIndexChanged += cboDanhSach_SelectedIndexChanged;
            //
            // btnNgauNhien
            //
            btnNgauNhien.Location = new Point(475, 100);
            btnNgauNhien.Name = "btnNgauNhien";
            btnNgauNhien.Size = new Size(115, 33);
            btnNgauNhien.Text = "Ăn gì?";
            btnNgauNhien.UseVisualStyleBackColor = true;
            btnNgauNhien.Click += btnNgauNhien_Click;
            //
            // btnThem
            //
            btnThem.Location = new Point(605, 100);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(115, 33);
            btnThem.Text = "Thêm món";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // btnXoa
            //
            btnXoa.Location = new Point(735, 100);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(115, 33);
            btnXoa.Text = "Xóa món";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            //
            // btnDangXuat
            //
            btnDangXuat.Location = new Point(843, 18);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(115, 34);
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            //
            // lblSoMon
            //
            lblSoMon.AutoSize = true;
            lblSoMon.Location = new Point(22, 144);
            lblSoMon.Name = "lblSoMon";
            lblSoMon.Text = "Danh sách món ăn";
            //
            // dgvMonAn
            //
            dgvMonAn.AllowUserToAddRows = false;
            dgvMonAn.AllowUserToDeleteRows = false;
            dgvMonAn.BackgroundColor = Color.White;
            dgvMonAn.AutoGenerateColumns = false;
            dgvMonAn.ColumnHeadersHeight = 30;
            dgvMonAn.Columns.AddRange(new DataGridViewColumn[] { colAnh, colTen, colGia, colDiaChi, colNguoiThem });
            dgvMonAn.Location = new Point(20, 171);
            dgvMonAn.MultiSelect = false;
            dgvMonAn.Name = "dgvMonAn";
            dgvMonAn.ReadOnly = true;
            dgvMonAn.RowHeadersVisible = false;
            dgvMonAn.RowTemplate.Height = 50;
            dgvMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonAn.Size = new Size(938, 315);
            dgvMonAn.TabIndex = 0;
            dgvMonAn.SelectionChanged += dgvMonAn_SelectionChanged;
            //
            // colAnh
            //
            colAnh.HeaderText = "Ảnh";
            colAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colAnh.DefaultCellStyle.NullValue = null;
            colAnh.Name = "colAnh";
            colAnh.ReadOnly = true;
            colAnh.Width = 90;
            //
            // colTen
            //
            colTen.DataPropertyName = "TenMon";
            colTen.HeaderText = "Tên món";
            colTen.Name = "colTen";
            colTen.ReadOnly = true;
            colTen.Width = 175;
            //
            // colGia
            //
            colGia.DataPropertyName = "Gia";
            colGia.DefaultCellStyle.Format = "N0";
            colGia.HeaderText = "Giá (VNĐ)";
            colGia.Name = "colGia";
            colGia.ReadOnly = true;
            colGia.Width = 115;
            //
            // colDiaChi
            //
            colDiaChi.DataPropertyName = "DiaChi";
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.Name = "colDiaChi";
            colDiaChi.ReadOnly = true;
            colDiaChi.Width = 245;
            //
            // colNguoiThem
            //
            colNguoiThem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNguoiThem.DataPropertyName = "NguoiThem";
            colNguoiThem.HeaderText = "Người thêm";
            colNguoiThem.Name = "colNguoiThem";
            colNguoiThem.ReadOnly = true;
            //
            // lblMonDangChon
            //
            lblMonDangChon.AutoSize = true;
            lblMonDangChon.Location = new Point(21, 499);
            lblMonDangChon.Name = "lblMonDangChon";
            lblMonDangChon.Text = "Món ăn đã chọn:";
            //
            // picMonAn
            //
            picMonAn.BorderStyle = BorderStyle.FixedSingle;
            picMonAn.Location = new Point(22, 524);
            picMonAn.Name = "picMonAn";
            picMonAn.Size = new Size(145, 95);
            picMonAn.SizeMode = PictureBoxSizeMode.Zoom;
            picMonAn.TabStop = false;
            //
            // lblChiTiet
            //
            lblChiTiet.BorderStyle = BorderStyle.FixedSingle;
            lblChiTiet.Location = new Point(182, 524);
            lblChiTiet.Name = "lblChiTiet";
            lblChiTiet.Padding = new Padding(7);
            lblChiTiet.Size = new Size(776, 95);
            lblChiTiet.Text = "Chọn một món ăn để xem thông tin.";
            //
            // btnTruoc
            //
            btnTruoc.Location = new Point(702, 633);
            btnTruoc.Name = "btnTruoc";
            btnTruoc.Size = new Size(78, 32);
            btnTruoc.Text = "< Trước";
            btnTruoc.UseVisualStyleBackColor = true;
            btnTruoc.Click += btnTruoc_Click;
            //
            // lblTrang
            //
            lblTrang.Location = new Point(783, 634);
            lblTrang.Name = "lblTrang";
            lblTrang.Size = new Size(97, 31);
            lblTrang.Text = "Trang 1";
            lblTrang.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnSau
            //
            btnSau.Location = new Point(883, 633);
            btnSau.Name = "btnSau";
            btnSau.Size = new Size(75, 32);
            btnSau.Text = "Sau >";
            btnSau.UseVisualStyleBackColor = true;
            btnSau.Click += btnSau_Click;
            //
            // Bai7
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 678);
            Controls.Add(lblTieuDe);
            Controls.Add(lblTaiKhoan);
            Controls.Add(lblDanhSach);
            Controls.Add(cboDanhSach);
            Controls.Add(btnNgauNhien);
            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnDangXuat);
            Controls.Add(lblSoMon);
            Controls.Add(dgvMonAn);
            Controls.Add(lblMonDangChon);
            Controls.Add(picMonAn);
            Controls.Add(lblChiTiet);
            Controls.Add(btnTruoc);
            Controls.Add(lblTrang);
            Controls.Add(btnSau);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 7 - Hôm nay ăn gì?";
            Shown += Bai7_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picMonAn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
