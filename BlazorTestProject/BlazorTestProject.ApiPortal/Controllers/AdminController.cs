using System;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.Interfaces;
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
        [Route("get/users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var usersList = await _adminService.ListUsersAsync();
            return Ok(usersList);
        }
    }
}
