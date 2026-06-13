using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;

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

            if (booking == null)
                return RedirectToPage();

            booking.Status = "Accepted";

            _context.Sessions.Add(new Session
            {
                TrainerId = booking.TrainerId,

                // FIX: string type matches Booking.ClientId
                ClientId = booking.ClientId,

                SessionDate = DateTime.Now.AddDays(1),
                Status = "Scheduled",
                Price = 0,
                Description = "Created from booking"
            });

            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostReject(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

            if (booking == null)
                return RedirectToPage();

            booking.Status = "Rejected";
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}