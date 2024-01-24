using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task AddUserAsync(User book);
        public Task SaveChangesAsync();
    }
}
