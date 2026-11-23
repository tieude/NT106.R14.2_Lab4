namespace NT106_Lab4.Bai7;

public partial class Bai7 : Form
{
    private KetNoiApi? api;
    private List<MonAn> danhSach = new();
    private List<Image> anhDanhSach = new();
    private readonly HttpClient httpAnh = new HttpClient { Timeout = TimeSpan.FromSeconds(6) };
    private int trang = 1;
    private int tongTrang = 1;
    private const int SoMonMoiTrang = 5;
    private bool dangTai = false;
    private int lanChonAnh = 0;

    public Bai7()
    {
        InitializeComponent();
        cboDanhSach.SelectedIndex = 0;
    }

    public Bai7(KetNoiApi ketNoi) : this()
    {
        api = ketNoi;
        lblTaiKhoan.Text = "Tài khoản: " + api.TenDangNhap;
    }

    private bool MonCuaToi => cboDanhSach.SelectedIndex == 1;
    private MonAn? MonDangChon => dgvMonAn.CurrentRow?.DataBoundItem as MonAn;

    private async void Bai7_Shown(object? sender, EventArgs e)
    {
        if (api != null) await HienThiDanhSach();
    }

    private void KhoaNut(bool khoa)
    {
        dangTai = khoa;
        btnThem.Enabled = !khoa;
        btnXoa.Enabled = !khoa;
        btnNgauNhien.Enabled = !khoa;
        cboDanhSach.Enabled = !khoa;
        btnTruoc.Enabled = !khoa && trang > 1;
        btnSau.Enabled = !khoa && trang < tongTrang;
        Cursor = khoa ? Cursors.WaitCursor : Cursors.Default;
    }

