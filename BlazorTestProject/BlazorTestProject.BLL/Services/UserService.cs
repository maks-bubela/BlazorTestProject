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
    public class UserService : IUserService
    {
        private readonly BlazoreTestProjectContext _ctx;

        public UserService(BlazoreTestProjectContext ctx, IMapper mapper, IPasswordProcessing passProcess)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public async Task<bool> IsBlockUser(long id)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == id & !x.IsDelete).SingleOrDefaultAsync();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return user.IsBlock;
        }
    }
}