using System;
using Microsoft.AspNetCore.Mvc;
using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
		{
            _accountService = accountService;
        }

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateUserRes>> CreateAccount(CreateAccountReq account)
        {
            var result = new ResultDto<string>(false);
            _ = await _accountService.CreateAccount(account);
            return Ok(result);
        }
    }
}

