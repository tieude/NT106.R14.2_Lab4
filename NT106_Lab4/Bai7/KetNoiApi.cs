using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace NT106_Lab4.Bai7;

public class KetNoiApi : IDisposable
{
    // May chay tren cung may: localhost. May khac trong LAN: doi thanh IP may chay API.
    // Doi thanh IP may chu khi chay tren may khac trong LAN.
    private const string Server = "http://localhost:5050";
    public static bool DungServerTaiCho =>
        new Uri(Server).Host is "localhost" or "127.0.0.1";
    private readonly HttpClient http = new() { BaseAddress = new Uri(Server), Timeout = TimeSpan.FromSeconds(15) };
    private string token = "";

    public string TenDangNhap { get; private set; } = "";
    public string MaNguoiDung { get; private set; } = "";

    private async Task<JsonElement> Gui(HttpRequestMessage request)
    {
        if (token != "")
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        try
        {
            using (request)
            using (HttpResponseMessage response = await http.SendAsync(request))
            {
                string noiDung = await response.Content.ReadAsStringAsync();
                JsonElement json;
                try { json = JsonDocument.Parse(noiDung).RootElement.Clone(); }
                catch { throw new Exception("Server trả về dữ liệu không hợp lệ."); }

                if (!response.IsSuccessStatusCode)
                {
                    string loi = json.TryGetProperty("detail", out var detail)
                        ? detail.ToString() : "Lỗi HTTP " + (int)response.StatusCode;
                    throw new Exception(loi);
                }
                return json;
            }
        }
        catch (TaskCanceledException)
        {
            throw new Exception("Không nhận được phản hồi từ API. Hãy kiểm tra server đã chạy chưa.");
        }
        catch (HttpRequestException)
        {
            throw new Exception("Không kết nối được đến " + Server + ". Hãy kiểm tra API đã khởi động.");
        }
    }

    public async Task DangKy(string taiKhoan, string matKhau, string email,
        string ho, string ten, string soDienThoai, DateTime ngaySinh, string gioiTinh)
    {
        var data = new
        {
            username = taiKhoan, password = matKhau, email,
            first_name = ho, last_name = ten, phone = soDienThoai,
            birthday = ngaySinh.ToString("yyyy-MM-dd"), sex = gioiTinh
        };
        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1/user/register")
        { Content = JsonContent.Create(data) };
        await Gui(request);
    }

    public async Task DangNhap(string taiKhoan, string matKhau)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "/auth/token");
        request.Content = new MultipartFormDataContent
        {
            { new StringContent(taiKhoan), "username" },
            { new StringContent(matKhau), "password" }
        };
        JsonElement ketQua = await Gui(request);
        token = ketQua.GetProperty("access_token").GetString() ?? "";
        TenDangNhap = taiKhoan;
        JsonElement me = await Gui(new HttpRequestMessage(HttpMethod.Get, "/api/v1/user/me"));
        MaNguoiDung = me.GetProperty("id").ToString();
        TenDangNhap = me.GetProperty("username").GetString() ?? taiKhoan;
    }

    public async Task<(List<MonAn> DanhSach, int Tong)> LayDanhSach(bool cuaToi, int trang, int soMon)
    {
        string url = cuaToi ? "/api/v1/food/me" : "/api/v1/food";
        JsonElement ketQua = await Gui(new HttpRequestMessage(HttpMethod.Get,
            $"{url}?page={trang}&page_size={soMon}"));
        var danhSach = new List<MonAn>();
        foreach (JsonElement item in ketQua.GetProperty("items").EnumerateArray())
        {
            danhSach.Add(new MonAn
            {
                Id = item.GetProperty("id").ToString(),
                TenMon = item.GetProperty("name").GetString() ?? "",
                Gia = item.GetProperty("price").GetDecimal(),
                DiaChi = item.GetProperty("address").GetString() ?? "",
                HinhAnh = DuongDanAnh(item.GetProperty("image").GetString() ?? ""),
                MoTa = item.GetProperty("description").GetString() ?? "",
                NguoiThem = item.GetProperty("username").GetString() ?? "",
                MaNguoiThem = item.GetProperty("user_id").ToString()
            });
        }
        return (danhSach, ketQua.GetProperty("total").GetInt32());
    }

    private static string DuongDanAnh(string anh)
    {
        return anh.StartsWith("/") ? Server + anh : anh;
    }

    public async Task ThemMon(MonAn mon)
    {
        string anh = mon.HinhAnh;
        if (File.Exists(anh))
        {
            using var form = new MultipartFormDataContent();
            using var stream = File.OpenRead(anh);
            using var file = new StreamContent(stream);
            form.Add(file, "image", Path.GetFileName(anh));
            using var requestAnh = new HttpRequestMessage(HttpMethod.Post, "/api/v1/food/image")
            { Content = form };
            JsonElement ketQuaAnh = await Gui(requestAnh);
            anh = ketQuaAnh.GetProperty("url").GetString() ?? "";
        }
        var data = new
        {
            name = mon.TenMon, price = mon.Gia, address = mon.DiaChi,
            image = anh, description = mon.MoTa
        };
        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1/food")
        { Content = JsonContent.Create(data) };
        await Gui(request);
    }

    public async Task XoaMon(string id)
    {
        await Gui(new HttpRequestMessage(HttpMethod.Delete,
            "/api/v1/food/" + Uri.EscapeDataString(id)));
    }

    public async Task<MonAn?> ChonNgauNhien(bool cuaToi)
    {
        const int moiTrang = 5;
        var dau = await LayDanhSach(cuaToi, 1, moiTrang);
        if (dau.Tong == 0) return null;
        int stt = Random.Shared.Next(dau.Tong);
        int trang = stt / moiTrang + 1;
        var ds = trang == 1 ? dau.DanhSach : (await LayDanhSach(cuaToi, trang, moiTrang)).DanhSach;
        return ds[stt % moiTrang];
    }

    public void Dispose() => http.Dispose();
}
