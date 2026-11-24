namespace NT106_Lab4.Bai7;

public partial class DangNhap : Form
{
    private readonly KetNoiApi api = new KetNoiApi();

    public DangNhap()
    {
        InitializeComponent();
        cboGioiTinh.SelectedIndex = 0;
    }

    private async void btnDangNhap_Click(object? sender, EventArgs e)
    {
        string taiKhoan = txtTaiKhoan.Text.Trim();
        string matKhau = txtMatKhau.Text;
        if (taiKhoan == "" || matKhau == "")
        {
            MessageBox.Show("Nhập tài khoản và mật khẩu.");
            return;
        }
        btnDangNhap.Enabled = false;
        try
        {
            await api.DangNhap(taiKhoan, matKhau);
            Hide();
            using (var form = new Bai7(api)) form.ShowDialog(this);
            Show();
            txtMatKhau.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Đăng nhập thất bại");
        }
        finally { btnDangNhap.Enabled = true; }
    }

    private async void btnDangKy_Click(object? sender, EventArgs e)
    {
        string taiKhoan = txtDKTaiKhoan.Text.Trim();
        string matKhau = txtDKMatKhau.Text;
        if (taiKhoan.Length < 3 || matKhau.Length < 6)
        {
            MessageBox.Show("Tài khoản cần ít nhất 3 ký tự, mật khẩu ít nhất 6 ký tự.");
            return;
        }
        if (matKhau != txtNhapLai.Text)
        {
            MessageBox.Show("Mật khẩu nhập lại không khớp.");
            return;
        }
        if (!System.Net.Mail.MailAddress.TryCreate(txtEmail.Text.Trim(), out _))
        {
            MessageBox.Show("Email không hợp lệ.");
            return;
        }
        btnDangKy.Enabled = false;
        try
        {
            string gioiTinh = cboGioiTinh.SelectedIndex switch
            {
                0 => "male",
                1 => "female",
                _ => "other"
            };
            await api.DangKy(taiKhoan, matKhau, txtEmail.Text.Trim(), txtHo.Text.Trim(),
                txtTen.Text.Trim(), txtSDT.Text.Trim(), dtNgaySinh.Value.Date, gioiTinh);
            MessageBox.Show("Đăng ký thành công. Hãy đăng nhập.");
            txtTaiKhoan.Text = taiKhoan;
            txtMatKhau.Clear();
            tabMain.SelectedTab = tabLogin;
        }
        catch (TimeoutException ex)
        {
            MessageBox.Show(ex.Message +
                "\n\nNếu máy chủ đã nhận yêu cầu, tài khoản có thể đã được tạo. " +
                "Bạn hãy thử đăng nhập trước khi đăng ký lại.", "Không nhận được phản hồi đăng ký");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Đăng ký thất bại");
        }
        finally { btnDangKy.Enabled = true; }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        api.Dispose();
        base.OnFormClosed(e);
    }
}
