using System.Globalization;

namespace NT106_Lab4.Bai7;

public partial class ThemMon : Form
{
    public MonAn? MonMoi { get; private set; }

    public ThemMon()
    {
        InitializeComponent();
    }

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        if (txtTenMon.Text.Trim() == "")
        {
            MessageBox.Show("Nhập tên món ăn.");
            return;
        }
        if (!decimal.TryParse(txtGia.Text.Trim(), NumberStyles.Integer,
                CultureInfo.InvariantCulture, out decimal gia) || gia < 0)
        {
            MessageBox.Show("Giá phải là số không âm, ví dụ 45000.");
            return;
        }
        string anh = txtAnh.Text.Trim();
        if (anh != "" && !File.Exists(anh) &&
            (!Uri.TryCreate(anh, UriKind.Absolute, out Uri? url) ||
            (url.Scheme != "http" && url.Scheme != "https")))
        {
            MessageBox.Show("Chọn ảnh từ máy hoặc nhập URL ảnh.");
            return;
        }

        MonMoi = new MonAn
        {
            TenMon = txtTenMon.Text.Trim(),
            Gia = gia,
            DiaChi = txtDiaChi.Text.Trim(),
            HinhAnh = anh,
            MoTa = txtMoTa.Text.Trim()
        };
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.Filter = "Ảnh JPG, PNG|*.jpg;*.jpeg;*.png";
        string thuMucAnh = Path.Combine(AppContext.BaseDirectory, "Bai7", "Assets");
        if (Directory.Exists(thuMucAnh)) dialog.InitialDirectory = thuMucAnh;
        if (dialog.ShowDialog() == DialogResult.OK)
            txtAnh.Text = dialog.FileName;
    }

    private void btnHuy_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
