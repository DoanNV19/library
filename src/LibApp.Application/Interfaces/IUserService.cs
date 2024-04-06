using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateAccount(CreateAccountReq account,string userId);
    }
}