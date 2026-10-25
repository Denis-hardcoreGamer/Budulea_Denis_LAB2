/*using Budulea_Denis_LAB2.Models;
using Microsoft.EntityFrameworkCore;

public class Budulea_Denis_LAB2Context : DbContext
{
    public Budulea_Denis_LAB2Context(DbContextOptions<Budulea_Denis_LAB2Context> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;
    public IEnumerable<object> Category { get; internal set; }
}
*/
using Microsoft.EntityFrameworkCore;
using Budulea_Denis_LAB2.Models;

namespace Budulea_Denis_LAB2.Data
{
    public class Budulea_Denis_LAB2Context : DbContext
    {
        public Budulea_Denis_LAB2Context(DbContextOptions<Budulea_Denis_LAB2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<BookCategory> BookCategory { get; set; } = default!;
    }
}