using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.DAL.Context;
using BlazorTestProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestProject.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly BlazoreTestProjectContext _ctx;
        private readonly IPasswordProcessing _passProcess;
        private readonly IAuthenticationService _authenticationService;
        private const long ID_NOT_FOUND = 0;
        private const string AuthenticationFailed = "Incorect Password!";
        public UserService(BlazoreTestProjectContext ctx, IMapper mapper, IPasswordProcessing passProcess,
            IAuthenticationService authenticationService)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _passProcess = passProcess ?? throw new ArgumentNullException(nameof(IPasswordProcessing));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(IPasswordProcessing));
        }
        public async Task<bool> IsBlockUser(long id)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == id & !x.IsDelete).SingleOrDefaultAsync();
            if (user == null) throw new ArgumentNullException(nameof(user));
            return user.IsBlock;
        }

        public async Task<bool> UserChangePass(UserChangePasswordDTO dto, long userId)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == userId & !x.IsDelete).SingleOrDefaultAsync();
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (await _authenticationService.VerifyCredentialsAsync(user.Username, dto.NowPassword) <= ID_NOT_FOUND)
                throw new Exception(AuthenticationFailed);
            user.Password = _passProcess.GetHashCode(dto.Password, user.Salt);
            _ctx.Entry(user).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}