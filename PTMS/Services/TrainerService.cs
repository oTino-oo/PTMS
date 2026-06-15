using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Services
{
    public class TrainerService
    {
        private readonly ApplicationDbContext _context;

        public TrainerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnsureTrainerExistsAsync(IdentityUser user)
        {
            var exists = await _context.Trainers
                .AnyAsync(t => t.UserId == user.Id);

            if (!exists)
            {
                _context.Trainers.Add(new Trainer
                {
                    UserId = user.Id,
                    Name = user.UserName ?? "PT",
                    Speciality = "General"
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}