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
        var authorFaker = new Faker<Author>()
            .UseSeed(12345)
            .RuleFor(b => b.Name, f => f.Name.FullName());

        var bookFaker = new Faker<Book>()
            .UseSeed(54321)
            .RuleFor(b => b.Author, f => authorFaker.Generate())
            .RuleFor(b => b.Title, f => f.Lorem.Sentence(4))
            .RuleFor(b => b.Summary, f => f.Lorem.Sentences(5));

        var books = new List<Book>();

        for (var i = 0; i < count; i++)
        {
            books.Add(bookFaker.Generate());
        }

        return books;
    }
}
