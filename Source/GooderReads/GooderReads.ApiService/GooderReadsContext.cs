using Microsoft.EntityFrameworkCore;

public class GooderReadsContext : DbContext
{
    public GooderReadsContext(DbContextOptions<GooderReadsContext> options)
        : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
}
