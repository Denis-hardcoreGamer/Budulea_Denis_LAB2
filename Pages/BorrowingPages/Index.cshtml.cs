using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budulea_Denis_LAB2.Models;
using Budulea_Denis_LAB2.Data;

namespace Budulea_Denis_LAB2.Pages.BorrowingPages;

public class IndexModel : PageModel
{
    private readonly Budulea_Denis_LAB2Context _context;

    public IndexModel(Budulea_Denis_LAB2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .ThenInclude(b => b.Author)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
