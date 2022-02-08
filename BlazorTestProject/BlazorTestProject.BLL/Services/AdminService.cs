using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Enums;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.DAL.Context;
using BlazorTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestProject.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly BlazoreTestProjectContext _ctx;
        private readonly IMapper _mapper;

        public AdminService(BlazoreTestProjectContext ctx, IMapper mapper, IPasswordProcessing passProcess)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }
        public async Task<List<UserDTO>> ListUsersAsync()
        {
            var users = await _ctx.Set<User>().Where(x => x.RoleId != (long)Roles.Admin).ToListAsync();
            if (users == null) throw new ArgumentNullException(nameof(users));
            
            return _mapper.Map<List<UserDTO>>(users);

        }
    }
}