using Budulea_Denis_LAB2.Data;
using Budulea_Denis_LAB2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Budulea_Denis_LAB2.Pages.BookPages;

public class EditModel : BookCategoriesPageModel
{
    private readonly Budulea_Denis_LAB2Context _context;

    public EditModel(Budulea_Denis_LAB2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }
        //se va include Author conform cu sarcina de la lab 2
        Book = await _context.Book
        .Include(b => b.Publisher)
        .Include(b => b.BookCategories).ThenInclude(b => b.Category)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);

        var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
        if (book is null)
        {
            return NotFound();
        }

        PopulateAssignedCategoryData(_context, Book);

        Book = book;
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
        "PublisherName");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
    {
        if (id == null)
        {
            return NotFound();
        }
        //se va include Author conform cu sarcina de la lab 2
        var bookToUpdate = await _context.Book
        .Include(i => i.Publisher)
        .Include(i => i.BookCategories)
        .ThenInclude(i => i.Category)
        .FirstOrDefaultAsync(s => s.ID == id);
        if (bookToUpdate == null)
        {
            return NotFound();
        }
        //se va modifica AuthorID conform cu sarcina de la lab 2
        if (await TryUpdateModelAsync<Book>(
        bookToUpdate,
        "Book",
        i => i.Title, i => i.Author,
        i => i.Price, i => i.PublishingDate, i => i.PublisherID))
        {
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books careCommentHighlight
        //este editata
        UpdateBookCategories(_context, selectedCategories, bookToUpdate);
        PopulateAssignedCategoryData(_context, bookToUpdate);
        return Page();
    }




    private bool BookExists(int id)
    {
        return _context.Book.Any(e => e.ID == id);
    }
}
