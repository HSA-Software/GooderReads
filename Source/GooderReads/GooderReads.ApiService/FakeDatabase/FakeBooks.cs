using Bogus;

namespace GooderReads.ApiService.FakeDatabase;

public class FakeBooks
{
    public FakeBooks()
    {
        Randomizer.Seed = new Random(8675309);
    }

    public static List<Book> GenerateBooks(int count)
    {
        var bookFaker = new Faker<Book>();
        var books = new List<Book>();

        for (var i = 0; i < count; i++)
        {
            books.Add(bookFaker.Generate());
        }

        return books;
    }
}
