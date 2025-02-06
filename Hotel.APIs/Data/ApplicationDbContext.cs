using BookingHotel_APi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel_APi.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
    }
}
