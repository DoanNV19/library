using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Domain.Specifications;
using LibApp.Domain.Entities;
using LibApp.Domain.Enums;
using LibApp.Domain.Exceptions;
using LibApp.Application.Models.DTOs;
using LibApp.Application.Interfaces;
using LibApp.Application.Core.Services;
using LibApp.Domain.Core.Repositories;
using Mapster;

namespace LibApp.Application.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public BorrowService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<ResultDto<BorrowDtoRes>> CreateBorrow(CreateBorrowReq req, string userId)
        {
            var result = new ResultDto<BorrowDtoRes>(false);
            var borrowRes = await _unitOfWork.Repository<Borrow>().AddAsync(req.Adapt<Borrow>(), userId);
            await _unitOfWork.SaveChangesAsync();
            result.ReturnSuccess(borrowRes.Adapt<BorrowDtoRes>());
            return result;
        }

        public async Task<ResultDto<BorrowDtoRes>> GetBorrow(Guid id)
        {
            var result = new ResultDto<BorrowDtoRes>(false);
            var borrowDetail = await _unitOfWork.Repository<Borrow>().GetByIdAsync(id, x => x.Book!,x => x.Customer!);
            result.ReturnSuccess(borrowDetail.Adapt<BorrowDtoRes>());
            return result;
        }

        public async Task<ResultDto<PagerRes<BorrowDtoRes>>> GetListBorrowByFilter(ListBorrowFilter req)
        {
            var result = new ResultDto<PagerRes<BorrowDtoRes>>(false);
            var borrowSpec = BorrowSpecifications.GetBorrowByFilter(req.KeySearch,req.BookId,req.CustomerId);
            var borrows = await _unitOfWork.Repository<Borrow>().ListPagingAsync(borrowSpec, req.PageIndex, req.PageSize, x => x.Book!,x=>x.Customer!);
            var countBorrows = await _unitOfWork.Repository<Borrow>().CountAsync(borrowSpec);
            result.ReturnSuccess(new PagerRes<BorrowDtoRes>() { Data = borrows.Adapt<List<BorrowDtoRes>>(), TotalRecord = countBorrows });
            return result;
        }
    }
}