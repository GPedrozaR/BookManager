using BookManager.Application.ViewModels.Loan;

namespace BookManager.Application.Services.Interfaces
{
    public interface ILoanService
    {
        List<LoanViewModel> GetAll(string query);
        LoanDetailsViewModel GetById(int id);
        int Create(NewLoanInputModel inputModel);
        void Update(UpdateLoanInputModel inputModel);
        void Delete(int id);
    }
}
