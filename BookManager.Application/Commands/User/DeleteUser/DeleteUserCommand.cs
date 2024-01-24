using MediatR;

namespace BookManager.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
