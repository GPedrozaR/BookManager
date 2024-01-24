using BookManager.Application.ViewModels.User;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDetails = users
                    .Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.BirthDate))
                    .ToList();

            return userDetails;
        }
    }
}
