using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Domain.Specifications;
using LibApp.Domain.Entities;
using LibApp.Application.Models.DTOs;
using LibApp.Application.Interfaces;
using LibApp.Application.Core.Services;
using LibApp.Domain.Core.Repositories;
using LibApp.Application.Resources;
using Mapster;

namespace LibApp.Application.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
        private readonly IJwtUtils _jwtUtils;

        public AuthenService(IUnitOfWork unitOfWork, ILoggerService loggerService,IJwtUtils jwtUtils)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
            _jwtUtils = jwtUtils;
        }

        public async Task<ResultDto<AuthenRes>> Login(AuthenReq req)
        {
            var result = new ResultDto<AuthenRes>(false);
            req.Password = Utilities.EncryptKey(req.Password);
            var accountByUserName = AccountSpecifications.GetAccountByUserName(req.UserName);
            var account = await _unitOfWork.Repository<Account>().FirstOrDefaultAsync(accountByUserName!,x=>x.User!);
            if (account == null)
            {
                return result.ReturnFail(ErrorCode.UserNotFound);
            }

            if(account.Password != req.Password)
            {
                return result.ReturnFail(ErrorCode.WrongPassword);
            }

            var token = _jwtUtils.GenerateJwtToken(account);
            return result.ReturnSuccess(new AuthenRes() { AccessToken= token, User = account.User.Adapt<UserDTO>() });
        }
    }
}