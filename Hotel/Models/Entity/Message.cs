namespace Hotel.Models.Entity
{
    public class Message : BaseEntity
    {
        public string MessageContent { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Answer { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
