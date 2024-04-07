using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Create book
        /// </summary>
        /// <param name="req">book information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookReq req)
        {
            return Ok(await _bookService.CreateBook(req,GetUserId()));
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">id of book</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            return Ok(await _bookService.GetBook(id));
        }
        
        /// <summary>
        /// Soft delete book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
        
        /// <summary>
        /// Get book by paging
        /// </summary>
        /// <param name="req">page information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPageBook")]
        public async Task<IActionResult> GetPageBook(PagerReq req)
        {
            return Ok(await _bookService.GetPageBook(req));
        }
    }
}
