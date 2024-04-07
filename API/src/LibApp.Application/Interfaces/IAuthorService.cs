using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// Create author of book
        /// </summary>
        /// <param name="req">Author information</param>
        /// <param name="userId">User create author</param>
        /// <returns>Return author after create</returns>
        Task<ResultDto<AuthorDtoRes>> CreateAuthor(CreateAuthorReq req, string userId);
        /// <summary>
        /// Get detail author
        /// </summary>
        /// <param name="id">id author need get detail</param>
        /// <returns>data author</returns>
        Task<ResultDto<AuthorDtoRes>> GetAuthor(Guid id);
    }
}
