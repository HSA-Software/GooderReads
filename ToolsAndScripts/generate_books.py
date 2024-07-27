import factory
import jsonpickle

class Book:
    def __init__(self, author, title, isbn):
        self.author = author
        self.title = title
        self.isbn = isbn

class BookFactory(factory.Factory):
    class Meta:
        model = Book

    title = factory.Faker('sentence', nb_words=4)
    author = factory.Faker('name')
    isbn = factory.Faker('isbn10')

for i in range(10):
    book = BookFactory()
    json_string = jsonpickle.encode(book)
    print(json_string)