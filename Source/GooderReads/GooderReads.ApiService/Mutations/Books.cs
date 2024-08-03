namespace GooderReads.ApiService.Mutations;

public class BooksMutation
{
    public async Task<Book> AddBook(Book book, GooderReadsContext gooderReadsContext)
    {
        book.Id = null;

        if (book.AuthorId.HasValue)
        {
            book.Author = null;
        }

        var result = await gooderReadsContext.Books.AddAsync(book);
        await gooderReadsContext.SaveChangesAsync();
        return result.Entity;
    }
}
