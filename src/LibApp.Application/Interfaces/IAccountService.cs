using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UpdateUserRes> UpdateUserInfomation(UpdateUserReq req, string userId);
    }
}