using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Models;
using PTMS.Data;

namespace PTMS.Pages.Admin.ClientPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public PTMS.Models.Client Client { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
        if (client is null)
        {
            return NotFound();
        }
        else
        {
            Client = client;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            Client = client;
            _context.Clients.Remove(Client);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
