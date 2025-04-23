using System;

namespace ChatApp.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int RoomId { get; set; }
        public ChatRoom ChatRoom { get; set; } = null!;

        public string Content { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
