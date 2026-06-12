using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PTMS.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}