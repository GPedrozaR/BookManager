namespace BookManager.Application.Commands.Loan.CreateLoan
{
    internal class CreateLoanCommand
    {
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public int LoanDays { get; private set; }
    }
}
