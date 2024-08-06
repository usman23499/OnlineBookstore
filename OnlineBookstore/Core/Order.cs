namespace OnlineBookstore.Core
{
    public class Order
    {
        public Guid Id { get; protected set; }
        public DateTime OrderDate { get; private set; }
        public int Quantity { get; private set; }
        public Book Book { get; private set; }
    }
}
