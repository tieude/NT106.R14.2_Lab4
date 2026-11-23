namespace NT106_Lab4.Bai7
{
    partial class ThemMon
    {
        private System.ComponentModel.IContainer? components = null;
        private TextBox txtTenMon = null!;
        private TextBox txtGia = null!;
        private TextBox txtDiaChi = null!;
        private TextBox txtAnh = null!;
        private TextBox txtMoTa = null!;
        private Button btnLuu = null!;
        private Button btnHuy = null!;
        private Button btnChonAnh = null!;
        private Label lbl0 = null!;
        private Label lbl1 = null!;
        private Label lbl2 = null!;
        private Label lbl3 = null!;
        private Label lbl4 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTenMon = new TextBox();
            txtGia = new TextBox();
            txtDiaChi = new TextBox();
            txtAnh = new TextBox();
            txtMoTa = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            btnChonAnh = new Button();
            lbl0 = new Label();
            lbl1 = new Label();
            lbl2 = new Label();
            lbl3 = new Label();
            lbl4 = new Label();
            SuspendLayout();

            lbl0.AutoSize = true;
            lbl0.Location = new Point(25, 34);
            lbl0.Name = "lbl0";
            lbl0.Text = "Tên món ăn:";
            txtTenMon.Location = new Point(138, 30);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(380, 27);
            Controls.Add(lbl0);
            Controls.Add(txtTenMon);

            lbl1.AutoSize = true;
            lbl1.Location = new Point(25, 78);
            lbl1.Name = "lbl1";
            lbl1.Text = "Giá (VNĐ):";
            txtGia.Location = new Point(138, 74);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(380, 27);
            Controls.Add(lbl1);
            Controls.Add(txtGia);

            lbl2.AutoSize = true;
            lbl2.Location = new Point(25, 122);
            lbl2.Name = "lbl2";
            lbl2.Text = "Địa chỉ:";
            txtDiaChi.Location = new Point(138, 118);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(380, 27);
            Controls.Add(lbl2);
            Controls.Add(txtDiaChi);

            lbl3.AutoSize = true;
            lbl3.Location = new Point(25, 166);
            lbl3.Name = "lbl3";
            lbl3.Text = "Ảnh:";
            txtAnh.Location = new Point(138, 162);
            txtAnh.Name = "txtAnh";
            txtAnh.Size = new Size(280, 27);
            Controls.Add(lbl3);
            Controls.Add(txtAnh);
            btnChonAnh.Location = new Point(428, 162);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(90, 27);
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.Click += btnChonAnh_Click;
            Controls.Add(btnChonAnh);

            lbl4.AutoSize = true;
            lbl4.Location = new Point(25, 210);
            lbl4.Name = "lbl4";
            lbl4.Text = "Mô tả:";
            txtMoTa.Location = new Point(138, 206);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Multiline = true;
            txtMoTa.Size = new Size(380, 95);
            Controls.Add(lbl4);
            Controls.Add(txtMoTa);

            btnLuu.Location = new Point(298, 330);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(105, 36);
            btnLuu.Text = "Thêm món";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Location = new Point(413, 330);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(105, 36);
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);

            AcceptButton = btnLuu;
            CancelButton = btnHuy;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 392);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ThemMon";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm món ăn";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
