using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace PTMS.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class BookModel : PageModel
    {
        [BindProperty]
        public int TrainerId { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public double CurrentWeight { get; set; }

        [BindProperty]
        public double TargetWeight { get; set; }

        [BindProperty]
        public string Experience { get; set; } = string.Empty;

        public string TrainerName { get; set; } = string.Empty;

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
            // Database code will go here later

            return RedirectToPage("/Client/Dashboard");
        }
    }
}