using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.Interfaces;
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
        [Route("blockstatus")]
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
    }
}
