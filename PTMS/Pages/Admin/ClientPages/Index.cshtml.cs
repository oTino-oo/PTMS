using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Models;
using PTMS.Data;

namespace PTMS.Pages.Admin.ClientPages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<PTMS.Models.Client> Client { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Client = await _context.Clients.ToListAsync();
    }
}
