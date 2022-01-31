using System;

namespace Hotel.Models.Entity
{
    public class Booking : BaseEntity
    {
        public Guest Guest { get; set; }
        public int GuestId { get; set; }
        public HotelInfo HotelInfo { get; set; }
        public int HotelId { get; set; }
        public Room Room { get; set; }
        public int? RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Fee { get; set; }
        public int Quantity { get; set; }
        public bool Paid { get; set; }
        
    }
}
