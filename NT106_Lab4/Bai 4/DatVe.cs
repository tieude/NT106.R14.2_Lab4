using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NT106_Lab4.Bai_4;

public partial class DatVe : Form
{
    private readonly List<Movie> _movies;
    private readonly Dictionary<string, HashSet<string>> _soldSeatsByShow;
    private readonly IReadOnlyList<BookingRecord> _bookingHistory;
    private readonly Action<BookingRecord>? _onBookingConfirmed;
    private readonly Dictionary<string, Button> _seatButtons = new();
    private readonly HashSet<string> _selectedSeats = new();

    private static readonly HashSet<string> DiscountSeats = new() { "A1", "A5", "C1", "C5" };
    private static readonly HashSet<string> VipSeats = new() { "B2", "B3", "B4" };

    public DatVe(
        List<Movie> movies,
        Dictionary<string, HashSet<string>> soldSeatsByShow,
        IReadOnlyList<BookingRecord> bookingHistory,
        Movie? preselectedMovie = null,
        Action<BookingRecord>? onBookingConfirmed = null)
    {
        InitializeComponent();
        _movies = movies;
        _soldSeatsByShow = soldSeatsByShow;
        _bookingHistory = bookingHistory;
        _onBookingConfirmed = onBookingConfirmed;

        InitializeSeatGrid();
        LoadMovies(preselectedMovie);
    }

