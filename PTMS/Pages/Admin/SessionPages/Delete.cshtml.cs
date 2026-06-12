using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Models;
using PTMS.Data;

namespace PTMS.Pages.Admin.SessionPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Session Session { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var session = await _context.Sessions.FirstOrDefaultAsync(m => m.Id == id);
        if (session is null)
        {
            return NotFound();
        }
        else
        {
            Session = session;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var session = await _context.Sessions.FindAsync(id);
        if (session != null)
        {
            Session = session;
            _context.Sessions.Remove(Session);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
