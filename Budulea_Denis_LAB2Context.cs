using Microsoft.EntityFrameworkCore;
using Budulea_Denis_LAB2.Models;

public class Budulea_Denis_LAB2Context : DbContext
{
    public Budulea_Denis_LAB2Context(DbContextOptions<Budulea_Denis_LAB2Context> options)
        : base(options)
    {
    }

    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;
}
