using LibApp.Application.Models.Requests.Author;
using LibApp.Application.Models.Requests.Book;
using LibApp.Application.Models.Requests.User;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.Author;
using LibApp.Application.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<ResultDto<AuthorDtoRes>> CreateAuthor(CreateAuthorReq req, string userId);
        Task<ResultDto<AuthorDtoRes>> GetAuthor(Guid id);
    }
}
