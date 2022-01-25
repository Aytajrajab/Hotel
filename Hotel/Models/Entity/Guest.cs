namespace Hotel.Models.Entity
{
    public class Guest : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
    }
}
