using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BlazorTestProject.ApiPortal.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Services
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        #endregion

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(IUserService));
        }
        [HttpGet]
        [Authorize]
        [Route("block/status")]
        public async Task<IActionResult> IsBlockUser()
        {
            var userId = User.Identity.GetUserId<long>();
            if (userId > 0)
            {
                var isBlocked = await _userService.IsBlockUser(userId);
                return Ok(isBlocked);
            }
            throw new ArgumentNullException(nameof(userId));
        }

        [HttpPut]
        [Authorize]
        [Route("change/password")]
        public async Task<IActionResult> UserPassChange(ChangePasswordModel model)
        {
            var userId = User.Identity.GetUserId<long>();
            if (ModelState.IsValid && userId > 0)
            {
                var changePassDTO = _mapper.Map<UserChangePasswordDTO>(model);
                var isChange = await _userService.UserChangePass(changePassDTO, userId);
                return Ok(isChange);
            }
            throw new ArgumentNullException(nameof(ChangePasswordModel));
        }
    }
}
