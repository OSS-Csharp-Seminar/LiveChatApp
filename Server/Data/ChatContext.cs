using ChatApp.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Server.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
