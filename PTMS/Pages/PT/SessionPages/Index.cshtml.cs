using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages.PT.SessionPages;

[Authorize(Roles = "PT")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IList<Session> Session { get; set; } = new List<Session>();

    public async Task OnGetAsync()
    {
        var userId = _userManager.GetUserId(User);

        var trainer = await _context.Trainers
            .FirstOrDefaultAsync(t => t.UserId == userId);

        if (trainer == null)
        {
            Session = new List<Session>();
            return;
        }

        Session = await _context.Sessions
            .Where(s => s.TrainerId == trainer.Id)
            .ToListAsync();
    }
}