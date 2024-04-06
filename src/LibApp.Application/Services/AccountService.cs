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
using LibApp.Application.Resources;

namespace LibApp.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;

        public AccountService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
        }

        public async Task<bool> CreateAccount(CreateAccountReq account)
        {
            account.Password = Utilities.EncryptKey(account.Password);

            var user = await _unitOfWork.Repository<User>().AddAsync(new User
            {
                FirstName = account.UserName,
                LastName = "",
                EmailId = "",
            });

            var accountRes = await _unitOfWork.Repository<Account>().AddAsync(new Account
            {
                UserName = account.UserName,
                Password = account.Password,
                UserId = user.Id,
            });

            await _unitOfWork.SaveChangesAsync();

            _loggerService.LogInfo("New user created");

            return true;
        }
    }
}