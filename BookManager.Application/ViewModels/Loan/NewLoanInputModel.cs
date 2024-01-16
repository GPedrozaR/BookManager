namespace BookManager.Application.ViewModels.Loan
{
    public class NewLoanInputModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public int LoanDays { get; set; }
    }
}
