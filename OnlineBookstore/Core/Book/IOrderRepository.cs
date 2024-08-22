namespace OnlineBookstore.Core
{
    public interface IOrderRepository
    {
        Task<Order>       GetById(Guid id);
        Task<List<Order>> GetAll();
        Task<Order>       Add(Order order);
        Task<Order>       Update(Order order);
    }
}
