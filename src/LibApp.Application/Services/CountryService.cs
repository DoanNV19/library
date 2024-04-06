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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public CountryService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<ResultDto<CountryDtoRes>> CreateCountry(CreateCountryReq req)
        {
            var result = new ResultDto<CountryDtoRes>(false);
            var country = await _unitOfWork.Repository<Country>().AddAsync(req.Adapt<Country>());
            result.ReturnSuccess(country.Adapt<CountryDtoRes>());
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}