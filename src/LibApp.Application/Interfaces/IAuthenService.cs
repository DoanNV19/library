using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.Application.Interfaces
{
    public interface IAuthenService
    {
        Task<ResultDto<AuthenRes>> Login(AuthenReq req);
    }
}