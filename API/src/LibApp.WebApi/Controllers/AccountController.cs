using System;
using Microsoft.AspNetCore.Mvc;
using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
		{
            _accountService = accountService;
        }

        /// <summary>
        /// Create account
        /// </summary>
        /// <param name="account">Informatin account</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateAccountRes>> CreateAccount(CreateAccountReq account)
        {
            var result = new ResultDto<string>(false);
            _ = await _accountService.CreateAccount(account,GetUserId());
            return Ok(result);
        }
    }
}

