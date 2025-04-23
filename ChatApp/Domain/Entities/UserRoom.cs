namespace ChatApp.Domain.Entities
{
    public class UserRoom
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int RoomId { get; set; }
        public ChatRoom ChatRoom { get; set; } = null!;
    }
}
