using System;
using System.Windows.Forms;

namespace NT106_Lab4.Bai_4;

public partial class ChiTiet_Phim : Form
{
    private readonly string _movieTitle;
    private readonly string _detailUrl;

    public ChiTiet_Phim(string movieTitle, string detailUrl)
    {
        InitializeComponent();
        _movieTitle = movieTitle;
        _detailUrl = detailUrl;
        Text = $"Chi tiết phim - {_movieTitle}";
        lblUrl.Text = _detailUrl;
    }

    private async void ChiTiet_Phim_Load(object? sender, EventArgs e)
    {
        try
        {
            await webViewDetail.EnsureCoreWebView2Async();
            if (Uri.TryCreate(_detailUrl, UriKind.Absolute, out Uri? uri))
            {
                webViewDetail.Source = uri;
            }
            else
            {
                MessageBox.Show("Đường dẫn chi tiết phim không hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể khởi tạo WebView2: {ex.Message}", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClose_Click(object? sender, EventArgs e) => Close();
}
