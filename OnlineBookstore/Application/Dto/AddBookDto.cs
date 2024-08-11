
namespace OnlineBookstore.Application.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string? Discription { get; set; }
    }
}
