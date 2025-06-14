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
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetAll), book);
        }
    }
}