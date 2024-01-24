using BookManager.Application.ViewModels.Book;
using MediatR;

namespace BookManager.Application.Queries.Book.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
        public GetAllBooksQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
