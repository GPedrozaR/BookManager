using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels.User;

namespace BookManager.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        public int Create(NewUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public UserDetailsViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
