using EventBoardBackend.Data.Models.Entities;
using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace EventBoardBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureDeleted();
            Console.WriteLine("Database deleted");
            Database.EnsureCreated();
            Console.WriteLine("Database created");

        }

        public DbSet<MeetingModel> Meetings { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<ManagerModel> Managers { get; set; }
        public DbSet<StudentModel> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // между User (пользователи) и Meeting (мероприятие) две связи,
            // "менеджер курирует мероприятие" и "студент посещает мероприятие"

            modelBuilder.Entity<StudentModel>()
                .HasMany(p => p.AttendedMeetings)
                .WithMany(u => u.Students);
        }

    }
}
