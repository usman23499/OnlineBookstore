namespace OnlineBookstore.Application.Dto
{
    public class CreateOrderDto
    {
        public int Quantity { get; set; }
        public Guid BookId { get; set; }
    }
}
