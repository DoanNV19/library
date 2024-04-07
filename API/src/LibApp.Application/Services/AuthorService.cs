using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Domain.Entities;
using LibApp.Application.Interfaces;
using LibApp.Application.Core.Services;
using LibApp.Domain.Core.Repositories;
using Mapster;

namespace LibApp.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public AuthorService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<ResultDto<AuthorDtoRes>> CreateAuthor(CreateAuthorReq req,string userId)
        {
            var result = new ResultDto<AuthorDtoRes>(false);
            var author = req.Adapt<Author>();
            var authorRes = await _unitOfWork.Repository<Author>().AddAsync(author, userId);
            result.ReturnSuccess(authorRes.Adapt<AuthorDtoRes>());
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<ResultDto<AuthorDtoRes>> GetAuthor(Guid id)
        {
            var result = new ResultDto<AuthorDtoRes>(false);
            var author = await _unitOfWork.Repository<Author>().GetByIdAsync(id, (x=>x.Country!));
            result.ReturnSuccess(author.Adapt<AuthorDtoRes>()); 
            return result;
        }
    }
}