using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Book.Application.Dto
{
    public class CreateOrderDto
    {
        public int Quantity { get; set; }
        public Guid BookId { get; set; }
    }
}
