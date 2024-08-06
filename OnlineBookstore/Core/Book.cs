namespace OnlineBookstore.Core
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public Price Price { get; private set; }
        public string? Discription { get; private set; }
        public List<Order> orders { get; private set; }
    }
}
