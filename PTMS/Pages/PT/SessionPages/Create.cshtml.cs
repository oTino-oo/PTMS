using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages.PT.SessionPages
{
    [Authorize(Roles = "PT")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Session Session { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var userId = _userManager.GetUserId(User);

            var trainer = _context.Trainers.FirstOrDefault(t => t.UserId == userId);

            if (trainer == null)
            {
                ModelState.AddModelError("", "Trainer not found.");
                return Page();
            }

            Session.TrainerId = trainer.Id;

            _context.Sessions.Add(Session);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}