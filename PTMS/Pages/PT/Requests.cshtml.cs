using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace PTMS.Pages.PT
{
    public class RequestsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RequestsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Booking> Bookings { get; set; } = new();

        public void OnGet()
        {
            Bookings = _context.Bookings.ToList();
        }

        public IActionResult OnPostAccept(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

            if (booking != null)
            {
                booking.Status = "Accepted";
                _context.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostReject(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

            if (booking != null)
            {
                booking.Status = "Rejected";
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}