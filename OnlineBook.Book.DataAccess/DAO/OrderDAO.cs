using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Book.DataAccess.DAO
{
    public class OrderDAO
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public virtual BookDAO Book { get; set; }
    }
}
