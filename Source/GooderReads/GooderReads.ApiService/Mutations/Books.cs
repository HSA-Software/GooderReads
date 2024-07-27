namespace GooderReads.ApiService.Mutations
{
    public class BooksMutation
    {
        private readonly GooderReadsContext gooderReadsContext;

        public BooksMutation(GooderReadsContext gooderReadsContext)
        {
            this.gooderReadsContext = gooderReadsContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            book.Id = null;
            var result = await gooderReadsContext.Books.AddAsync(book);
            await gooderReadsContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
