using EventBoardBackend.Data.Models.Entities;
using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EventBoardBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
            // Database.EnsureDeleted();
        }

        public DbSet<MeetingModel> Meeting { get; set; }
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<RequestModel> Request { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<CompanyModel> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(p => p.AttendedMeetings)
                .WithMany(u => u.Students);

            modelBuilder.Entity<UserModel>()
                .HasMany(p => p.ManagedMeetings)
                .WithOne(u => u.Manager)
                .HasForeignKey(p => p.ManagerId);
        }

    }
}
