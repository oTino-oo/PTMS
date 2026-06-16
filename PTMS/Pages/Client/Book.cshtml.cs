using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PTMS.Data;
using PTMS.Models;
using System.Security.Claims;

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
        public string? Experience { get; set; }

        public string PlanType { get; set; } = "Monthly";

        public string TrainerName { get; set; } = "";

        public void OnGet(int trainerId, string planType)
        {
            TrainerId = trainerId;
            PlanType = planType ?? "Monthly";

            TrainerName = trainerId switch
            {
                1 => "PT John",
                2 => "PT Sally",
                3 => "PT Jake",
                _ => "Unknown Trainer"
            };
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("PlanType");

            if (!ModelState.IsValid)
                return Page();

            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(clientId))
            {
                ModelState.AddModelError("", "User not logged in");
                return Page();
            }

            var booking = new Booking
            {
                ClientId = clientId,
                TrainerId = TrainerId,
                Age = Age,
                CurrentWeight = CurrentWeight,
                TargetWeight = TargetWeight,
                Experience = Experience ?? "",
                PlanType = "Monthly",
                Status = "Pending"
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            TempData["Success"] = "Booking submitted successfully.";
            return RedirectToPage("/Client/Dashboard");
        }
    }
}