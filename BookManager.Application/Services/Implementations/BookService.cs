using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels.Book;
using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;

namespace BookManager.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookManagerDbContext _dbContext;
        public BookService(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewBookInputModel inputModel)
        {
            var book = new Book(inputModel.Title, inputModel.Author, inputModel.Isbn, inputModel.PublishedYear);
            
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            if (book is null)
                return;

            book.Active = false;
            book.UpdatedAt = DateTime.Now;

            //_dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }

        public List<BookViewModel> GetAll(string query)
        {
            var books = _dbContext.Books;
            return books
                .Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.Isbn, b.PublishedYear, b.CreatedAt))
                .ToList();
        }

        public BookDetailsViewModel GetById(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            
            if (book is null)
                return null;

            var bookDetails = new BookDetailsViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.Isbn,
                book.PublishedYear,
                book.CreatedAt);

            return bookDetails;
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == inputModel.Id);
            if (book is null)
                return;

            book.Title = inputModel.Title;
            book.Author = inputModel.Author;
            book.Isbn = inputModel.Isbn;
            book.PublishedYear = inputModel.PublishedYear;
            book.UpdatedAt = DateTime.Now;

            //_dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
