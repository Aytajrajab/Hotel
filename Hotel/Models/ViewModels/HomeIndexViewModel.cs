using Hotel.Models.Entity;
using System.Collections;
using System.Collections.Generic;

namespace Hotel.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<CommentSection> Comments { get; set; }
        public List<HotelInfo> HotelInfos { get; set; }
        public List<HotelImage> HotelImages { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public List<Service> Services { get; set; }
        public List<Staff> Staffs { get; set; }
    }
}
