using Microsoft.AspNetCore.Mvc;
using Xz.Models;
using Xz.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookApiController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookApiController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
    }
}
