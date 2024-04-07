using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerReq req)
        {
            return Ok(await _customerService.CreateCustomer(req,GetUserId()));
        }
    }
}
