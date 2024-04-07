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
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<CreateAccountRes>> CreateAccount(CreateAccountReq account)
        {
            return Ok(await _accountService.CreateAccount(account, GetUserId()));
        }

        /// <summary>
        /// Create account
        /// </summary>
        /// <param name="account">Informatin account</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePasse(AccountChangePass req)
        {
            return Ok(await _accountService.ChangePass(req, GetUserId()));
        }

        /// <summary>
        /// Api change account status
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeAccountsStatus(AccountChangeReq req)
        {
            return Ok(await _accountService.ChangeAccountsStatus(req, GetUserId()));
        }
    }
}

