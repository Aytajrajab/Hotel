using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.Entity
{
    public class HotelInfo : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        public int RoomCount { get; set; }
        public int Rating { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
