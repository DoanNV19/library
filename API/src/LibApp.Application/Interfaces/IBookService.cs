
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
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
        /// <summary>
        /// Get detail book
        /// </summary>
        /// <param name="id">id of book</param>
        /// <returns></returns>
        Task<ResultDto<BookDtoRes>> GetBook(Guid id);
        /// <summary>
        /// soft delete book
        /// </summary>
        /// <param name="id">id of book need delete</param>
        /// <returns></returns>
        Task<ResultDto<string>> DeleteBook(Guid id);
        /// <summary>
        /// Get paging book
        /// </summary>
        /// <param name="req">page information get data</param>
        /// <returns>list book according to filter </returns>
        Task<ResultDto<PagerRes<BookDtoRes>>> GetPageBook(PagerReq req);
    }
}
