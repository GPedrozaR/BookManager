using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllBooksAsync();
        public Task<Book> GetBookByIdAsync(int id);
        public Task AddBookAsync(Book book);
        public Task SaveChangesAsync();
    }
}
