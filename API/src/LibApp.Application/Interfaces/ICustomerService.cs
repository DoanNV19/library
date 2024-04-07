
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using LibApp.Application.Models.Responses.Customer;

namespace LibApp.Application.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="req">Data customer create</param>
        /// <param name="userId">user create customer</param>
        /// <returns>full information customer</returns>
        Task<ResultDto<CustomerDtoRes>> CreateCustomer(CreateCustomerReq req,string userId);
    }
}
