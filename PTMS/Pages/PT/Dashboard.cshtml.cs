using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PTMS.Pages.PT
{
    [Authorize(Roles = "PT")]
    public class DashboardModel : PageModel
    {
        public int TotalClients { get; set; } = 0;
        public int UpcomingSessions { get; set; } = 0;

        public void OnGet()
        {
 
        }
    }
}