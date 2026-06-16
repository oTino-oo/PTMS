using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages.PT
{
    [Authorize(Roles = "PT")]
    public class ScheduleModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ScheduleModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<SessionViewModel> Session { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var trainer = await _context.Trainers
                .FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (trainer == null) return;

            var sessions = await _context.Sessions
                .Where(s => s.TrainerId == trainer.Id)
                .OrderBy(s => s.SessionDate)
                .ToListAsync();

            Session = sessions.Select(s => new SessionViewModel
            {
                Description = s.Description,
                SessionDate = s.SessionDate,
                Status = s.Status
            }).ToList();
        }
    }

    public class SessionViewModel
    {
        public string Description { get; set; }
        public DateTime SessionDate { get; set; }
        public string Status { get; set; }
    }
}