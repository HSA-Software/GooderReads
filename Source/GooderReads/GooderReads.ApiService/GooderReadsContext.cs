using Microsoft.EntityFrameworkCore;

public class GooderReadsContext : DbContext
{
    public GooderReadsContext(DbContextOptions<GooderReadsContext> options)
        : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
}

public class BooksQuery
{
    public IQueryable<Book> GetUsers(GooderReadsContext dbContext)
        => dbContext.Books;
}