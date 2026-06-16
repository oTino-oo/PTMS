using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<UserApproval> PendingUsers { get; set; } = new();

        [BindProperty]
        public string UserId { get; set; }

        public void OnGet()
        {
            PendingUsers = _context.UserApprovals
                .Where(x => !x.IsApproved)
                .ToList();
        }

        public async Task<IActionResult> OnPostApproveAsync()
        {
            var record = _context.UserApprovals
                .FirstOrDefault(x => x.UserId == UserId);

            if (record != null)
            {
                record.IsApproved = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectAsync()
        {
            var approval = _context.UserApprovals
                .FirstOrDefault(x => x.UserId == UserId);

            if (approval != null)
            {
                _context.UserApprovals.Remove(approval);
            }

            var user = await _userManager.FindByIdAsync(UserId);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}