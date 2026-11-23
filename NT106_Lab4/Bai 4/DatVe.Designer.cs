namespace NT106_Lab4.Bai_4;

partial class DatVe
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
        pnlHeader = new Panel();
        lblHeaderTitle = new Label();
        pnlFooter = new Panel();
        lblSelectedInfo = new Label();
        lblTotalPrice = new Label();
        btnExportInfo = new Button();
        btnConfirm = new Button();
        pnlBody = new Panel();
        grpSeats = new GroupBox();
        tlpSeats = new TableLayoutPanel();
        lblScreen = new Label();
        grpInfo = new GroupBox();
        lblBasePrice = new Label();
        lblLegend = new Label();
        cboRoom = new ComboBox();
        lblRoom = new Label();
        cboMovie = new ComboBox();
        lblMovie = new Label();
        txtCustomerName = new TextBox();
        lblCustomerName = new Label();
        pnlHeader.SuspendLayout();
        pnlFooter.SuspendLayout();
        pnlBody.SuspendLayout();
        grpSeats.SuspendLayout();
        grpInfo.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = SystemColors.Window;
        pnlHeader.Controls.Add(lblHeaderTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(840, 68);
        pnlHeader.TabIndex = 0;
        // 
        // lblHeaderTitle
        // 
        lblHeaderTitle.Dock = DockStyle.Fill;
        lblHeaderTitle.Font = new Font("Sitka Text Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblHeaderTitle.ForeColor = Color.Brown;
        lblHeaderTitle.Location = new Point(0, 0);
        lblHeaderTitle.Name = "lblHeaderTitle";
        lblHeaderTitle.Size = new Size(840, 68);
        lblHeaderTitle.TabIndex = 0;
        lblHeaderTitle.Text = "ĐẶT VÉ XEM PHIM";
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = SystemColors.Window;
        pnlFooter.BorderStyle = BorderStyle.FixedSingle;
        pnlFooter.Controls.Add(lblSelectedInfo);
        pnlFooter.Controls.Add(lblTotalPrice);
        pnlFooter.Controls.Add(btnExportInfo);
        pnlFooter.Controls.Add(btnConfirm);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 434);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(15, 10, 15, 10);
        pnlFooter.Size = new Size(840, 82);
        pnlFooter.TabIndex = 1;
        // 
        // lblSelectedInfo
        // 
        lblSelectedInfo.AutoSize = true;
        lblSelectedInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSelectedInfo.Location = new Point(16, 12);
        lblSelectedInfo.Name = "lblSelectedInfo";
        lblSelectedInfo.Size = new Size(194, 20);
        lblSelectedInfo.TabIndex = 0;
        lblSelectedInfo.Text = "Ghế đang chọn: Chưa chọn";
        // 
        // lblTotalPrice
        // 
        lblTotalPrice.AutoSize = true;
        lblTotalPrice.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTotalPrice.ForeColor = Color.Brown;
        lblTotalPrice.Location = new Point(16, 42);
        lblTotalPrice.Name = "lblTotalPrice";
        lblTotalPrice.Size = new Size(156, 25);
        lblTotalPrice.TabIndex = 1;
        lblTotalPrice.Text = "Tổng tiền: 0 VNĐ";
        // 
        // btnExportInfo
        // 
        btnExportInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExportInfo.BackColor = SystemColors.ScrollBar;
        btnExportInfo.Cursor = Cursors.Hand;
        btnExportInfo.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
        btnExportInfo.ForeColor = SystemColors.ControlText;
        btnExportInfo.Location = new Point(421, 16);
        btnExportInfo.Name = "btnExportInfo";
        btnExportInfo.Size = new Size(189, 46);
        btnExportInfo.TabIndex = 3;
        btnExportInfo.Text = "Xuất thông tin";
        btnExportInfo.UseVisualStyleBackColor = false;
        btnExportInfo.Click += btnExportInfo_Click;
        // 
        // btnConfirm
        // 
        btnConfirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnConfirm.BackColor = SystemColors.ScrollBar;
        btnConfirm.Cursor = Cursors.Hand;
        btnConfirm.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnConfirm.ForeColor = SystemColors.ControlText;
        btnConfirm.Location = new Point(622, 16);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Size = new Size(198, 46);
        btnConfirm.TabIndex = 2;
        btnConfirm.Text = "Xác nhận đặt vé";
        btnConfirm.UseVisualStyleBackColor = false;
        btnConfirm.Click += btnConfirm_Click;
        // 
        // pnlBody
        // 
        pnlBody.BackColor = SystemColors.Window;
        pnlBody.Controls.Add(grpSeats);
        pnlBody.Controls.Add(grpInfo);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 68);
        pnlBody.Name = "pnlBody";
        pnlBody.Padding = new Padding(15, 6, 15, 12);
        pnlBody.Size = new Size(840, 366);
        pnlBody.TabIndex = 2;
        // 
        // grpSeats
        // 
        grpSeats.Controls.Add(tlpSeats);
        grpSeats.Controls.Add(lblScreen);
        grpSeats.Dock = DockStyle.Fill;
        grpSeats.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        grpSeats.Location = new Point(345, 6);
        grpSeats.Name = "grpSeats";
        grpSeats.Padding = new Padding(12);
        grpSeats.Size = new Size(480, 348);
        grpSeats.TabIndex = 1;
        grpSeats.TabStop = false;
        grpSeats.Text = "Sơ đồ ghế ngồi";
        // 
        // tlpSeats
        // 
        tlpSeats.ColumnCount = 5;
        tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tlpSeats.Dock = DockStyle.Fill;
        tlpSeats.Location = new Point(12, 62);
        tlpSeats.Name = "tlpSeats";
        tlpSeats.Padding = new Padding(8, 16, 8, 8);
        tlpSeats.RowCount = 3;
        tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
        tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
        tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));
        tlpSeats.Size = new Size(456, 274);
        tlpSeats.TabIndex = 1;
        // 
        // lblScreen
        // 
        lblScreen.BackColor = SystemColors.ScrollBar;
        lblScreen.BorderStyle = BorderStyle.FixedSingle;
        lblScreen.Dock = DockStyle.Top;
        lblScreen.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblScreen.ForeColor = SystemColors.ControlText;
        lblScreen.Location = new Point(12, 32);
        lblScreen.Name = "lblScreen";
        lblScreen.Size = new Size(456, 30);
        lblScreen.TabIndex = 0;
        lblScreen.Text = "MÀN HÌNH CHIẾU";
        lblScreen.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpInfo
        // 
        grpInfo.Controls.Add(lblBasePrice);
        grpInfo.Controls.Add(lblLegend);
        grpInfo.Controls.Add(cboRoom);
        grpInfo.Controls.Add(lblRoom);
        grpInfo.Controls.Add(cboMovie);
        grpInfo.Controls.Add(lblMovie);
        grpInfo.Controls.Add(txtCustomerName);
        grpInfo.Controls.Add(lblCustomerName);
        grpInfo.Dock = DockStyle.Left;
        grpInfo.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        grpInfo.Location = new Point(15, 6);
        grpInfo.Name = "grpInfo";
        grpInfo.Size = new Size(330, 348);
        grpInfo.TabIndex = 0;
        grpInfo.TabStop = false;
        grpInfo.Text = "Thông tin đặt vé";
        // 
        // lblBasePrice
        // 
        lblBasePrice.AutoSize = true;
        lblBasePrice.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblBasePrice.ForeColor = Color.Brown;
        lblBasePrice.Location = new Point(15, 226);
        lblBasePrice.Name = "lblBasePrice";
        lblBasePrice.Size = new Size(174, 19);
        lblBasePrice.TabIndex = 6;
        lblBasePrice.Text = "Giá vé chuẩn: 75,000 VNĐ";
        // 
        // lblLegend
        // 
        lblLegend.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblLegend.ForeColor = Color.DimGray;
        lblLegend.Location = new Point(15, 254);
        lblLegend.Name = "lblLegend";
        lblLegend.Size = new Size(298, 76);
        lblLegend.TabIndex = 7;
        lblLegend.Text = "• Vé vớt (A1, A5, C1, C5): 25% giá chuẩn\r\n• Vé thường (A2-A4, C2-C4, B1, B5): 100%\r\n• Vé VIP (B2, B3, B4): 200% giá chuẩn\r\n• Trống: Trắng | Đang chọn: Cam | Đã đặt: Đỏ";
        // 
        // cboRoom
        // 
        cboRoom.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRoom.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        cboRoom.Location = new Point(15, 186);
        cboRoom.Name = "cboRoom";
        cboRoom.Size = new Size(298, 28);
        cboRoom.TabIndex = 5;
        cboRoom.SelectedIndexChanged += cboSelection_Changed;
        // 
        // lblRoom
        // 
        lblRoom.AutoSize = true;
        lblRoom.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblRoom.Location = new Point(15, 162);
        lblRoom.Name = "lblRoom";
        lblRoom.Size = new Size(90, 19);
        lblRoom.TabIndex = 4;
        lblRoom.Text = "Phòng chiếu:";
        // 
        // cboMovie
        // 
        cboMovie.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMovie.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        cboMovie.Location = new Point(15, 120);
        cboMovie.Name = "cboMovie";
        cboMovie.Size = new Size(298, 28);
        cboMovie.TabIndex = 3;
        cboMovie.SelectedIndexChanged += cboSelection_Changed;
        // 
        // lblMovie
        // 
        lblMovie.AutoSize = true;
        lblMovie.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblMovie.Location = new Point(15, 96);
        lblMovie.Name = "lblMovie";
        lblMovie.Size = new Size(81, 19);
        lblMovie.TabIndex = 2;
        lblMovie.Text = "Chọn phim:";
        // 
        // txtCustomerName
        // 
        txtCustomerName.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
        txtCustomerName.Location = new Point(15, 56);
        txtCustomerName.Name = "txtCustomerName";
        txtCustomerName.PlaceholderText = "Nhập họ tên khách hàng...";
        txtCustomerName.Size = new Size(298, 27);
        txtCustomerName.TabIndex = 1;
        // 
        // lblCustomerName
        // 
        lblCustomerName.AutoSize = true;
        lblCustomerName.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCustomerName.Location = new Point(15, 32);
        lblCustomerName.Name = "lblCustomerName";
        lblCustomerName.Size = new Size(110, 19);
        lblCustomerName.TabIndex = 0;
        lblCustomerName.Text = "Tên khách hàng:";
        // 
        // DatVe
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Window;
        ClientSize = new Size(840, 516);
        Controls.Add(pnlBody);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "DatVe";
        StartPosition = FormStartPosition.CenterParent;
        Text = "DatVe";
        pnlHeader.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        pnlFooter.PerformLayout();
        pnlBody.ResumeLayout(false);
        grpSeats.ResumeLayout(false);
        grpInfo.ResumeLayout(false);
        grpInfo.PerformLayout();
        ResumeLayout(false);
    }

    private Panel pnlHeader;
    private Label lblHeaderTitle;
    private Panel pnlFooter;
    private Label lblSelectedInfo;
    private Label lblTotalPrice;
    private Button btnExportInfo;
    private Button btnConfirm;
    private Panel pnlBody;
    private GroupBox grpInfo;
    private Label lblBasePrice;
    private Label lblLegend;
    private ComboBox cboRoom;
    private Label lblRoom;
    private ComboBox cboMovie;
    private Label lblMovie;
    private TextBox txtCustomerName;
    private Label lblCustomerName;
    private GroupBox grpSeats;
    private Label lblScreen;
    private TableLayoutPanel tlpSeats;
}
