using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests.Author;
using LibApp.Application.Models.Requests.Book;
using LibApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorReq req)
        {
            return Ok(await _authorService.CreateAuthor(req, GetUserId()));
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            return Ok(await _authorService.GetAuthor(id));
        }
    }
}
