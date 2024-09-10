using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Book.Core
{
    public interface IBookRepository
    {
        Task<Book>       GetById(Guid id);
        Task<List<Book>> GetAll();
        Task<Book>       Add(Book book);
        Task<Book>       Update(Book book);
    }
}
