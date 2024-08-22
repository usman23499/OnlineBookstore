namespace OnlineBookstore.Core
{
    public interface IBookRepository
    {
        Task<Book>       GetById(Guid id);
        Task<List<Book>> GetAll();
        Task<Book>       Add(Book book);
        Task<Book>       Update(Book book);
    }
}
