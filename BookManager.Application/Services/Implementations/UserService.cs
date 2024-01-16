using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels.User;
using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;

namespace BookManager.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly BookManagerDbContext _dbContext;

        public UserService(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.Name, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            if (user is null)
                return;

            user.Active = false;
            user.UpdatedAt = DateTime.Now;

            _dbContext.SaveChanges();
        }

        public List<UserViewModel> GetAll(string query)
        {
            var users = _dbContext.Users;
            return users
                    .Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.BirthDate))
                    .ToList();
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
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

        public void Update(UpdateUserInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
