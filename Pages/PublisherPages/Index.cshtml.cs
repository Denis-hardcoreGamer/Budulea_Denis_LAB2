using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budulea_Denis_LAB2.Models;
using Budulea_Denis_LAB2.Models.ViewModels;
using Budulea_Denis_LAB2.Data;

namespace Budulea_Denis_LAB2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Budulea_Denis_LAB2Context _context;

    public IndexModel(Budulea_Denis_LAB2Context context)
    {
        _context = context;
    }

    public PublisherIndexData PublisherData { get; set; } = default!;
    public int PublisherID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        PublisherData = new PublisherIndexData();
        PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
                .ThenInclude(c => c.Author)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();

        if (id != null)
        {
            PublisherID = id.Value;
            Publisher publisher = PublisherData.Publishers
                .Single(i => i.ID == id.Value);
            PublisherData.Books = publisher.Books;
        }
    }
}