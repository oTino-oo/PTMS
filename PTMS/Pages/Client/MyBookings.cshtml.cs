using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using PTMS.Data;
using PTMS.Models;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using PTMS.Models;
using PTMS.Data;

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

        public List<Trainer> Trainers { get; set; } = new();

        public void OnGet()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            Bookings = _context.Bookings
                .Where(b => b.ClientId == userId)
                .ToList();

            Trainers = _context.Trainers.ToList();
        }
    }
}