using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.Application.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Create account
        /// </summary>
        /// <param name="account">data account</param>
        /// <param name="userId">user create</param>
        /// <returns></returns>
        Task<ResultDto<string>> CreateAccount(CreateAccountReq account,string userId);
        /// <summary>
        /// Change pass for current user
        /// </summary>
        /// <param name="req">new pass and old pass</param>
        /// <param name="userId">id user</param>
        /// <returns></returns>
        Task<ResultDto<string>> ChangePass(AccountChangePass req, string userId);
    }
}