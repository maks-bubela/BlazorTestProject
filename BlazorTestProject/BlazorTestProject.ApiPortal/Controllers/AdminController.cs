using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlazorTestProject.ApiPortal.Controllers
{
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        #region Services
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;
        #endregion

        public AdminController(IMapper mapper, IAdminService adminService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(IAdminService));
        }
        [HttpGet]
        [Authorize]
        [Route("get/users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var usersList = await _adminService.ListUsersAsync();
            var userListModels = _mapper.Map<List<UserInfoModel>>(usersList);
            return Ok(userListModels);
        }

        [HttpPut]
        [Authorize]
        [Route("user/block")]
        public async Task<IActionResult> BlockUser([FromBody] long userId)
        {
            if (ModelState.IsValid)
            {
                var isBlocked = await _adminService.BlockUser(userId);
                if (isBlocked)
                    return Ok();
                return Conflict();
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        [Route("user/unblock")]
        public async Task<IActionResult> UnBlockUser([FromBody] long userId)
        {
            if (ModelState.IsValid)
            {
                var isUnBlocked = await _adminService.UnBlockUser(userId);
                if (isUnBlocked)
                    return Ok();
                return Conflict();
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        [Route("user/soft/delete")]
        public async Task<IActionResult> DeleteUser([FromBody] long userId)
        {
            if (ModelState.IsValid)
            {
                var isDelete = await _adminService.UserSoftDelete(userId);
                if (isDelete)
                    return Ok();
                return Conflict();
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        [Route("user/role/change")]
        public async Task<IActionResult> ChangeUserRole([FromBody] UserChangeRoleModel changeRoleModel)
        {
            if (ModelState.IsValid)
            {
                var isChange = await _adminService.ChangeUserRole
                    (changeRoleModel.userId, changeRoleModel.roleName);
                if (isChange)
                    return Ok();
                return Conflict();
            }
            return BadRequest();
        }

    }
}
