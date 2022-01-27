using Hotel.Models.Entity;
using System.Collections.Generic;

namespace Hotel.Models.ViewModels
{
    public class HotelViewModel
    {
        public List<HotelCategory> HotelCategories { get; set; }
        public List<HotelInfo> HotelInfos { get; set; }
        public List<Room> Rooms { get; set; }
        public HotelInfo HotelInfo { get; set; }
    }
}
