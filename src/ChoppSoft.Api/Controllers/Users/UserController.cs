﻿using AutoMapper;
using ChoppSoft.Domain.Models.Users.Services;
using ChoppSoft.Domain.Models.Users.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Users
{
    public class UserController : ControllerSoftBase
    {
        private readonly IUserService _userService;
        public UserController(IMapper mapper,
                              IUserService userService) : base(mapper)
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
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {
            return ReturnBase(await _userService.Register(model), "Register");
        }

        [HttpPut("{id:guid}/SetAsManager")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> SetAsManager([FromRoute] Guid userId)
        {
            return ReturnBase(await _userService.SetAsManager(userId), "SetAsManager");
        }

        [HttpPost("ChagePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto model)
        {
            return ReturnBase(await _userService.ChangePassword(model), "Change password");
        }

        [HttpGet("List")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            return ReturnBase(await _userService.GetAll(query), "GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "user_id")?.Value;

            if (userIdClaim == null)
                return ReturnBase(ServiceResult.Failed("Não foi possível recuperar o código do usuário via token."));

            var response = await _userService.GetById(Guid.Parse(userIdClaim));

            return ReturnBase(response);
        }
    }
}
