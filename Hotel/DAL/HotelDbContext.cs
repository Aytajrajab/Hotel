﻿using Hotel.Models;
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
        public DbSet<Footer> Footers { get; set; }
        public DbSet<CommentSection> Comments { get; set; }
        public DbSet<HotelInfo> HotelInfos { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomImageSlider> RoomImages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TopBarSection> TopBars { get; set; }




    }
}
