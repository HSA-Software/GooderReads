namespace GooderReads.ApiService.Queries;

public class BooksQuery
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetUsers(GooderReadsContext dbContext) => dbContext.Books;
}