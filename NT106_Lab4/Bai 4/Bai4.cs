using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace NT106_Lab4.Bai_4;

public partial class Bai4 : Form
{
    private readonly List<Movie> _movies = new();
    private readonly Dictionary<string, HashSet<string>> _soldSeatsByShow = new();
    private readonly List<BookingRecord> _bookingHistory = new();
    private readonly string _jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.json");
    private readonly string _soldSeatsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sold_seats.json");
    private readonly string _bookingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bookings.json");

    private static readonly HttpClient HttpClient = CreateHttpClient();

    public Bai4()
    {
        InitializeComponent();
        LoadSoldSeatsFromJson();
        LoadBookingsFromJson();
    }

    private static HttpClient CreateHttpClient()
    {
        var client = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };
        client.DefaultRequestHeaders.UserAgent.ParseAdd(
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
        return client;
    }

    private async void Bai4_Load(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtURL.Text))
            txtURL.Text = "https://betacinemas.vn/phim.htm";

        await LoadMoviesFromWebAsync();
    }

    private async void btnFetch_Click(object? sender, EventArgs e)
    {
        await LoadMoviesFromWebAsync();
    }

    private async Task LoadMoviesFromWebAsync()
    {
        string url = txtURL.Text.Trim();
        if (string.IsNullOrEmpty(url))
        {
            MessageBox.Show("Vui lòng nhập đường dẫn website.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnFetch.Enabled = false;
        progressBar.Value = 0;
        lblStatus.Text = "Đang kết nối và tải mã nguồn HTML...";

        try
        {
            string html = await HttpClient.GetStringAsync(url);
            progressBar.Value = 25;
            lblStatus.Text = "Đang phân tích danh sách phim...";

            List<Movie> parsed = ParseMoviesFromHtml(html, url);
            if (parsed.Count == 0)
            {
                throw new InvalidOperationException("Không tìm thấy danh sách phim từ cấu trúc HTML.");
            }

            _movies.Clear();
            _movies.AddRange(parsed);
            SaveMoviesToJson(_movies);

            await RenderMovieCardsAsync(_movies);

            progressBar.Value = 100;
            lblStatus.Text = $"Hoàn tất! Đã tải {_movies.Count} phim và lưu vào movies.json.";
        }
        catch (Exception ex)
        {
            if (TryLoadMoviesFromJson(out List<Movie> cached) && cached.Count > 0)
            {
                _movies.Clear();
                _movies.AddRange(cached);
                await RenderMovieCardsAsync(_movies);
                progressBar.Value = 100;
                lblStatus.Text = $"Không thể kết nối web ({ex.Message}). Đã nạp {_movies.Count} phim từ movies.json.";
            }
            else
            {
                _movies.Clear();
                _movies.AddRange(GetFallbackMovies());
                SaveMoviesToJson(_movies);
                await RenderMovieCardsAsync(_movies);
                progressBar.Value = 100;
                lblStatus.Text = $"Lỗi tải web ({ex.Message}). Đã nạp {_movies.Count} phim mẫu vào movies.json.";
            }
        }
        finally
        {
            btnFetch.Enabled = true;
        }
    }

    private static List<Movie> ParseMoviesFromHtml(string html, string baseUrl)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var movies = new List<Movie>();
        var seenUrls = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        Uri baseUri = new(baseUrl);

        var linkNodes = doc.DocumentNode.SelectNodes("//a[contains(@href, 'chi-tiet-phim')]");
        if (linkNodes == null) return movies;

        foreach (var link in linkNodes)
        {
            string href = link.GetAttributeValue("href", "").Trim();
            if (string.IsNullOrEmpty(href)) continue;

            string fullUrl = new Uri(baseUri, href).ToString();
            if (!seenUrls.Add(fullUrl)) continue;

            HtmlNode? cardNode = link.Ancestors("div")
                .FirstOrDefault(d => d.SelectSingleNode(".//div[contains(@class, 'pi-img-wrapper')]//img") != null)
                ?? link.Ancestors("div").FirstOrDefault(d => d.SelectSingleNode(".//img[not(contains(@src, 'icon'))]") != null)
                ?? link.Ancestors("div").FirstOrDefault();

            string title = HtmlEntity.DeEntitize(
                cardNode?.SelectSingleNode(".//h3//a | .//h3 | .//h4")?.InnerText ?? link.InnerText).Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                title = link.GetAttributeValue("title", "").Trim();
            }
            if (string.IsNullOrWhiteSpace(title)) continue;

            var imgNode = cardNode?.SelectSingleNode(".//div[contains(@class, 'pi-img-wrapper')]//img[not(contains(@src, 'icon'))]")
                       ?? cardNode?.SelectSingleNode(".//img[not(contains(@src, 'icon'))]")
                       ?? link.SelectSingleNode(".//img");
            string imgSrc = imgNode?.GetAttributeValue("src", "") ?? "";
            if (string.IsNullOrWhiteSpace(imgSrc))
                imgSrc = imgNode?.GetAttributeValue("data-src", "") ?? "";
            string posterUrl = string.IsNullOrWhiteSpace(imgSrc) ? "" : new Uri(baseUri, imgSrc).ToString();

            string genre = System.Text.RegularExpressions.Regex.Replace(
                HtmlEntity.DeEntitize(cardNode?.SelectSingleNode(".//*[contains(text(),'Thể loại')]")?.ParentNode?.InnerText ?? ""),
                @"\s+", " ").Trim();
            string duration = System.Text.RegularExpressions.Regex.Replace(
                HtmlEntity.DeEntitize(cardNode?.SelectSingleNode(".//*[contains(text(),'Thời lượng')]")?.ParentNode?.InnerText ?? ""),
                @"\s+", " ").Trim();

            movies.Add(new Movie
            {
                Title = title,
                DetailUrl = fullUrl,
                PosterUrl = posterUrl,
                Genre = genre,
                Duration = duration
            });
        }

        return movies;
    }

    private async Task RenderMovieCardsAsync(List<Movie> movies)
    {
        flpMovies.SuspendLayout();
        flpMovies.Controls.Clear();
        flpMovies.ResumeLayout();

        int total = movies.Count;
        for (int i = 0; i < total; i++)
        {
            Movie movie = movies[i];
            Panel card = CreateMovieCard(movie);
            flpMovies.Controls.Add(card);

            if (card.Tag is PictureBox pic && !string.IsNullOrWhiteSpace(movie.PosterUrl))
            {
                await LoadPosterAsync(pic, movie.PosterUrl);
            }

            int percent = 25 + (int)(((i + 1) / (double)total) * 75);
            progressBar.Value = Math.Min(100, percent);
            lblStatus.Text = $"Đang xử lý phim {i + 1}/{total}: {movie.Title}";
        }
    }

    private Panel CreateMovieCard(Movie movie)
    {
        int cardWidth = Math.Max(660, flpMovies.ClientSize.Width - 45);

        Panel card = new()
        {
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(0, 0, 0, 12),
            Padding = new Padding(10),
            Size = new Size(cardWidth, 132)
        };

        PictureBox picPoster = new()
        {
            BackColor = Color.FromArgb(236, 240, 241),
            Cursor = Cursors.Hand,
            Location = new Point(10, 10),
            Size = new Size(82, 110),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        picPoster.Click += (_, _) => OpenMovieDetail(movie);
        card.Tag = picPoster;

        Label lblMovieTitle = new()
        {
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.FromArgb(192, 57, 43),
            Location = new Point(106, 12),
            Size = new Size(cardWidth - 240, 26),
            Text = movie.Title
        };

        Label lblMeta = new()
        {
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 9F, FontStyle.Regular),
            ForeColor = Color.DimGray,
            Location = new Point(106, 42),
            Size = new Size(cardWidth - 240, 22),
            Text = string.IsNullOrWhiteSpace(movie.Genre)
                ? $"Giá vé chuẩn: {movie.BasePrice:N0} VNĐ"
                : string.Join("  |  ", new[] { movie.Genre, movie.Duration }.Where(s => !string.IsNullOrWhiteSpace(s)))
        };

        LinkLabel lnkDetail = new()
        {
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 9F, FontStyle.Regular),
            Location = new Point(106, 72),
            Size = new Size(cardWidth - 240, 22),
            Text = movie.DetailUrl
        };
        lnkDetail.LinkClicked += (_, _) => OpenMovieDetail(movie);

        Label lblHint = new()
        {
            Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
            ForeColor = Color.Gray,
            Location = new Point(106, 98),
            Size = new Size(cardWidth - 240, 20),
            Text = "Nhấn vào banner hoặc đường dẫn để xem chi tiết phim"
        };

        Button btnBook = new()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            BackColor = Color.FromArgb(41, 128, 185),
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Color.White,
            Location = new Point(cardWidth - 120, 44),
            Size = new Size(105, 40),
            Text = "Đặt vé"
        };
        btnBook.FlatAppearance.BorderSize = 0;
        btnBook.Click += (_, _) => OpenBookingForm(movie);

        card.Controls.Add(picPoster);
        card.Controls.Add(lblMovieTitle);
        card.Controls.Add(lblMeta);
        card.Controls.Add(lnkDetail);
        card.Controls.Add(lblHint);
        card.Controls.Add(btnBook);

        return card;
    }

    private static async Task LoadPosterAsync(PictureBox pic, string imageUrl)
    {
        try
        {
            byte[] bytes = await HttpClient.GetByteArrayAsync(imageUrl);
            using var ms = new MemoryStream(bytes);
            using var img = Image.FromStream(ms);
            pic.Image = new Bitmap(img);
        }
        catch
        {
            // Bỏ qua nếu ảnh không tải được
        }
    }

    private void OpenMovieDetail(Movie movie)
    {
        if (string.IsNullOrWhiteSpace(movie.DetailUrl)) return;
        using var detailForm = new ChiTiet_Phim(movie.Title, movie.DetailUrl);
        detailForm.ShowDialog(this);
    }

    private void OpenBookingForm(Movie? preselectedMovie = null)
    {
        if (_movies.Count == 0)
        {
            MessageBox.Show("Chưa có dữ liệu phim. Vui lòng nhấn \"Tải phim\" trước.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var bookingForm = new DatVe(_movies, _soldSeatsByShow, _bookingHistory, preselectedMovie, OnBookingConfirmed);
        bookingForm.ShowDialog(this);
    }

    private void OnBookingConfirmed(BookingRecord record)
    {
        _bookingHistory.Add(record);
        SaveSoldSeatsToJson();
        SaveBookingsToJson();
    }

    private void LoadBookingsFromJson()
    {
        if (!File.Exists(_bookingsFilePath)) return;
        try
        {
            string json = File.ReadAllText(_bookingsFilePath);
            var loaded = JsonSerializer.Deserialize<List<BookingRecord>>(json);
            if (loaded == null) return;
            _bookingHistory.Clear();
            _bookingHistory.AddRange(loaded);
        }
        catch
        {
            // Bỏ qua nếu file lưu hóa đơn bị lỗi
        }
    }

    private void SaveBookingsToJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        File.WriteAllText(_bookingsFilePath, JsonSerializer.Serialize(_bookingHistory, options));
    }

    private void LoadSoldSeatsFromJson()
    {
        if (!File.Exists(_soldSeatsFilePath)) return;
        try
        {
            string json = File.ReadAllText(_soldSeatsFilePath);
            var loaded = JsonSerializer.Deserialize<Dictionary<string, HashSet<string>>>(json);
            if (loaded == null) return;
            _soldSeatsByShow.Clear();
            foreach (var kvp in loaded)
                _soldSeatsByShow[kvp.Key] = kvp.Value;
        }
        catch
        {
            // Bỏ qua nếu file lưu ghế bị lỗi
        }
    }

    private void SaveSoldSeatsToJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        File.WriteAllText(_soldSeatsFilePath, JsonSerializer.Serialize(_soldSeatsByShow, options));
    }

    private void btnOpenBooking_Click(object? sender, EventArgs e) => OpenBookingForm();

    private void SaveMoviesToJson(List<Movie> movies)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        string json = JsonSerializer.Serialize(movies, options);
        File.WriteAllText(_jsonFilePath, json);
    }

    private bool TryLoadMoviesFromJson(out List<Movie> movies)
    {
        movies = new List<Movie>();
        if (!File.Exists(_jsonFilePath)) return false;

        try
        {
            string json = File.ReadAllText(_jsonFilePath);
            movies = JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
            return movies.Count > 0;
        }
        catch
        {
            return false;
        }
    }

    private static List<Movie> GetFallbackMovies() => new()
    {
        new Movie
        {
            Title = "Lật Mặt 7: Một Điều Ước",
            DetailUrl = "https://betacinemas.vn/phim.htm",
            Genre = "Tâm lý, Gia đình",
            Duration = "138 phút",
            BasePrice = 75000m,
            Rooms = new List<int> { 1, 2, 3 }
        },
        new Movie
        {
            Title = "Cái Giá Của Hạnh Phúc",
            DetailUrl = "https://betacinemas.vn/phim.htm",
            Genre = "Tâm lý, Chính kịch",
            Duration = "115 phút",
            BasePrice = 80000m,
            Rooms = new List<int> { 1, 2 }
        },
        new Movie
        {
            Title = "Thanh Xuân 18x2: Lữ Trình Hướng Về Em",
            DetailUrl = "https://betacinemas.vn/phim.htm",
            Genre = "Tình cảm, Lãng mạn",
            Duration = "123 phút",
            BasePrice = 70000m,
            Rooms = new List<int> { 2, 3 }
        }
    };

    private void flpMovies_Resize(object? sender, EventArgs e)
    {
        int newWidth = Math.Max(660, flpMovies.ClientSize.Width - 45);
        foreach (Control c in flpMovies.Controls)
        {
            if (c is Panel card) card.Width = newWidth;
        }
    }
}