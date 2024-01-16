namespace BookManager.Application.ViewModels.Book
{
    public class NewBookInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishedYear { get; set; }
    }
}
