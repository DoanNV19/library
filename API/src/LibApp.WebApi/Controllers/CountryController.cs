﻿using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Create country api
        /// </summary>
        /// <param name="req">infomation country</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCountry(CreateCountryReq req)
        {
            return Ok(await _countryService.CreateCountry(req));
        }
    }
}
