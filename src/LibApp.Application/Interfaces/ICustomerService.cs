
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.Customer;

namespace LibApp.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<ResultDto<CustomerDtoRes>> CreateCustomer(CreateCustomerReq req,string userId);
    }
}
