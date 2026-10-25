using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budulea_Denis_LAB2.Models;
using Budulea_Denis_LAB2.Data;

namespace Budulea_Denis_LAB2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Budulea_Denis_LAB2Context _context;

    public IndexModel(Budulea_Denis_LAB2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publisher = await _context.Publisher.ToListAsync();
    }
}
