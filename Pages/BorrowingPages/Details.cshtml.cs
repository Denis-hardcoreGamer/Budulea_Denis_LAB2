using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budulea_Denis_LAB2.Models;
using Budulea_Denis_LAB2.Data;

namespace Budulea_Denis_LAB2.Pages.BorrowingPages;

public class DetailsModel : PageModel
{
    private readonly Budulea_Denis_LAB2Context _context;
    public DetailsModel(Budulea_Denis_LAB2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing is null)
        {
            return NotFound();
        }
        else
        {
            Borrowing = borrowing;
        }

        return Page();
    }
}
