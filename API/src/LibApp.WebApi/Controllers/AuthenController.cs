﻿using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenService _authenService;
        public AuthenController(IAuthenService authenService)
        {
            _authenService = authenService;
        }

        /// <summary>
        /// Login Api return token and user information
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthenReq req)
        {
            var result = await _authenService.Login(req);
            return Ok(result);
        }
    }
}
