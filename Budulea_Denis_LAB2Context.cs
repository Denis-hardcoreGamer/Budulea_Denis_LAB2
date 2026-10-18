using Microsoft.EntityFrameworkCore;

public class Budulea_Denis_LAB2Context(DbContextOptions<Budulea_Denis_LAB2Context> options) : DbContext(options)
{
    public DbSet<Budulea_Denis_LAB2.Models.Book> Book { get; set; } = default!;
}
