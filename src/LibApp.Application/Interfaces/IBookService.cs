using LibApp.Application.Models.Requests.Book;
using LibApp.Application.Models.Requests.User;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.Author;
using LibApp.Application.Models.Responses.Book;
using LibApp.Application.Models.Responses.Common;
using LibApp.Application.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Create book
        /// </summary>
        /// <param name="req">book information</param>
        /// <returns></returns>
        Task<ResultDto<BookDtoRes>> CreateBook(CreateBookReq req,string userId);
        Task<ResultDto<BookDtoRes>> GetBook(Guid id);
        Task<ResultDto<string>> DeleteBook(Guid id);
        Task<ResultDto<PagerRes<BookDtoRes>>> GetPageBook(PagerReq req);
    }
}
