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
using LibApp.Application.Models.Responses.Customer;
using System.Security.Principal;

namespace LibApp.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public CustomerService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<ResultDto<CustomerDtoRes>> CreateCustomer(CreateCustomerReq req, string userId)
        {
            var result = new ResultDto<CustomerDtoRes>(false);
            var accountRes = await _unitOfWork.Repository<Customer>().AddAsync(req.Adapt<Customer>(), userId);
            await _unitOfWork.SaveChangesAsync();
            result.ReturnSuccess(accountRes.Adapt<CustomerDtoRes>());
            return result;
        }
    }
}