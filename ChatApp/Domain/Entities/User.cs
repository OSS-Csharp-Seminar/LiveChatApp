using System.Collections.Generic;
using System;

namespace ChatApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Role { get; set; } = "User"; 
        public ICollection<UserRoom> UserRooms { get; set; } = new List<UserRoom>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
