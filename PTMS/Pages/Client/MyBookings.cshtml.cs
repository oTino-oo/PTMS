using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;
using System.Linq;

namespace PTMS.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class MyBookingsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MyBookingsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Booking> Bookings { get; set; } = new();

        public Dictionary<int, string> TrainerNames { get; set; } = new();

        public void OnGet()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Bookings = _context.Bookings
                .Where(b => b.ClientId == userId)
                .ToList();

            TrainerNames = _context.Trainers
                .ToDictionary(t => t.Id, t => t.Name);
        }
    }
}