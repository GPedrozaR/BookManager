using BookManager.Application.ViewModels.User;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.User.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user is null)
                return null;

            return new UserDetailsViewModel(
                user.Id,
                user.Name,
                user.Email,
                user.BirthDate,
                user.CreatedAt,
                user.UpdatedAt,
                user.Active);
        }
    }
}
