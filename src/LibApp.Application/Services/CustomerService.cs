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
    }
}