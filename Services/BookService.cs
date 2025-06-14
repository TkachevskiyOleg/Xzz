using Microsoft.EntityFrameworkCore;
using Xz.Data;
using Xz.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xz.Services
{
    public class BookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> SearchBooks(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            return await _context.Books
                .Where(b => b.Title.ToLower().Contains(searchTerm)
                         || b.Author.ToLower().Contains(searchTerm)
                         || b.Genre.ToLower().Contains(searchTerm))
                .ToListAsync();
        }
    }
}
