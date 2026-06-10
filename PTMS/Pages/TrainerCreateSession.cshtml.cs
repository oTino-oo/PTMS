using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages
{
    public class TrainerCreateSessionModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TrainerCreateSessionModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Session Session { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Session.Status = "Available";

            _context.Sessions.Add(Session);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}