using OnlineBook.Book.DataAccess;
using OnlineBookstore.Core;
using OnlineBookstore.DataAccess.DAO;

namespace OnlineBookstore.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _context;   
        public BookRepository(BookDBContext context)
        {
            _context = context;
        }
        public async Task<Book> Add(Book book)
        {
            BookDAO bookDAO = new BookDAO()
            { 
                Id = book.Id,
                Author = book.Author,
                Discription = book.Discription,
                Title = book.Title,
                Price = new PriceDAO()
                {
                    Amount   = book.Price.Amount,
                    Currency = book.Price.Currency
                }
            }; 

           await _context.Books.AddAsync(bookDAO);
           await _context.SaveChangesAsync();

            return book;
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
