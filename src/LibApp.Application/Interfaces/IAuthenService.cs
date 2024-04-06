using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.Application.Interfaces
{
    public interface IAuthenService
    {
        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="req">Information login (userName,Password)</param>
        /// <returns>Token + userInformation</returns>
        Task<ResultDto<AuthenRes>> Login(AuthenReq req);
    }
}