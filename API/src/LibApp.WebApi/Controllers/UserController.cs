using Microsoft.AspNetCore.Mvc;
using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<UpdateUserRes>> UpdateUserInformation(UpdateUserReq user)
        {
            var result = await _userService.UpdateUserInformation(user,GetUserId());
            return Ok(result);
        }
    }
}
