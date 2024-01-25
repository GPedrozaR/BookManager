using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface ILoanRepository
    {
        public Task SaveChangesAsync();
        public Task AddLoanAsync(Loan loan);
        public Task<Loan> GetLoanByIdAsync(int id);
    }
}
