using ChoppSoft.Domain.Models.Users.Services;
using ChoppSoft.Domain.Models.Users.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Users
{
    public class UserController : ControllerSoftBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDto model)
        {
            return ReturnBase(await _userService.GetUser(model), "Login");
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {
            return ReturnBase(await _userService.Register(model), "Register");
        }

        [HttpPost("ChagePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            return ReturnBase(await _userService.ChangePassword(model), "Chande password");
        }
    }
}
