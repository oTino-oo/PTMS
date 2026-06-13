using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;

namespace PTMS.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class BookModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BookModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int TrainerId { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public double CurrentWeight { get; set; }

        [BindProperty]
        public double TargetWeight { get; set; }

        [BindProperty]
        public string Experience { get; set; } = "";

        public string TrainerName { get; set; } = "";

        public void OnGet(int trainerId)
        {
            TrainerId = trainerId;

            switch (trainerId)
            {
                case 1:
                    TrainerName = "PT John";
                    break;
                case 2:
                    TrainerName = "PT Sally";
                    break;
                case 3:
                    TrainerName = "PT Jake";
                    break;
                default:
                    TrainerName = "Unknown Trainer";
                    break;
            }
        }

        public IActionResult OnPost()
        {
            var booking = new Booking
            {
                ClientId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "",

                TrainerId = TrainerId,
                Age = Age,
                CurrentWeight = CurrentWeight,
                TargetWeight = TargetWeight,
                Experience = Experience,
                Status = "Pending"
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToPage("/Client/Dashboard");
        }
    }
}