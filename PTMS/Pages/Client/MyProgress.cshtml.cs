using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class MyProgressModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MyProgressModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Session> Sessions { get; set; } = new();

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            Sessions = await _context.Sessions
                .Where(s => s.ClientId == user.Id)
                .OrderByDescending(s => s.SessionDate)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostSubmitAsync(int sessionId, double actualValue)
        {
            var session = await _context.Sessions.FindAsync(sessionId);

            if (session == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            if (session.ClientId != user.Id)
                return Forbid();

            session.ActualValue = actualValue;
            session.Completed = true;
            session.Status = "Completed";

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}