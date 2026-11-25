using Microsoft.EntityFrameworkCore;
using Travelstay.Domain.Entity;

namespace Travelstay.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
            public DbSet<TourBooking> TourBookings { get; set; }
            public DbSet<RoomReservation> RoomReservations { get; set; }
       

    }
}
