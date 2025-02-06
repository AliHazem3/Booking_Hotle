using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotel_APi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        public int? BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking? Booking { get; set; }
    }
}
