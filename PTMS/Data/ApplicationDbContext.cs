using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PTMS.Models;

namespace PTMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PTMS.Models.User> User { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<UserApproval> UserApprovals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<Session>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

    
            modelBuilder.Entity<Booking>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(b => b.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Trainer>()
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(t => t.UserId);
        }
    }
}