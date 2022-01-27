namespace Hotel.Models.Entity
{
    public class RoomImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
