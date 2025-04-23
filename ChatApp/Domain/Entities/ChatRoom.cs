using System;
using System.Collections.Generic;

namespace ChatApp.Domain.Entities
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public ICollection<UserRoom> UserRooms { get; set; } = new List<UserRoom>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
