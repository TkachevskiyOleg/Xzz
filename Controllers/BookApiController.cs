using Microsoft.AspNetCore.Mvc;
using Xz.Models;

namespace Xz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookApiController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll() => Ok(_books);

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return CreatedAtAction(nameof(GetAll), new { id = book.Id }, book);
        }
    }
}
