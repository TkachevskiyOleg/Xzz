using Microsoft.AspNetCore.Mvc;
using Xz.Models;
using Xz.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Xz.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // Додаємо параметр searchTerm для пошуку
        public async Task<IActionResult> Index(string? searchTerm)
        {
            List<Book> books;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                books = await _bookService.SearchBooks(searchTerm);
                ViewData["CurrentFilter"] = searchTerm;
            }
            else
            {
                books = await _bookService.GetAllBooks();
            }

            return View(books);
        }

        public IActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
