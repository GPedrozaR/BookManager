using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.Book.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
