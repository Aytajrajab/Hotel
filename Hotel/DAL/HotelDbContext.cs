using Hotel.Models;
using Hotel.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DAL
{
    public class HotelDbContext :IdentityDbContext<User>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        public DbSet<CommentSection> Comments { get; set; }
        public DbSet<HotelInfo> HotelInfos { get; set; }
        public DbSet<HotelCategory> HotelCategories { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImage> RoomImages  { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TopBarSection> TopBars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