    private async Task HienThiDanhSach()
    {
        if (api == null || dangTai) return;
        KhoaNut(true);
        lblTrang.Text = "Đang tải...";
        try
        {
            var ketQua = await api.LayDanhSach(MonCuaToi, trang, SoMonMoiTrang);
            if (trang > 1 && ketQua.DanhSach.Count == 0)
            {
                trang--;
                ketQua = await api.LayDanhSach(MonCuaToi, trang, SoMonMoiTrang);
            }
            danhSach = ketQua.DanhSach;
            tongTrang = ketQua.Tong >= 0
                ? Math.Max(1, (ketQua.Tong + SoMonMoiTrang - 1) / SoMonMoiTrang)
                : trang + (danhSach.Count == SoMonMoiTrang ? 1 : 0);

            dgvMonAn.DataSource = null;
            foreach (Image anh in anhDanhSach) anh.Dispose();
            anhDanhSach.Clear();
            dgvMonAn.DataSource = danhSach;
            lblTrang.Text = "Trang " + trang + (ketQua.Tong >= 0 ? " / " + tongTrang : "");
            lblSoMon.Text = "Có " + (ketQua.Tong >= 0 ? ketQua.Tong : danhSach.Count) + " món ăn";
            HienThiMon(MonDangChon);
            await TaiAnhDanhSach();
        }
        catch (Exception ex)
        {
            lblTrang.Text = "Không tải được danh sách";
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally { KhoaNut(false); }
    }

    private async Task<Image?> TaiAnh(string duongDan)
    {
        if (!Uri.TryCreate(duongDan, UriKind.Absolute, out Uri? url) ||
            (url.Scheme != "http" && url.Scheme != "https")) return null;
        try
        {
            byte[] bytes = await httpAnh.GetByteArrayAsync(url);
            if (bytes.Length > 5 * 1024 * 1024) return null;
            using var stream = new MemoryStream(bytes);
            using Image anh = Image.FromStream(stream);
            return new Bitmap(anh);
        }
        catch (Exception) { return null; }
    }

    private async Task TaiAnhDanhSach()
    {
        foreach (DataGridViewRow dong in dgvMonAn.Rows)
        {
            if (IsDisposed || dong.DataBoundItem is not MonAn mon) return;
            Image? anh = await TaiAnh(mon.HinhAnh);
            if (IsDisposed || dong.DataBoundItem != mon)
            {
                anh?.Dispose();
                return;
            }
            if (anh == null) continue;
            anhDanhSach.Add(anh);
            dong.Cells[colAnh.Index].Value = anh;
        }
    }

    private async void HienThiMon(MonAn? mon)
    {
        int lanHienTai = ++lanChonAnh;
        picMonAn.Image?.Dispose();
        picMonAn.Image = null;
        if (mon == null)
        {
            lblChiTiet.Text = "Chọn một món ăn để xem thông tin.";
            return;
        }
        lblChiTiet.Text = $"{mon.TenMon} - {mon.Gia:N0} VNĐ\n" +
            $"Địa chỉ: {mon.DiaChi}\n" +
            $"Người thêm: {mon.NguoiThem}\n" +
            $"Mô tả: {mon.MoTa}";

        Image? anh = await TaiAnh(mon.HinhAnh);
        if (IsDisposed || lanHienTai != lanChonAnh) anh?.Dispose();
        else picMonAn.Image = anh;
    }

    private void dgvMonAn_SelectionChanged(object? sender, EventArgs e)
    {
        HienThiMon(MonDangChon);
    }

    private async void cboDanhSach_SelectedIndexChanged(object? sender, EventArgs e)
    {
        trang = 1;
        if (Visible && api != null) await HienThiDanhSach();
    }

    private async void btnTruoc_Click(object? sender, EventArgs e)
    {
        if (trang <= 1) return;
        trang--;
        await HienThiDanhSach();
    }

    private async void btnSau_Click(object? sender, EventArgs e)
    {
        if (trang >= tongTrang) return;
        trang++;
        await HienThiDanhSach();
    }

    private async void btnThem_Click(object? sender, EventArgs e)
    {
        if (api == null) return;
        using var form = new ThemMon();
        if (form.ShowDialog(this) != DialogResult.OK || form.MonMoi == null) return;
        KhoaNut(true);
        try
        {
            await api.ThemMon(form.MonMoi);
            trang = 1;
            MessageBox.Show("Đã thêm món ăn.");
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Không thêm được món"); }
        finally { KhoaNut(false); }
        await HienThiDanhSach();
    }

    private async void btnXoa_Click(object? sender, EventArgs e)
    {
        if (api == null) return;
        MonAn? mon = MonDangChon;
        if (mon == null)
        {
            MessageBox.Show("Hãy chọn món ăn cần xóa.");
            return;
        }
        if (mon.Id == "")
        {
            MessageBox.Show("Món ăn không có mã ID.");
            return;
        }
        if ((mon.MaNguoiThem != "" && api.MaNguoiDung != "" && mon.MaNguoiThem != api.MaNguoiDung) ||
            (mon.NguoiThem != "" && mon.MaNguoiThem == "" &&
             !mon.NguoiThem.Equals(api.TenDangNhap, StringComparison.OrdinalIgnoreCase)))
        {
            MessageBox.Show("Chỉ được xóa món ăn do bạn thêm.");
            return;
        }
        if (MessageBox.Show("Xóa món " + mon.TenMon + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        KhoaNut(true);
        try
        {
            await api.XoaMon(mon.Id);
            MessageBox.Show("Đã xóa món ăn.");
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Không xóa được món"); }
        finally { KhoaNut(false); }
        await HienThiDanhSach();
    }

    private async void btnNgauNhien_Click(object? sender, EventArgs e)
    {
        if (api == null) return;
        KhoaNut(true);
        try
        {
            MonAn? mon = await api.ChonNgauNhien(MonCuaToi);
            if (mon == null) { MessageBox.Show("Danh sách chưa có món ăn."); return; }
            HienThiMon(mon);
            MessageBox.Show("Hôm nay ăn: " + mon.TenMon, "Kết quả");
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Không chọn được món"); }
        finally { KhoaNut(false); }
    }

    private void btnDangXuat_Click(object? sender, EventArgs e) => Close();

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        ++lanChonAnh;
        dgvMonAn.DataSource = null;
        picMonAn.Image?.Dispose();
        foreach (Image anh in anhDanhSach) anh.Dispose();
        httpAnh.Dispose();
        base.OnFormClosed(e);
    }
}
