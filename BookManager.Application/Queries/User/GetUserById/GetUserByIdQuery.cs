using BookManager.Application.ViewModels.User;
using MediatR;

namespace BookManager.Application.Queries.User.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDetailsViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        
        public int Id { get; private set; }
    }
}
