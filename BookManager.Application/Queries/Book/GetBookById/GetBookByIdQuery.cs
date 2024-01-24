using BookManager.Application.ViewModels.Book;
using MediatR;

namespace BookManager.Application.Queries.Book.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDetailsViewModel>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
