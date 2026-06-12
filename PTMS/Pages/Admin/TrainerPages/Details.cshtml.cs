using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PTMS.Models;
using PTMS.Data;

namespace PTMS.Pages.Admin.TrainerPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Trainer Trainer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var trainer = await _context.Trainers.FirstOrDefaultAsync(m => m.Id == id);
        if (trainer is null)
        {
            return NotFound();
        }
        else
        {
            Trainer = trainer;
        }

        return Page();
    }
}
