using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.DAL.Context;
using BlazorTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestProject.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly BlazoreTestProjectContext _ctx;
        private readonly IMapper _mapper;

        public RoleService(BlazoreTestProjectContext ctx, IMapper mapper)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        #region GetMethods
        public async Task<List<RoleDTO>> GetRoles()
        {
            var roles = await _ctx.Set<Role>().ToListAsync();
            if (roles == null) throw new ArgumentNullException(nameof(roles));
            return _mapper.Map<List<RoleDTO>>(roles);
        }
        #endregion
    }
}