using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using System.Linq;

namespace PTMS.Pages.PT
{
    [Authorize(Roles = "PT")]
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public int TotalClients { get; set; }
        public int UpcomingSessions { get; set; }

        public void OnGet()
        {
            var userId = _userManager.GetUserId(User);

            var trainer = _context.Trainers.FirstOrDefault(t => t.UserId == userId);

            if (trainer == null)
                return;

            TotalClients = _context.Bookings
                .Count(b => b.TrainerId == trainer.Id && b.Status == "Accepted");

            UpcomingSessions = _context.Sessions
                .Count(s => s.TrainerId == trainer.Id && s.SessionDate > System.DateTime.Now);
        }
    }
}