    private void InitializeSeatGrid()
    {
        tlpSeats.Controls.Clear();
        _seatButtons.Clear();

        string[] rows = { "A", "B", "C" };
        for (int r = 0; r < rows.Length; r++)
        {
            for (int c = 1; c <= 5; c++)
            {
                string seatCode = $"{rows[r]}{c}";
                Button btnSeat = new()
                {
                    Text = seatCode,
                    Tag = seatCode,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(6),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnSeat.FlatAppearance.BorderSize = 1;
                btnSeat.FlatAppearance.BorderColor = Color.Silver;
                btnSeat.Click += SeatButton_Click;

                _seatButtons[seatCode] = btnSeat;
                tlpSeats.Controls.Add(btnSeat, c - 1, r);
            }
        }
    }

    private void LoadMovies(Movie? preselectedMovie)
    {
        cboMovie.DataSource = null;
        cboMovie.DataSource = _movies;
        cboMovie.DisplayMember = nameof(Movie.Title);

        if (preselectedMovie != null)
        {
            int idx = _movies.FindIndex(m => m.Title == preselectedMovie.Title);
            if (idx >= 0) cboMovie.SelectedIndex = idx;
        }
        else if (_movies.Count > 0)
        {
            cboMovie.SelectedIndex = 0;
        }

        LoadRoomsForSelectedMovie();
    }

    private void LoadRoomsForSelectedMovie()
    {
        if (cboMovie.SelectedItem is not Movie movie) return;

        cboRoom.Items.Clear();
        foreach (int room in movie.Rooms)
        {
            cboRoom.Items.Add($"Phòng {room}");
        }
        if (cboRoom.Items.Count > 0) cboRoom.SelectedIndex = 0;

        lblBasePrice.Text = $"Giá vé chuẩn: {movie.BasePrice:N0} VNĐ";
        RefreshSeatStates();
    }

    private void cboSelection_Changed(object? sender, EventArgs e)
    {
        if (sender == cboMovie)
        {
            LoadRoomsForSelectedMovie();
            return;
        }
        RefreshSeatStates();
    }

    private string GetCurrentShowKey()
    {
        string movieTitle = (cboMovie.SelectedItem as Movie)?.Title ?? string.Empty;
        string room = cboRoom.SelectedItem?.ToString() ?? string.Empty;
        return $"{movieTitle}||{room}";
    }

    private void RefreshSeatStates()
    {
        _selectedSeats.Clear();
        string showKey = GetCurrentShowKey();
        _soldSeatsByShow.TryGetValue(showKey, out HashSet<string>? soldSeats);

        foreach (var kvp in _seatButtons)
        {
            string code = kvp.Key;
            Button btn = kvp.Value;

            if (soldSeats != null && soldSeats.Contains(code))
            {
                btn.Enabled = false;
                btn.BackColor = Color.FromArgb(231, 76, 60);
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.Enabled = true;
                btn.BackColor = GetDefaultSeatColor(code);
                btn.ForeColor = Color.Black;
            }
        }

        UpdateSummary();
    }

    private static Color GetDefaultSeatColor(string seatCode) => Color.White;

    private void SeatButton_Click(object? sender, EventArgs e)
    {
        if (sender is not Button btn || btn.Tag is not string seatCode) return;

        if (_selectedSeats.Contains(seatCode))
        {
            _selectedSeats.Remove(seatCode);
            btn.BackColor = GetDefaultSeatColor(seatCode);
            btn.ForeColor = Color.Black;
        }
        else
        {
            _selectedSeats.Add(seatCode);
            btn.BackColor = Color.FromArgb(230, 126, 34);
            btn.ForeColor = Color.White;
        }

        UpdateSummary();
    }

    private decimal GetSeatPrice(string seatCode, decimal basePrice)
    {
        if (DiscountSeats.Contains(seatCode)) return basePrice * 0.25m;
        if (VipSeats.Contains(seatCode)) return basePrice * 2.0m;
        return basePrice;
    }

    private decimal CalculateTotal(decimal basePrice) =>
        _selectedSeats.Sum(s => GetSeatPrice(s, basePrice));

    private void UpdateSummary()
    {
        if (cboMovie.SelectedItem is not Movie movie || _selectedSeats.Count == 0)
        {
            lblSelectedInfo.Text = "Ghế đang chọn: Chưa chọn";
            lblTotalPrice.Text = "Tổng tiền: 0 VNĐ";
            return;
        }

        var sorted = _selectedSeats.OrderBy(s => s).ToList();
        decimal total = CalculateTotal(movie.BasePrice);
        lblSelectedInfo.Text = $"Ghế đang chọn: {string.Join(", ", sorted)} ({sorted.Count} vé)";
        lblTotalPrice.Text = $"Tổng tiền: {total:N0} VNĐ";
    }

    private void btnConfirm_Click(object? sender, EventArgs e)
    {
        string customerName = txtCustomerName.Text.Trim();
        if (string.IsNullOrEmpty(customerName))
        {
            MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCustomerName.Focus();
            return;
        }

        if (cboMovie.SelectedItem is not Movie movie || cboRoom.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng chọn phim và phòng chiếu.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_selectedSeats.Count == 0)
        {
            MessageBox.Show("Vui lòng chọn ít nhất 1 ghế.", "Chưa chọn ghế",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string showKey = GetCurrentShowKey();
        if (!_soldSeatsByShow.ContainsKey(showKey))
            _soldSeatsByShow[showKey] = new HashSet<string>();

        var bookedSeats = _selectedSeats.OrderBy(s => s).ToList();
        foreach (string seat in bookedSeats)
            _soldSeatsByShow[showKey].Add(seat);

        decimal total = CalculateTotal(movie.BasePrice);
        string roomName = cboRoom.SelectedItem.ToString() ?? string.Empty;

        var record = new BookingRecord
        {
            CustomerName = customerName,
            MovieTitle = movie.Title,
            Room = roomName,
            Seats = bookedSeats,
            TotalAmount = total,
            BookedAt = DateTime.Now
        };
        _onBookingConfirmed?.Invoke(record);

        MessageBox.Show(
            $"ĐẶT VÉ THÀNH CÔNG!\n\n" +
            $"Khách hàng: {customerName}\n" +
            $"Phim: {movie.Title}\n" +
            $"Phòng chiếu: {roomName}\n" +
            $"Vé đã đặt: {string.Join(", ", bookedSeats)} ({bookedSeats.Count} vé)\n" +
            $"Tổng thanh toán: {total:N0} VNĐ",
            "Thông báo đặt vé",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );

        txtCustomerName.Clear();
        RefreshSeatStates();
    }

    private void btnExportInfo_Click(object? sender, EventArgs e)
    {
        if (_bookingHistory.Count == 0)
        {
            MessageBox.Show("Chưa có vé nào được đặt.", "Thông tin vé",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        BookingRecord highest = _bookingHistory.OrderByDescending(b => b.TotalAmount).First();

        var sb = new System.Text.StringBuilder();
        sb.AppendLine("DANH SÁCH CÁC VÉ ĐÃ ĐƯỢC ĐẶT:");
        sb.AppendLine("----------------------------------------");
        for (int i = 0; i < _bookingHistory.Count; i++)
        {
            BookingRecord b = _bookingHistory[i];
            sb.AppendLine($"{i + 1}. {b.CustomerName} | {b.MovieTitle} | {b.Room} | Ghế: {string.Join(", ", b.Seats)} | {b.TotalAmount:N0} VNĐ");
        }
        sb.AppendLine();
        sb.AppendLine("HÓA ĐƠN CÓ GIÁ TRỊ CAO NHẤT:");
        sb.AppendLine("----------------------------------------");
        sb.AppendLine($"Khách hàng: {highest.CustomerName}");
        sb.AppendLine($"Phim: {highest.MovieTitle}");
        sb.AppendLine($"Phòng: {highest.Room}");
        sb.AppendLine($"Ghế đã đặt: {string.Join(", ", highest.Seats)}");
        sb.AppendLine($"Tổng tiền: {highest.TotalAmount:N0} VNĐ");

        using var infoForm = new Form
        {
            Text = "Thông tin các vé đã đặt",
            Size = new Size(620, 400),
            StartPosition = FormStartPosition.CenterParent
        };
        var txtInfo = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Font = new Font("Segoe UI", 10F),
            Text = sb.ToString()
        };
        infoForm.Controls.Add(txtInfo);
        infoForm.ShowDialog(this);
    }
}
