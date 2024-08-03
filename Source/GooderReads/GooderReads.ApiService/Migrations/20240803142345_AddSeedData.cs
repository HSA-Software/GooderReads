using GooderReads.ApiService.Faker;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GooderReads.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fakeBooks = BooksFaker.GenerateBooks(100);
            var authors = new object[fakeBooks.Count, 2];
            var books = new object[fakeBooks.Count, 4];

            for (int i = 0; i < fakeBooks.Count; i++)
            {
                authors[i,0] = i;
                authors[i,1] = fakeBooks[i].Author.Name;

                books[i,0] = i;
                books[i,1] = i;
                books[i,2] = fakeBooks[i].Summary;
                books[i,3] = fakeBooks[i].Title;
            }

            migrationBuilder.InsertData(
                table: "Author",
                columns: ["Id", "Name"],
                values: authors);

            migrationBuilder.InsertData(
                table: "Books",
                columns: ["Id", "AuthorId", "Summary", "Title"],
                values: books);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
