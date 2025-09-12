using EventBoardBackend.CustomExceptions;
using EventBoardBackend.Data.Models.Entities;
using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace EventBoardBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            //Console.WriteLine("Database deleted");
            
        }

        public DbSet<MeetingModel> Meetings => Set<MeetingModel>();
        public DbSet<CompanyModel> Companies => Set<CompanyModel>();
        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<ManagerModel> Managers => Set<ManagerModel>();
        public DbSet<StudentModel> Students => Set<StudentModel>();
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // между User (пользователи) и Meeting (мероприятие) две связи,
            // "менеджер курирует мероприятие" и "студент посещает мероприятие"

            modelBuilder.Entity<UserModel>()
                .HasIndex(e => e.Email)
                .IsUnique();


            modelBuilder.Entity<ManagerModel>()
                .HasOne(m => m.Company)
                .WithMany(c => c.Managers)
                .HasForeignKey(m => m.CompanyId);

            modelBuilder.Entity<MeetingModel>()
                .HasOne(m => m.Manager)
                .WithMany(m => m.ManagedMeetings)
                .HasForeignKey(m => m.ManagerId);

            modelBuilder.Entity<UserModel>()
                .HasOne(p => p.Manager)
                .WithOne(d => d.User)
                .HasForeignKey<ManagerModel>(d => d.Id);

            modelBuilder.Entity<UserModel>()
                .HasOne(p => p.Student)
                .WithOne(d => d.User)
                .HasForeignKey<StudentModel>(d => d.Id);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            try
            {
                return await Users
                    .SingleOrDefaultAsync(u => u.Email == email);
            }
            catch (InvalidOperationException ex) //если пользователей больше 2 и более на Email (противоречит ОЦ)
            {
                throw new DuplicateException("Two users with same email", ex);
            }
        }
    }
}
