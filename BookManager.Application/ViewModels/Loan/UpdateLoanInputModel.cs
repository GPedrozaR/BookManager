namespace BookManager.Application.ViewModels.Loan
{
    public class UpdateLoanInputModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DevolutionDate { get; set; }
    }
}
