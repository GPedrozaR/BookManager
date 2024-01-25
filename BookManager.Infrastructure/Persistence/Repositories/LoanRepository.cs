using BookManager.Core.Entities;
using BookManager.Core.Repositories;

namespace BookManager.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BookManagerDbContext _dbContext;
        public LoanRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);
            await SaveChangesAsync();
        }
    }
}
