using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace NT106_Lab4.Bai7Server;

// May chu HTTP cho Bai 7. Chay tu dong khi mo Bai 7 tren may chu.
public static class MayChuApi
{
    private static WebApplication? appDangChay;
    private static readonly SemaphoreSlim khoaKhoiDong = new(1, 1);

    public static async Task KhoiDong()
    {
        await khoaKhoiDong.WaitAsync();
        try
        {
            if (appDangChay != null) return;
            // Du lieu dat o may dang chay ung dung, khong nam trong source GitHub.
            string thuMucDuLieu = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "NT106_Lab4", "Bai7");
            Directory.CreateDirectory(Path.Combine(thuMucDuLieu, "wwwroot", "anh"));

            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                ContentRootPath = thuMucDuLieu,
                WebRootPath = "wwwroot"
            });
            builder.WebHost.UseUrls("http://0.0.0.0:5050");
            var app = builder.Build();

            string duongDan = Path.Combine(app.Environment.ContentRootPath, "du_lieu.json");
            string thuMucAnh = Path.Combine(app.Environment.ContentRootPath, "wwwroot", "anh");
            Directory.CreateDirectory(thuMucAnh);
            app.UseStaticFiles();

            var khoa = new object();
            DuLieu csdl = File.Exists(duongDan)
                ? JsonSerializer.Deserialize<DuLieu>(File.ReadAllText(duongDan)) ?? new DuLieu()
                : new DuLieu();
            var phienDangNhap = new ConcurrentDictionary<string, int>();

            void LuuDuLieu()
            {
                // Goi trong lock de tranh hai yeu cau cung ghi file.
                string fileTam = duongDan + ".tmp";
                File.WriteAllText(fileTam, JsonSerializer.Serialize(csdl, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
                File.Move(fileTam, duongDan, true);
            }

            NguoiDung? LayNguoiDung(HttpContext ctx)
            {
                string header = ctx.Request.Headers["Authorization"].ToString();
                if (!header.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)) return null;
                string token = header.Substring(7).Trim();
                if (!phienDangNhap.TryGetValue(token, out int id)) return null;
                lock (khoa) return csdl.NguoiDung.FirstOrDefault(u => u.Id == id);
            }

            object ThongTinMon(Mon mon)
            {
                NguoiDung? nguoi = csdl.NguoiDung.FirstOrDefault(u => u.Id == mon.UserId);
                return new
                {
                    id = mon.Id,
                    name = mon.Name,
                    price = mon.Price,
                    address = mon.Address,
                    image = mon.Image,
                    description = mon.Description,
                    user_id = mon.UserId,
                    username = nguoi?.Username ?? ""
                };
            }

            // Kiem tra server dang chay.
            app.MapGet("/", () => Results.Ok(new { message = "Bai 7 API dang hoat dong" }));

            app.MapPost("/api/v1/user/register", async Task<IResult> (HttpContext ctx) =>
            {
                DangKy? data;
                try { data = await ctx.Request.ReadFromJsonAsync<DangKy>(); }
                catch (JsonException) { return Results.BadRequest(new { detail = "Dữ liệu đăng ký không hợp lệ." }); }

                if (data == null || string.IsNullOrWhiteSpace(data.Username) || data.Username.Trim().Length < 3 ||
                    string.IsNullOrEmpty(data.Password) || data.Password.Length < 6)
                    return Results.BadRequest(new { detail = "Tài khoản tối thiểu 3 ký tự, mật khẩu tối thiểu 6 ký tự." });

                lock (khoa)
                {
                    if (csdl.NguoiDung.Any(u => u.Username.Equals(data.Username.Trim(), StringComparison.OrdinalIgnoreCase)))
                        return Results.Conflict(new { detail = "Tài khoản đã tồn tại." });

                    byte[] salt = RandomNumberGenerator.GetBytes(16);
                    byte[] hash = Rfc2898DeriveBytes.Pbkdf2(data.Password, salt, 100_000, HashAlgorithmName.SHA256, 32);
                    int id = csdl.NguoiDung.Count == 0 ? 1 : csdl.NguoiDung.Max(u => u.Id) + 1;
                    csdl.NguoiDung.Add(new NguoiDung
                    {
                        Id = id, Username = data.Username.Trim(), Email = data.Email ?? "",
                        Ho = data.Ho ?? "", Ten = data.Ten ?? "", SoDienThoai = data.SoDienThoai ?? "",
                        NgaySinh = data.NgaySinh ?? "", GioiTinh = data.GioiTinh ?? "",
                        Salt = Convert.ToBase64String(salt), Hash = Convert.ToBase64String(hash)
                    });
                    LuuDuLieu();
                    return Results.Ok(new { message = "Đăng ký thành công" });
                }
            });

            app.MapPost("/auth/token", async Task<IResult> (HttpContext ctx) =>
            {
                if (!ctx.Request.HasFormContentType)
                    return Results.BadRequest(new { detail = "Yêu cầu phải có form-data." });
                var form = await ctx.Request.ReadFormAsync();
                string taiKhoan = form["username"].ToString();
                string matKhau = form["password"].ToString();
                NguoiDung? nguoi;
                lock (khoa) nguoi = csdl.NguoiDung.FirstOrDefault(u =>
                    u.Username.Equals(taiKhoan, StringComparison.OrdinalIgnoreCase));
                if (nguoi == null) return Results.Json(new { detail = "Sai tài khoản hoặc mật khẩu." }, statusCode: 401);

                byte[] kiemTra = Rfc2898DeriveBytes.Pbkdf2(matKhau, Convert.FromBase64String(nguoi.Salt),
                    100_000, HashAlgorithmName.SHA256, 32);
                if (!CryptographicOperations.FixedTimeEquals(kiemTra, Convert.FromBase64String(nguoi.Hash)))
                    return Results.Json(new { detail = "Sai tài khoản hoặc mật khẩu." }, statusCode: 401);

                string token = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
                phienDangNhap[token] = nguoi.Id;
                return Results.Ok(new { access_token = token, token_type = "Bearer" });
            });

            app.MapGet("/api/v1/user/me", IResult (HttpContext ctx) =>
            {
                var nguoi = LayNguoiDung(ctx);
                if (nguoi == null) return Results.Unauthorized();
                return Results.Ok(new { id = nguoi.Id, username = nguoi.Username, email = nguoi.Email });
            });

            IResult DanhSach(HttpContext ctx, bool cuaToi, int page, int page_size)
            {
                var nguoi = LayNguoiDung(ctx);
                if (nguoi == null) return Results.Unauthorized();
                int trang = Math.Max(1, page);
                int soMon = Math.Clamp(page_size, 1, 50);
                lock (khoa)
                {
                    var danhSach = csdl.MonAn.Where(m => !cuaToi || m.UserId == nguoi.Id)
                        .OrderByDescending(m => m.Id).ToList();
                    return Results.Ok(new
                    {
                        total = danhSach.Count,
                        items = danhSach.Skip((trang - 1) * soMon).Take(soMon).Select(ThongTinMon).ToList()
                    });
                }
            }

            app.MapGet("/api/v1/food", (HttpContext ctx, int page = 1, int page_size = 5) =>
                DanhSach(ctx, false, page, page_size));

            app.MapGet("/api/v1/food/me", (HttpContext ctx, int page = 1, int page_size = 5) =>
                DanhSach(ctx, true, page, page_size));

            app.MapPost("/api/v1/food", async Task<IResult> (HttpContext ctx) =>
            {
                var nguoi = LayNguoiDung(ctx);
                if (nguoi == null) return Results.Unauthorized();
                ThemMon? data;
                try { data = await ctx.Request.ReadFromJsonAsync<ThemMon>(); }
                catch (JsonException) { return Results.BadRequest(new { detail = "Dữ liệu món ăn không hợp lệ." }); }
                if (data == null || string.IsNullOrWhiteSpace(data.Name) || data.Price < 0)
                    return Results.BadRequest(new { detail = "Tên món và giá không hợp lệ." });

                lock (khoa)
                {
                    int id = csdl.MonAn.Count == 0 ? 1 : csdl.MonAn.Max(m => m.Id) + 1;
                    Mon mon = new Mon
                    {
                        Id = id, UserId = nguoi.Id, Name = data.Name.Trim(), Price = data.Price,
                        Address = data.Address ?? "", Image = data.Image ?? "", Description = data.Description ?? ""
                    };
                    csdl.MonAn.Add(mon);
                    LuuDuLieu();
                    return Results.Ok(ThongTinMon(mon));
                }
            });

            app.MapDelete("/api/v1/food/{id:int}", IResult (HttpContext ctx, int id) =>
            {
                var nguoi = LayNguoiDung(ctx);
                if (nguoi == null) return Results.Unauthorized();
                lock (khoa)
                {
                    Mon? mon = csdl.MonAn.FirstOrDefault(m => m.Id == id);
                    if (mon == null) return Results.NotFound(new { detail = "Không tìm thấy món ăn." });
                    if (mon.UserId != nguoi.Id)
                        return Results.Json(new { detail = "Chỉ được xóa món ăn của mình." }, statusCode: 403);
                    csdl.MonAn.Remove(mon);
                    LuuDuLieu();
                    return Results.Ok(new { message = "Đã xóa món ăn." });
                }
            });

            // Anh tai tu may nguoi dung duoc luu tren server de may khac cung xem duoc.
            app.MapPost("/api/v1/food/image", async Task<IResult> (HttpContext ctx) =>
            {
                if (LayNguoiDung(ctx) == null) return Results.Unauthorized();
                if (!ctx.Request.HasFormContentType)
                    return Results.BadRequest(new { detail = "Cần gửi ảnh bằng form-data." });
                var form = await ctx.Request.ReadFormAsync();
                IFormFile? anh = form.Files["image"];
                if (anh == null || anh.Length == 0 || anh.Length > 3 * 1024 * 1024)
                    return Results.BadRequest(new { detail = "Chọn ảnh không quá 3 MB." });
                string duoi = Path.GetExtension(anh.FileName).ToLowerInvariant();
                if (duoi != ".jpg" && duoi != ".jpeg" && duoi != ".png")
                    return Results.BadRequest(new { detail = "Chỉ hỗ trợ ảnh JPG hoặc PNG." });
                string tenFile = Guid.NewGuid().ToString("N") + duoi;
                await using (var file = File.Create(Path.Combine(thuMucAnh, tenFile)))
                    await anh.CopyToAsync(file);
                string url = "/anh/" + tenFile;
                return Results.Ok(new { url });
            });

            await app.StartAsync();
            appDangChay = app;

        }
        finally
        {
            khoaKhoiDong.Release();
        }
    }
}

class DuLieu
{
    public List<NguoiDung> NguoiDung { get; set; } = new();
    public List<Mon> MonAn { get; set; } = new();
}

class NguoiDung
{
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string Ho { get; set; } = "";
    public string Ten { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string NgaySinh { get; set; } = "";
    public string GioiTinh { get; set; } = "";
    public string Salt { get; set; } = "";
    public string Hash { get; set; } = "";
}

class Mon
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string Address { get; set; } = "";
    public string Image { get; set; } = "";
    public string Description { get; set; } = "";
}

class DangKy
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string? Email { get; set; }
    [JsonPropertyName("first_name")] public string? Ho { get; set; }
    [JsonPropertyName("last_name")] public string? Ten { get; set; }
    [JsonPropertyName("phone")] public string? SoDienThoai { get; set; }
    [JsonPropertyName("birthday")] public string? NgaySinh { get; set; }
    [JsonPropertyName("sex")] public string? GioiTinh { get; set; }
}

class ThemMon
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string? Address { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}
