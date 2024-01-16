namespace BookManager.Application.ViewModels.Loan
{
    public class LoanViewModel
    {
        public LoanViewModel(int id, int idUser, int idBook, int loanDays, DateTime loanDate, DateTime devolutionDate)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDays = loanDays;
            LoanDate = loanDate;
            DevolutionDate = devolutionDate;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public int LoanDays { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DevolutionDate { get; private set; }
    }
}
