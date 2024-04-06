using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Requests.Authen;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.Authen;

namespace LibApp.Application.Interfaces
{
    public interface IAuthenService
    {
        Task<ResultDto<AuthenRes>> Login(AuthenReq req);
    }
}