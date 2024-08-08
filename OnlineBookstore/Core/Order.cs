namespace OnlineBookstore.Core
{
    public class Order
    {
        public Guid Id { get; protected set; }
        public DateTime OrderDate { get; private set; }
        public int Quantity { get; private set; }
        public Book Book { get; private set; }

        public Order(Guid id, DateTime orderDate, int quantity)
        {
            Id = id;
            OrderDate = orderDate;
            Quantity = quantity;
        }

        private Order(int quantity)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;
            Quantity = quantity;
        }

        public static Order Create(int quantity) 
        { 
            return new Order(quantity);
        }

        public static Order Create(
            Guid id, 
            DateTime orderTime, 
            int quantity)
        {
            return new Order(id,orderTime,quantity);
        }
    }
}
