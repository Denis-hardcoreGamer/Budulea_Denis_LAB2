using Budulea_Denis_LAB2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Budulea_Denis_LAB2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Budulea_Denis_LAB2Context _context;

        public IndexModel(Budulea_Denis_LAB2Context context)
        {
            _context = context;
        }
        // Expose a list of books to the page. The view expects an indexable collection and to iterate over it.
        public IList<Book> Book { get; set; } = new List<Book>();

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Publisher)
                .ToListAsync();
        }
    }
}
