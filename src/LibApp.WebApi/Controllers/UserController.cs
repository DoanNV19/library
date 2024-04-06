using Microsoft.AspNetCore.Mvc;
using LibApp.Application.Interfaces;
using LibApp.Application.Models.Requests;
using LibApp.Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create uer
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CreateUserRes>> CreateUser(CreateUserReq user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        /// <summary>
        /// ValidateUser
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ValidateUserRes>> ValidateUser(ValidateUserReq req)
        {
            var result = await _userService.ValidateUser(req);
            return Ok(result);
        }

        /// <summary>
        /// Get all active user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetAllActiveUsersRes>> GetAllActiveUsers()
        {
            var a = User.Claims;
            var result = await _userService.GetAllActiveUsers();
            return Ok(result);
        }
    }
}
