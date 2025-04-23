using Application.Common.Interface;
using ChatApp.Domain.Entities; 
using Domain.Common;
using Domain.Master;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ICurrentUserService currentUserService)
        : IdentityDbContext<ApplicationUser>(options), IApplicationDBContext
    {
        #region Properties
        private readonly DateTime _currentDateTime = DateTime.Now;
        private readonly ICurrentUserService _currentUserService = currentUserService;
        #endregion

        #region Master
        public DbSet<AppSetting> AppSettings { get; set; }
        #endregion

        #region ChatApp
        public DbSet<User> Users { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        #endregion

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                var currentUserID = _currentUserService.UserId;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Author = currentUserID;
                        entry.Entity.Created = _currentDateTime;
                        entry.Entity.Editor = currentUserID;
                        entry.Entity.Modified = _currentDateTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Editor = currentUserID;
                        entry.Entity.Modified = _currentDateTime;
                        break;
                }
            }
            return await base.SaveChangesAsync();
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

            modelBuilder.Entity<UserRoom>()
                .HasKey(ur => new { ur.UserId, ur.RoomId });

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRooms)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ChatRoom>()
                .HasMany(r => r.UserRooms)
                .WithOne(ur => ur.ChatRoom)
                .HasForeignKey(ur => ur.RoomId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<ChatRoom>()
                .HasMany(r => r.Messages)
                .WithOne(m => m.ChatRoom)
                .HasForeignKey(m => m.RoomId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
