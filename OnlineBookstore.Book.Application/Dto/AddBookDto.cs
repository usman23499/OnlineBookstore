using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Book.Application.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string? Discription { get; set; }
    }
}
