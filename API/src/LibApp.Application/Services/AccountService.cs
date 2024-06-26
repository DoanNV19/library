using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Domain.Entities;
using LibApp.Application.Interfaces;
using LibApp.Application.Core.Services;
using LibApp.Domain.Core.Repositories;
using LibApp.Application.Resources;
using LibApp.Domain.Specifications;

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

        public async Task<ResultDto<string>> ChangePass(AccountChangePass req, string userId)
        {
            var result = new ResultDto<string>(true);
            if (req.OldPass != req.NewPass)
            {
                result.ReturnFail("Pass not compare");
                return result;
            }

            req.OldPass = Utilities.EncryptKey(req.OldPass);
            req.NewPass = Utilities.EncryptKey(req.NewPass);
            var account = await _unitOfWork.Repository<Account>().GetByIdAsync(new Guid(userId));
            if (account == null)
            {
                result.ReturnFail("Not Found");
                return result;
            }
            if(account.Password != req.OldPass)
            {
                result.ReturnFail("Old pass not compare");
                return result;
            }
            account.Password = req.NewPass;
            _unitOfWork.Repository<Account>().Update(account);
            await _unitOfWork.SaveChangesAsync();
            return result;
        }


        public async Task<ResultDto<string>> ChangeAccountsStatus(AccountChangeReq req, string userId)
        {
            var result = new ResultDto<string>(true);
            var accountSpec = AccountSpecifications.GetAccountInList(req.Ids);
            var accounts = (await _unitOfWork.Repository<Account>().ListAsync(accountSpec!)).ToList();
            accounts.ForEach(x =>
            {
                x.Status = req.AccountStatus;
                _unitOfWork.Repository<Account>().Update(x,userId);
            });
            await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<ResultDto<string>> CreateAccount(CreateAccountReq account, string userId)
        {
            var result = new ResultDto<string>(true);
            account.Password = Utilities.EncryptKey(account.Password);

            var accountSpec = AccountSpecifications.GetAccountByUserName(account.UserName);
            var accountExits = await _unitOfWork.Repository<Account>().FirstOrDefaultAsync(accountSpec!);
            if(accountExits != null)
            {
                result.ReturnFail("duplicate user name");
                return result;
            }

            var user = await _unitOfWork.Repository<User>().AddAsync(new User
            {
                FirstName = account.UserName,
                LastName = "",
                EmailId = ""
            }, userId);

            await _unitOfWork.Repository<Account>().AddAsync(new Account
            {
                UserName = account.UserName,
                Password = account.Password,
                UserId = user.Id
            }, userId);

            await _unitOfWork.SaveChangesAsync();

            _loggerService.LogInfo("New user created");

            return result;
        }
    }
}