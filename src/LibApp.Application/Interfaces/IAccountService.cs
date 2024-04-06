using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Requests.User;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.User;

namespace LibApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UpdateUserRes> UpdateUserInfomation(UpdateUserReq req, string userId);
    }
}