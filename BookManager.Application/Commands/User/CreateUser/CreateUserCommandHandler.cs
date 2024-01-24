using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Core.Entities.User(request.Name, request.Email, request.BirthDate);

            await _userRepository.AddUserAsync(user);

            return user.Id;
        }
    }
}
