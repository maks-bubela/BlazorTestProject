using Microsoft.EntityFrameworkCore;
using BlazorTestProject.BLL.Exceptions;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.DAL.Context;
using BlazorTestProject.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorTestProject.BLL.Enums;

namespace BlazorTestProject.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly BlazoreTestProjectContext _ctx;
        public TokenService(BlazoreTestProjectContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(BlazoreTestProjectContext));
        }

        #region GetMethods
        public async Task<int> GetTokenSettingsAsync(EnvirementTypes type)
        {
            var tokenSetting = await _ctx.Set<BearerTokenSetting>().Include(x => x.EnvironmentType)
                .Where(b => b.EnvironmentType.Id == ((long)type))
                .SingleOrDefaultAsync() ?? throw new EntityArgumentNullException(nameof(BearerTokenSetting));
            return tokenSetting.LifeTime;
        }
        #endregion
    }
}
