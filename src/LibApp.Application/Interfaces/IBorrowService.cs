using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Interfaces
{
    public interface IBorrowService
    {
        /// <summary>
        /// Create borrow
        /// </summary>
        /// <param name="req">Data</param>
        /// <param name="userId">User Create</param>
        /// <returns></returns>
        Task<ResultDto<BorrowDtoRes>> CreateBorrow(CreateBorrowReq req, string userId);
        /// <summary>
        /// Get detail borrow
        /// </summary>
        /// <param name="id">borrow id</param>
        /// <returns></returns>
        Task<ResultDto<BorrowDtoRes>> GetBorrow(Guid id);
        /// <summary>
        /// Get paging borrow
        /// </summary>
        /// <param name="req">filter paging borrow</param>
        /// <returns></returns>
        Task<ResultDto<PagerRes<BorrowDtoRes>>> GetListBorrowByFilter(ListBorrowFilter req);
    }
}
