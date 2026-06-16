using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Data;
using PTMS.Services;

namespace PTMS.Pages.PT
{
    [Authorize(Roles = "PT")]
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TrainerService _trainerService;

        public DashboardModel(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            TrainerService trainerService)
        {
            _context = context;
            _userManager = userManager;
            _trainerService = trainerService;
            Input = new InputModel();
        }

        public int TotalClients { get; set; }
        public int UpcomingSessions { get; set; }

        public InputModel Input { get; set; }

        public class InputModel
        {
            public int TrainerId { get; set; }
            public string Status { get; set; }
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return;

            await _trainerService.EnsureTrainerExistsAsync(user);

            var trainer = await _context.Trainers
                        .FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (trainer != null)
            {
                Input.TrainerId = trainer.Id;
                Input.Status = "Scheduled";

                TotalClients = await _context.Bookings
                    .CountAsync(b => b.TrainerId == trainer.Id && b.Status == "Accepted");

                UpcomingSessions = await _context.Sessions
                    .CountAsync(s => s.TrainerId == trainer.Id && s.SessionDate > DateTime.Now);
            }
        }
    }
}