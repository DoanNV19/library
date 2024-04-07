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
        private const int PRICE_ONE_DAY = 10000;    
        public BorrowService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<ResultDto<BorrowDtoRes>> CreateBorrow(CreateBorrowReq req, string userId)
        {
            var result = new ResultDto<BorrowDtoRes>(false);
            var borrow = req.Adapt<Borrow>();
            borrow.Date = DateTime.Now;
            var borrowRes = await _unitOfWork.Repository<Borrow>().AddAsync(borrow, userId);
            await _unitOfWork.SaveChangesAsync();
            result.ReturnSuccess(borrowRes.Adapt<BorrowDtoRes>());
            return result;
        }

        public async Task<ResultDto<BorrowDtoRes>> UpdateBorrow(UpdateBorrowReq req, string userId)
        {
            var result = new ResultDto<BorrowDtoRes>(false);
            var borrow = await _unitOfWork.Repository<Borrow>().GetByIdAsync(req.Id);
            borrow.BookId = req.BookId;
            borrow.CustomerId = req.CustomerId;
            _unitOfWork.Repository<Borrow>().Update(borrow, userId);
            await _unitOfWork.SaveChangesAsync();
            result.ReturnSuccess(borrow.Adapt<BorrowDtoRes>());
            return result;
        }

        public async Task<ResultDto<BorrowPriceDtoRes>> CaculatePriceBorrow(Guid borrowId)
        {
            var result = new ResultDto<BorrowPriceDtoRes>(false);
            var borrow = await _unitOfWork.Repository<Borrow>().GetByIdAsync(borrowId, x => x.Book!);
            if(borrow == null)
            {
                result.ReturnFail("Not Found");
                return result;
            }
            result.ReturnSuccess(new BorrowPriceDtoRes() { Price = CalculatePrice(borrow) });
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

        /// <summary>
        /// Calculate price paid for borrow book
        /// </summary>
        /// <param name="borrow">borrow information</param>
        /// <returns>Price </returns>
        private int CalculatePrice(Borrow borrow)
        {
            var totalDate = (DateTime.Now - borrow.Date);
            return 1;
        }
    }
}