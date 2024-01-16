using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks(string query)
        {
            var books = _bookService.GetAll(query);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetById(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public IActionResult RegisterNewBook([FromBody] NewBookInputModel inputModel)
        {
            var id = _bookService.Create(inputModel);

            return CreatedAtAction(nameof(GetBookById), new { id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookInputModel inputModel)
        {
            var book = _bookService.GetById(id);

            if (book is null)
                return NotFound();

            _bookService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var book = _bookService.GetById(id);

            if (book is null)
                return NotFound();

            _bookService.Delete(id);

            return NoContent();
        }
    }
}
