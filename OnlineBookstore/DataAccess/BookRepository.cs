using OnlineBook.Book.DataAccess;
using OnlineBookstore.Core;

namespace OnlineBookstore.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _context;   
        public BookRepository(BookDBContext context)
        {
            _context = context;
        }
        public Task<Book> Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
