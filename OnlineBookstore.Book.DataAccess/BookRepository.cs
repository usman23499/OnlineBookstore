using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineBook.Book.DataAccess;
using OnlineBookstore.Book.Core;
using OnlineBookstore.Book.DataAccess.DAO;

namespace OnlineBookstore.Book.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Core.Book> Add(Core.Book book)
        {
            BookDAO bookDAO = _mapper.Map<BookDAO>(book);
            bookDAO.Price = _mapper.Map<PriceDAO>(book.Price);

            await _context.Books.AddAsync(bookDAO);
            await _context.SaveChangesAsync();

            return book;
        }

        public Task<List<Core.Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Core.Book> GetById(Guid id)
        {
            BookDAO book = await _context.Books.FindAsync(id);
            if (book == null)
                throw new Exception("Invalid ID");
            return Core.Book.Create(book.Id, book.Title, book.Author, book.Discription);
        }

        public Task<Core.Book> Update(Core.Book book)
        {
            throw new NotImplementedException();
        }
    }
}
