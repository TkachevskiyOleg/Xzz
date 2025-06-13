using System.Collections.Generic;
using System.Linq;
using Xz.Models;

namespace Xz.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Dystopian", Publisher = "Secker & Warburg", Year = 1949 },
            new Book { Id = 2, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Publisher = "George Allen & Unwin", Year = 1937 },
            new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic", Publisher = "J.B. Lippincott & Co.", Year = 1960 }
        };

        public List<Book> GetAllBooks() => _books;

        public void AddBook(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }
    }
}
