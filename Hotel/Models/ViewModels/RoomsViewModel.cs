using Hotel.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models.ViewModels
{
    public class RoomsViewModel
    {
        public List<Room> Rooms { get; set; }
        public List<RoomImage> RoomImages { get; set;}
        public List<RoomCategory> RoomCategories { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int Adult { get; set; }
        public int Kids { get; set; }
    }
}
