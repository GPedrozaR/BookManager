namespace BookManager.Application.ViewModels.Book
{
    public class UpdateBookInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishedYear { get; set; }
    }
}
