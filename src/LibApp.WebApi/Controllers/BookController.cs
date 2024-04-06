using LibApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}
