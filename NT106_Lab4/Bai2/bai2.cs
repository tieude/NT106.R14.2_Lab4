using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04___Bai2
{
    public partial class bai2 : Form
    {
        public bai2()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string url = NormalizeUrl(txtUrl.Text);
            string filePath = txtFilePath.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ URL.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn file để lưu.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnDownload.Enabled = false;
            rtbContent.Text = "Đang tải...";

            try
            {
                await DownloadPageToFileAsync(url, filePath);

                // Đọc lại file vừa lưu và hiển thị lên form
                rtbContent.Text = File.ReadAllText(filePath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                rtbContent.Clear();
                MessageBox.Show("Không thể tải trang web:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDownload.Enabled = true;
            }
        }

        private static async Task DownloadPageToFileAsync(string url, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (WebClient myClient = new WebClient())
            {
                // Một số web chặn request không có User-Agent
                myClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                await myClient.DownloadFileTaskAsync(new Uri(url), filePath);
            }
        }

        // Nếu người dùng gõ "uit.edu.vn" thì tự thêm https://
        private static string NormalizeUrl(string input)
        {
            string url = input.Trim();
            if (url.Length == 0) return url;
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }
            return url;
        }
    }
}