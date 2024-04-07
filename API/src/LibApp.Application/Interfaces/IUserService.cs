using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.Application.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Update information user
        /// </summary>
        /// <param name="req">information user include first name, last name, email</param>
        /// <param name="userId">user update information user</param>
        /// <returns></returns>
        Task<UpdateUserRes> UpdateUserInformation(UpdateUserReq req, string userId);
    }
}