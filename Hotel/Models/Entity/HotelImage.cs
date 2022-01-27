namespace Hotel.Models.Entity
{
    public class HotelImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public HotelInfo HotelInfo { get; set; }
        public int HotelId { get; set; }
    }
}
