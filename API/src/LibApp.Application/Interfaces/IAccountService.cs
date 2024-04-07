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
        Task<bool> CreateAccount(CreateAccountReq account,string userId);
    }
}