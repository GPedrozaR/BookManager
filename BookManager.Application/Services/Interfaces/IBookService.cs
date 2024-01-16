using BookManager.Application.ViewModels.Book;

namespace BookManager.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll(string query);
        BookDetailsViewModel GetById(int id);
        int Create(NewBookInputModel inputModel);
        void Update(UpdateBookInputModel inputModel);
        void Delete(int id);
    }
}
