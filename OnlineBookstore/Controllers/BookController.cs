using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineBookstore.Application.Book;
using OnlineBookstore.Application.Dto;
using OnlineBookstore.Core;

namespace OnlineBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly ILogger logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            this.bookService = bookService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            List<Order> orders = await bookService.GetOrdersAll();
            logger.LogInformation("Get All books");
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDto Dto)
        {
            Book book = await bookService.AddBook(Dto);
            return Ok(book);
        }

        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> AddOrder(CreateOrderDto Dto)
        {
            Order order = await bookService.CreateOrder(Dto);
            return Ok(order);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            Order order = await bookService.GetOrderById(id);
            logger.LogInformation("Get book by id");
            return Ok(order);
        }

    }
}
