using System.Collections;
using System.Collections.Generic;

namespace Hotel.Models.Entity
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Area { get; set; }
        public int Quantity { get; set; }
        public bool Availabilities { get; set; }
        public Room RoomId { get; set; }
        public HotelInfo HotelId { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
