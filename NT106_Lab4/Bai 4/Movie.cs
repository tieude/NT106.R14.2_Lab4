using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT106_Lab4.Bai_4
{
    public class Movie
    {
        public string Title { get; set; } = string.Empty;
        public string DetailUrl { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public decimal BasePrice { get; set; } = 75000m;
        public List<int> Rooms { get; set; } = new() { 1, 2, 3 };
        public override string ToString() => Title;
    }

    public class BookingRecord
    {
        public string CustomerName { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public List<string> Seats { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public DateTime BookedAt { get; set; } = DateTime.Now;
    }
}
