using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PTMS.Models;

namespace PTMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Progress> Progress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    ClientId = 0,
                    TrainerId = 1,
                    SessionDate = new DateTime(2026, 6, 12, 10, 0, 0),
                    Price = 25,
                    Description = "Strength training",
                    Status = "Available"
                },
                new Session
                {
                    Id = 2,
                    ClientId = 0,
                    TrainerId = 2,
                    SessionDate = new DateTime(2026, 6, 13, 14, 0, 0),
                    Price = 30,
                    Description = "Cardio session",
                    Status = "Available"
                }
            );

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}