public class Book
{
    public long? Id { get; set; }
    public required string Title { get; set; }
    public Author? Author { get; set; }
    public long? AuthorId { get; set; }
    public string? Summary { get; set; }
}

public class Author
{
    public long? Id { get; set; }
    public required string Name { get; set; }
}
