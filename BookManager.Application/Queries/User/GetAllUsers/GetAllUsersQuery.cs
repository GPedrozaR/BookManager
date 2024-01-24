using BookManager.Application.ViewModels.User;
using MediatR;

namespace BookManager.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
