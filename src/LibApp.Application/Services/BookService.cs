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
using LibApp.Application.Models.Requests.User;
using LibApp.Application.Models.Responses.User;
using Mapster;
using LibApp.Application.Models.Responses.Book;
using LibApp.Application.Models.Requests.Book;
using LibApp.Application.Models.Responses.Author;

namespace LibApp.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public BookService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<ResultDto<BookDtoRes>> CreateBook(CreateBookReq req,string userId)
        {
            var result = new ResultDto<BookDtoRes>(false);
            var book = req.Adapt<Book>();
            var bookRes = await _unitOfWork.Repository<Book>().AddAsync(book, userId);
            result.ReturnSuccess(bookRes.Adapt<BookDtoRes>());
            _loggerService.LogInfo("add new book");
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<ResultDto<BookDtoRes>> GetBook(Guid id)
        {
            var result = new ResultDto<BookDtoRes>(false);
            var book = await _unitOfWork.Repository<Book>().GetByIdAsync(id, (x => x.Author));
            result.ReturnSuccess(book.Adapt<BookDtoRes>());
            return result;
        }
    }
}