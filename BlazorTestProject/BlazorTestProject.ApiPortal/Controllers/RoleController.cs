using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.ApiPortal.Interfaces;
using BlazorTestProject.BLL.Enums;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlazorTestProject.ApiPortal.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        #region Services
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        #endregion

        public RoleController(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _roleService = roleService ?? throw new ArgumentNullException(nameof(IAuthenticationService));
        }

        [HttpGet]
        [Authorize]
        [Route("get/roles")]
        public async Task<List<RoleNamesModel>> RolesInfoAsync()
        {
            var roles = await _roleService.GetRoles();
            return _mapper.Map<List<RoleNamesModel>>(roles);
        }
    }
}
