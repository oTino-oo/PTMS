using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace PTMS.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class YearlyPlansModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}