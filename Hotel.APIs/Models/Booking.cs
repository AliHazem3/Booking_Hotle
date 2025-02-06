using System.ComponentModel.DataAnnotations;

namespace BookingHotel_APi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;

 
        [MaxLength(14)]
        [MinLength(14)]
        public string NationalId { get; set; } = string.Empty;
 
        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
        public string HotelBranch { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string NumberOFRooms { get; set; } = string.Empty;
        public bool HasBookedBefore { get; set; }  


    }
}
