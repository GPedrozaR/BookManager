using BookManager.Application.Commands.Book.CreateBook;
using BookManager.Application.Commands.Book.DeleteBook;
using BookManager.Application.Commands.Book.UpdateBook;
using BookManager.Application.Queries.Book.GetAllBooks;
using BookManager.Application.Queries.Book.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(string query)
        {
            var command = new GetAllBooksQuery(query);
            var books = await _mediator.Send(command);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var command = new GetBookByIdQuery(id);
            var book = await _mediator.Send(command);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewBook([FromBody] CreateBookCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            var deleteBook = new DeleteBookCommand(id);
            await _mediator.Send(deleteBook);

            return NoContent();
        }
    }
}
