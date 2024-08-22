using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Application.Book;
using OnlineBookstore.Application.Dto;
using OnlineBookstore.Application.User;
using OnlineBookstore.Application.User.Dto;
using OnlineBookstore.Core;
using OnlineBookstore.Core.User;

namespace OnlineBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger logger;

        public UserController(IUserService userService, ILogger<BookController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            UserRM userRm = await userService.Login(email, password);
            return Ok(userRm);
        }
        
        [HttpPost("Register")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> Register(UserDTO Dto)
        {
            User user = await userService.Register(Dto); 
            return Ok(user);
        }

        [HttpPost("AddRole")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> AddRole(string roleName)
        {
            RoleRM role = await userService.AddRole(roleName);
            return Ok(role);
        }
    }
}
