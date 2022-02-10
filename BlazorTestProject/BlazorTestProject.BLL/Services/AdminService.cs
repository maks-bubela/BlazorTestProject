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
        public async Task<List<UserInfoDTO>> ListUsersAsync()
        {
            var users = await _ctx.Set<User>().Where(x => x.RoleId != (long)Roles.Admin & !x.IsDelete)
                .Include(x => x.Role).ToListAsync();
            if (users == null) throw new ArgumentNullException(nameof(users));
            return _mapper.Map<List<UserInfoDTO>>(users);
        }

        public async Task<bool> BlockUser(long id)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == id).SingleOrDefaultAsync();
            user.IsBlock = true;
            _ctx.Entry(user).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserSoftDelete(long id)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == id).SingleOrDefaultAsync();
            user.IsDelete = true;
            _ctx.Entry(user).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnBlockUser(long id)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == id).SingleOrDefaultAsync();
            user.IsBlock = false;
            _ctx.Entry(user).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeUserRole(long userId, string roleName)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == userId).SingleOrDefaultAsync();
            var role = await _ctx.Set<Role>().Where(x => x.RoleName == roleName).SingleOrDefaultAsync();
            user.RoleId = role.Id;
            _ctx.Entry(user).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}