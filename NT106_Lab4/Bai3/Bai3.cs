using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace NT106_Lab4.Bai3;

public partial class Bai3 : Form
{
    private bool _isWebViewInitialized = false;

    public Bai3()
    {
        InitializeComponent();
    }

    #region Form & WebView Events

    private async void Bai3_Load(object? sender, EventArgs e)
    {
        await InitializeWebViewAsync();
    }

    private async void btnLoad_Click(object? sender, EventArgs e)
    {
        await NavigateToUrlAsync(txtUrl.Text);
    }

    private async void txtUrl_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            await NavigateToUrlAsync(txtUrl.Text);
        }
    }

    private void btnReload_Click(object? sender, EventArgs e)
    {
        ReloadCurrentPage();
    }

    private async void btnViewSource_Click(object? sender, EventArgs e)
    {
        await OpenViewSourceAsync();
    }

    private async void btnDownFiles_Click(object? sender, EventArgs e)
    {
        await DownloadHtmlFileAsync();
    }

    private async void btnDownResources_Click(object? sender, EventArgs e)
    {
        await DownloadResourcesAsync();
    }

    private void WebView_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
    {
        UpdateStatus($"Đang kết nối: {e.Uri}...");
    }

    private void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        if (e.IsSuccess)
        {
            UpdateStatus("Đã tải trang thành công.");
        }
        else
        {
            UpdateStatus($"Không thể tải trang (Mã lỗi: {e.WebErrorStatus})", isError: true);
        }
    }

    private void WebView_SourceChanged(object? sender, CoreWebView2SourceChangedEventArgs e)
    {
        if (webView.Source != null && !webView.Source.AbsoluteUri.Equals("about:blank", StringComparison.OrdinalIgnoreCase))
        {
            txtUrl.Text = webView.Source.AbsoluteUri;
        }
    }

    #endregion

    #region Web Navigation Logic

    private async Task InitializeWebViewAsync()
    {
        UpdateStatus("Đang khởi tạo trình duyệt WebView2...");
        try
        {
            await webView.EnsureCoreWebView2Async(null);
            _isWebViewInitialized = true;

            webView.NavigationStarting += WebView_NavigationStarting;
            webView.NavigationCompleted += WebView_NavigationCompleted;
            webView.SourceChanged += WebView_SourceChanged;

            UpdateStatus("WebView2 đã sẵn sàng.");

            // Tự động điều hướng đến URL mặc định ban đầu
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                await NavigateToUrlAsync(txtUrl.Text);
            }
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi khởi tạo WebView2: {ex.Message}", isError: true);
            MessageBox.Show(
                $"Không thể khởi động Microsoft WebView2 Runtime:\n{ex.Message}\n\nĐảm bảo máy đã cài đặt Microsoft Edge WebView2 Evergreen Runtime.",
                "Lỗi khởi tạo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private async Task EnsureWebViewReadyAsync()
    {
        if (!_isWebViewInitialized || webView.CoreWebView2 == null)
        {
            await webView.EnsureCoreWebView2Async(null);
            _isWebViewInitialized = true;
        }
    }

    private async Task NavigateToUrlAsync(string rawUrl)
    {
        string normalizedUrl = NormalizeUrl(rawUrl);
        if (string.IsNullOrWhiteSpace(normalizedUrl))
        {
            MessageBox.Show("Vui lòng nhập địa chỉ URL trang web.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        txtUrl.Text = normalizedUrl;

        try
        {
            await EnsureWebViewReadyAsync();
            UpdateStatus($"Đang mở: {normalizedUrl}...");
            webView.CoreWebView2.Navigate(normalizedUrl);
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi điều hướng: {ex.Message}", isError: true);
            MessageBox.Show($"Không thể mở trang web:\n{ex.Message}", "Lỗi điều hướng", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ReloadCurrentPage()
    {
        if (webView.CoreWebView2 != null)
        {
            UpdateStatus("Đang làm mới trang web...");
            webView.Reload();
        }
    }

    private string NormalizeUrl(string inputUrl)
    {
        if (string.IsNullOrWhiteSpace(inputUrl)) return string.Empty;

        string trimmed = inputUrl.Trim();
        if (!trimmed.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
            !trimmed.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            trimmed = "https://" + trimmed;
        }
        return trimmed;
    }

    private string GetCurrentOrInputUrl()
    {
        if (webView.Source != null && !string.IsNullOrWhiteSpace(webView.Source.AbsoluteUri) &&
            !webView.Source.AbsoluteUri.Equals("about:blank", StringComparison.OrdinalIgnoreCase))
        {
            return webView.Source.AbsoluteUri;
        }
        return NormalizeUrl(txtUrl.Text);
    }

    #endregion

    #region HTML & Resource Handling

    public async Task<string> GetCurrentHtmlAsync()
    {
        await EnsureWebViewReadyAsync();

        // Ưu tiên 1: Lấy HTML trực tiếp từ DOM đang hiển thị trong WebView2
        if (webView.CoreWebView2 != null)
        {
            try
            {
                string rawJson = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
                if (!string.IsNullOrEmpty(rawJson) && rawJson != "null")
                {
                    string? domHtml = JsonSerializer.Deserialize<string>(rawJson);
                    if (!string.IsNullOrWhiteSpace(domHtml))
                    {
                        return domHtml;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ExecuteScriptAsync error: {ex.Message}");
            }
        }

        // Ưu tiên 2 (Fallback): Dùng HttpClient để tải mã nguồn trực tiếp từ URL
        string currentUrl = GetCurrentOrInputUrl();
        if (Uri.TryCreate(currentUrl, UriKind.Absolute, out Uri? uri) &&
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(15);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            return await client.GetStringAsync(uri);
        }

        return string.Empty;
    }

    private async Task OpenViewSourceAsync()
    {
        try
        {
            UpdateStatus("Đang trích xuất mã nguồn HTML...");
            string html = await GetCurrentHtmlAsync();
            string currentUrl = GetCurrentOrInputUrl();

            if (string.IsNullOrWhiteSpace(html))
            {
                UpdateStatus("Không thể lấy mã nguồn HTML của trang web.", isError: true);
                MessageBox.Show(
                    "Không thể lấy nội dung HTML của trang hiện tại. Vui lòng đợi trang tải xong hoặc kiểm tra lại kết nối.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            UpdateStatus("Đã tải xong mã nguồn HTML.");
            var formViewSource = new ViewSourceHTML(html, currentUrl);
            formViewSource.Show();
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi khi xem mã nguồn: {ex.Message}", isError: true);
            MessageBox.Show($"Đã xảy ra lỗi:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task DownloadHtmlFileAsync()
    {
        try
        {
            UpdateStatus("Đang trích xuất nội dung HTML để lưu...");
            string html = await GetCurrentHtmlAsync();

            if (string.IsNullOrWhiteSpace(html))
            {
                UpdateStatus("Không có nội dung HTML để lưu.", isError: true);
                MessageBox.Show("Không tìm thấy nội dung HTML của trang web để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string defaultFileName = "webpage.html";
            string currentUrl = GetCurrentOrInputUrl();
            if (Uri.TryCreate(currentUrl, UriKind.Absolute, out Uri? uri))
            {
                string host = uri.Host.Replace(".", "_");
                defaultFileName = $"{host}.html";
            }

            using var sfd = new SaveFileDialog
            {
                Title = "Chọn nơi lưu file HTML",
                Filter = "HTML Files (*.html;*.htm)|*.html;*.htm|All Files (*.*)|*.*",
                DefaultExt = "html",
                FileName = defaultFileName
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                await File.WriteAllTextAsync(sfd.FileName, html, Encoding.UTF8);
                UpdateStatus($"Đã lưu file HTML thành công: {Path.GetFileName(sfd.FileName)}");
                MessageBox.Show(
                    $"Đã tải và lưu file HTML thành công!\n\nĐường dẫn: {sfd.FileName}\nKích thước: {new FileInfo(sfd.FileName).Length:N0} bytes (Mã hóa UTF-8)",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                UpdateStatus("Đã hủy thao tác lưu file HTML.");
            }
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi khi lưu file HTML: {ex.Message}", isError: true);
            MessageBox.Show($"Đã xảy ra lỗi khi lưu file HTML:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task DownloadResourcesAsync()
    {
        try
        {
            UpdateStatus("Đang chuẩn bị quét tài nguyên hình ảnh...");
            string html = await GetCurrentHtmlAsync();
            string currentUrl = GetCurrentOrInputUrl();

            if (string.IsNullOrWhiteSpace(html))
            {
                UpdateStatus("Không thể lấy mã nguồn để trích xuất ảnh.", isError: true);
                MessageBox.Show("Trang web chưa tải xong hoặc không có mã nguồn HTML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Trích xuất link ảnh bằng HtmlAgilityPack
            List<string> imageUrls = ExtractImageUrls(html, currentUrl);

            if (imageUrls.Count == 0)
            {
                UpdateStatus("Không tìm thấy hình ảnh nào trên trang web.");
                MessageBox.Show("Không tìm thấy hình ảnh nào (`<img>`) trên trang web này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chọn thư mục lưu
            using var fbd = new FolderBrowserDialog
            {
                Description = $"Tìm thấy {imageUrls.Count} hình ảnh. Vui lòng chọn thư mục để tải về:",
                UseDescriptionForTitle = true
            };

            if (fbd.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                UpdateStatus("Đã hủy tải tài nguyên.");
                return;
            }

            string targetFolder = fbd.SelectedPath;

            // Bắt đầu quá trình tải với hiển thị tiến trình
            SetBusyState(true, imageUrls.Count);

            var progress = new Progress<(int current, int total, string currentUrl)>(report =>
            {
                progressBar.Value = Math.Min(report.current, progressBar.Maximum);
                UpdateStatus($"Đang tải ({report.current}/{report.total}): {Path.GetFileName(report.currentUrl)}");
            });

            var (success, failed, errors) = await DownloadImagesToFolderAsync(imageUrls, targetFolder, progress);

            SetBusyState(false);

            string summaryMsg = $"Hoàn tất tải tài nguyên hình ảnh!\n\n" +
                               $"- Tổng số ảnh tìm thấy: {imageUrls.Count}\n" +
                               $"- Tải thành công: {success}\n" +
                               $"- Thất bại / Bỏ qua: {failed}\n" +
                               $"- Thư mục lưu: {targetFolder}";

            if (errors.Count > 0)
            {
                summaryMsg += $"\n\n(Có {errors.Count} ảnh không thể tải về do liên kết hỏng hoặc chặn truy cập).";
            }

            UpdateStatus($"Hoàn tất tải ảnh: {success}/{imageUrls.Count} thành công.");
            MessageBox.Show(summaryMsg, "Kết quả tải tài nguyên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            SetBusyState(false);
            UpdateStatus($"Lỗi khi tải tài nguyên: {ex.Message}", isError: true);
            MessageBox.Show($"Đã xảy ra lỗi trong quá trình tải tài nguyên:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public List<string> ExtractImageUrls(string htmlContent, string baseUriString)
    {
        var resultUrls = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        if (string.IsNullOrWhiteSpace(htmlContent)) return resultUrls.ToList();

        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(htmlContent);

        Uri? baseUri = null;
        if (!string.IsNullOrWhiteSpace(baseUriString))
        {
            Uri.TryCreate(baseUriString, UriKind.Absolute, out baseUri);
        }

        // Kiểm tra thẻ <base href="..."> trong mã nguồn nếu có
        var baseNode = doc.DocumentNode.SelectSingleNode("//base[@href]");
        if (baseNode != null)
        {
            string? baseHref = baseNode.GetAttributeValue("href", null);
            if (!string.IsNullOrWhiteSpace(baseHref))
            {
                if (baseUri != null && Uri.TryCreate(baseUri, baseHref, out Uri? resolvedBase))
                {
                    baseUri = resolvedBase;
                }
                else
                {
                    Uri.TryCreate(baseHref, UriKind.Absolute, out baseUri);
                }
            }
        }

        var imgNodes = doc.DocumentNode.SelectNodes("//img");
        if (imgNodes != null)
        {
            foreach (var img in imgNodes)
            {
                // Ưu tiên src, nếu rỗng hoặc là data placeholder thì kiểm tra các thuộc tính lazy-load
                string? rawSrc = img.GetAttributeValue("src", null);
                if (string.IsNullOrWhiteSpace(rawSrc) || rawSrc.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
                {
                    string? lazySrc = img.GetAttributeValue("data-src", null)
                                   ?? img.GetAttributeValue("data-original", null)
                                   ?? img.GetAttributeValue("data-lazy-src", null);
                    if (!string.IsNullOrWhiteSpace(lazySrc))
                    {
                        rawSrc = lazySrc;
                    }
                }

                // Kiểm tra thuộc tính srcset nếu vẫn chưa có link ảnh
                if (string.IsNullOrWhiteSpace(rawSrc) || rawSrc.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
                {
                    string? srcset = img.GetAttributeValue("srcset", null);
                    if (!string.IsNullOrWhiteSpace(srcset))
                    {
                        var firstCandidate = srcset.Split(',')[0].Trim().Split(' ')[0].Trim();
                        if (!string.IsNullOrWhiteSpace(firstCandidate))
                        {
                            rawSrc = firstCandidate;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(rawSrc)) continue;

                rawSrc = rawSrc.Trim();

                // Trường hợp ảnh dạng Data URI base64
                if (rawSrc.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
                {
                    resultUrls.Add(rawSrc);
                    continue;
                }

                // Chuyển URL tương đối thành URL tuyệt đối bằng baseUri
                if (baseUri != null)
                {
                    if (Uri.TryCreate(baseUri, rawSrc, out Uri? absoluteUri))
                    {
                        if (absoluteUri.Scheme == Uri.UriSchemeHttp || absoluteUri.Scheme == Uri.UriSchemeHttps)
                        {
                            resultUrls.Add(absoluteUri.AbsoluteUri);
                        }
                    }
                }
                else if (Uri.TryCreate(rawSrc, UriKind.Absolute, out Uri? absoluteUri))
                {
                    if (absoluteUri.Scheme == Uri.UriSchemeHttp || absoluteUri.Scheme == Uri.UriSchemeHttps)
                    {
                        resultUrls.Add(absoluteUri.AbsoluteUri);
                    }
                }
            }
        }

        return resultUrls.ToList();
    }

    public async Task<(int success, int failed, List<string> errors)> DownloadImagesToFolderAsync(
        List<string> imageUrls,
        string targetDirectory,
        IProgress<(int current, int total, string currentUrl)>? progress = null,
        CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(targetDirectory);
        int successCount = 0;
        int failedCount = 0;
        var errorLogs = new List<string>();

        using var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(20);
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

        var usedFileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 0; i < imageUrls.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            string imgUrl = imageUrls[i];
            progress?.Report((i + 1, imageUrls.Count, imgUrl));

            try
            {
                if (imgUrl.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
                {
                    await SaveDataUriImageAsync(imgUrl, targetDirectory, i + 1, usedFileNames);
                    successCount++;
                }
                else
                {
                    using var response = await client.GetAsync(imgUrl, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    byte[] data = await response.Content.ReadAsByteArrayAsync(cancellationToken);
                    string contentType = response.Content.Headers.ContentType?.MediaType ?? string.Empty;

                    string fileName = DetermineSafeFileName(imgUrl, contentType, i + 1, usedFileNames);
                    string destinationPath = Path.Combine(targetDirectory, fileName);

                    await File.WriteAllBytesAsync(destinationPath, data, cancellationToken);
                    successCount++;
                }
            }
            catch (Exception ex)
            {
                failedCount++;
                errorLogs.Add($"[{i + 1}] Lỗi tải {imgUrl}: {ex.Message}");
            }
        }

        return (successCount, failedCount, errorLogs);
    }

    private string DetermineSafeFileName(string url, string contentType, int index, HashSet<string> usedFileNames)
    {
        string fileName = "";
        try
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                string local = Path.GetFileName(uri.LocalPath);
                if (!string.IsNullOrWhiteSpace(local))
                {
                    fileName = local;
                }
            }
        }
        catch { }

        try
        {
            fileName = Uri.UnescapeDataString(fileName);
        }
        catch { }

        foreach (char c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }

        string extension = Path.GetExtension(fileName);
        if (string.IsNullOrWhiteSpace(extension) || extension.Length > 6)
        {
            extension = GetExtensionFromMimeType(contentType);
            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            fileName = string.IsNullOrWhiteSpace(nameWithoutExt) ? $"image_{index}{extension}" : $"{nameWithoutExt}{extension}";
        }
        else if (string.IsNullOrWhiteSpace(Path.GetFileNameWithoutExtension(fileName)))
        {
            fileName = $"image_{index}{extension}";
        }

        string baseName = Path.GetFileNameWithoutExtension(fileName);
        string ext = Path.GetExtension(fileName);
        string candidate = fileName;
        int counter = 1;

        while (usedFileNames.Contains(candidate))
        {
            candidate = $"{baseName}_{counter}{ext}";
            counter++;
        }

        usedFileNames.Add(candidate);
        return candidate;
    }

    private string GetExtensionFromMimeType(string mimeType)
    {
        return mimeType.ToLowerInvariant() switch
        {
            "image/jpeg" or "image/jpg" => ".jpg",
            "image/png" => ".png",
            "image/gif" => ".gif",
            "image/webp" => ".webp",
            "image/svg+xml" => ".svg",
            "image/x-icon" or "image/vnd.microsoft.icon" => ".ico",
            "image/bmp" => ".bmp",
            _ => ".jpg"
        };
    }

    private async Task SaveDataUriImageAsync(string dataUri, string targetDirectory, int index, HashSet<string> usedFileNames)
    {
        int commaIndex = dataUri.IndexOf(',');
        if (commaIndex < 0) throw new FormatException("Data URI không đúng định dạng.");

        string meta = dataUri.Substring(0, commaIndex);
        string base64Data = dataUri.Substring(commaIndex + 1);

        string ext = ".png";
        if (meta.Contains("image/jpeg", StringComparison.OrdinalIgnoreCase)) ext = ".jpg";
        else if (meta.Contains("image/gif", StringComparison.OrdinalIgnoreCase)) ext = ".gif";
        else if (meta.Contains("image/webp", StringComparison.OrdinalIgnoreCase)) ext = ".webp";
        else if (meta.Contains("image/svg+xml", StringComparison.OrdinalIgnoreCase)) ext = ".svg";

        string baseName = $"embedded_img_{index}";
        string candidate = $"{baseName}{ext}";
        int counter = 1;
        while (usedFileNames.Contains(candidate))
        {
            candidate = $"{baseName}_{counter}{ext}";
            counter++;
        }

        string targetPath = Path.Combine(targetDirectory, candidate);
        byte[] bytes = Convert.FromBase64String(base64Data);
        await File.WriteAllBytesAsync(targetPath, bytes);
        usedFileNames.Add(candidate);
    }

    #endregion

    #region Helper & UI State Methods

    private void UpdateStatus(string message, bool isError = false)
    {
        if (InvokeRequired)
        {
            Invoke(() => UpdateStatus(message, isError));
            return;
        }

        lblStatus.Text = message;
        lblStatus.ForeColor = isError ? Color.Firebrick : Color.DimGray;
        lblStatusStrip.Text = $"Trạng thái: {message}";
    }

    private void SetBusyState(bool isBusy, int totalItems = 0)
    {
        if (InvokeRequired)
        {
            Invoke(() => SetBusyState(isBusy, totalItems));
            return;
        }

        btnLoad.Enabled = !isBusy;
        btnReload.Enabled = !isBusy;
        btnViewSource.Enabled = !isBusy;
        btnDownFiles.Enabled = !isBusy;
        btnDownResources.Enabled = !isBusy;

        if (isBusy)
        {
            progressBar.Visible = true;
            progressBar.Maximum = Math.Max(1, totalItems);
            progressBar.Value = 0;
        }
        else
        {
            progressBar.Visible = false;
        }
    }

    #endregion
}
