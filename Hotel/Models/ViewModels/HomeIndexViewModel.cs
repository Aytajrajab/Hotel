using Hotel.Models.Entity;
using System.Collections;
using System.Collections.Generic;

namespace Hotel.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public ICollection<CommentSection> Comments { get; set; }
        public ICollection<HotelInfo> HotelInfos { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<RoomImageSlider> RoomImages { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
