using System;
using System.Windows.Forms;

namespace NT106_Lab4.Bai3;

public partial class ViewSourceHTML : Form
{
    public ViewSourceHTML(string htmlContent, string sourceUrl = "")
    {
        InitializeComponent();
        LoadSourceData(htmlContent, sourceUrl);
    }

    private void LoadSourceData(string htmlContent, string sourceUrl)
    {
        lblUrl.Text = string.IsNullOrWhiteSpace(sourceUrl) ? "URL: (Không xác định)" : $"URL: {sourceUrl}";
        txtSource.Text = htmlContent ?? string.Empty;

        int charCount = txtSource.Text.Length;
        int lineCount = txtSource.Lines.Length;
        lblStats.Text = $"{charCount:N0} ký tự | {lineCount:N0} dòng";
        lblStatus.Text = $"Đã tải mã nguồn ({charCount:N0} ký tự)";
    }

    private void btnCopy_Click(object? sender, EventArgs e)
    {
        CopySourceToClipboard();
    }

    private void CopySourceToClipboard()
    {
        if (string.IsNullOrEmpty(txtSource.Text))
        {
            MessageBox.Show("Không có nội dung để sao chép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            Clipboard.SetText(txtSource.Text);
            btnCopy.Text = "Đã chép!";
            var timer = new System.Windows.Forms.Timer { Interval = 1500 };
            timer.Tick += (s, args) =>
            {
                btnCopy.Text = "Sao chép";
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi sao chép vào bộ nhớ tạm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void chkWordWrap_CheckedChanged(object? sender, EventArgs e)
    {
        ToggleWordWrap(chkWordWrap.Checked);
    }

    private void ToggleWordWrap(bool wrap)
    {
        txtSource.WordWrap = wrap;
    }
}
