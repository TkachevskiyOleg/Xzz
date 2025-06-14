using Microsoft.AspNetCore.Mvc;
using Xz.Models;
using Xz.Services;
using System.Threading.Tasks;
using System.Collections.Generic; // Додайте цей using

namespace Xz.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // Змінено: повертаємо колекцію книг
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books); // Повертаємо список книг
        }

        public IActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}