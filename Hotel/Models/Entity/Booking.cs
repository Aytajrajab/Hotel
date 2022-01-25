using System;

namespace Hotel.Models.Entity
{
    public class Booking : BaseEntity
    {
        public Guest Guest { get; set; }
        public Room RoomId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Fee { get; set; }
        public bool Paid { get; set; }
        public Guid ApplicationUserId { get; set; }
        
    }
}
