
using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Exceptions;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.DAL.Context;
using BlazorTestProject.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorTestProject.BLL.Enums;
using Microsoft.EntityFrameworkCore;

namespace BlazorTestProject.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly BlazoreTestProjectContext _ctx;
        private readonly IMapper _mapper;
        private readonly IPasswordProcessing _passProcess;
        private const long ID_NOT_FOUND = 0;

        public AuthenticationService(BlazoreTestProjectContext ctx, IMapper mapper, IPasswordProcessing passProcess)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
            _passProcess = passProcess ?? throw new ArgumentNullException(nameof(IPasswordProcessing));
        }

        public async Task<long> RegisterUserAsync(UserDTO userDTO)
        {
            if (userDTO == null) throw new EntityArgumentNullException(nameof(userDTO));
            if (string.IsNullOrWhiteSpace(userDTO.Firstname))
                throw new EntityArgumentNullException(nameof(userDTO.Firstname));
            if (string.IsNullOrWhiteSpace(userDTO.Username))
                throw new EntityArgumentNullException(nameof(userDTO.Username));
            if (string.IsNullOrWhiteSpace(userDTO.Lastname))
                throw new EntityArgumentNullException(nameof(userDTO.Lastname));
            if (string.IsNullOrWhiteSpace(userDTO.Password))
                throw new EntityArgumentNullException(nameof(userDTO.Password));

            var salt = _passProcess.GenerateSalt();

            var role = await _ctx.Set<Role>().Where(x => x.Id == (long) Roles.Customer)
                .SingleOrDefaultAsync() ?? throw new NullReferenceException(nameof(Role));

            var user = _mapper.Map<User>(userDTO);
            user.Password = _passProcess.GetHashCode(userDTO.Password, salt);
            user.Salt = salt;
            user.RoleId = role.Id;
            user.IsDelete = false;
            user.IsBlock = false;

            _ctx.Set<User>().Add(user);
            await _ctx.SaveChangesAsync();
            if (user.Id <= ID_NOT_FOUND) throw new FailedAddToDatabaseException();
            return user.Id;
        }

        public async Task<long> VerifyCredentialsAsync(string username, string password)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));

            var user = await _ctx.Set<User>().Where(x => x.Username == username && !x.IsDelete)
                .SingleOrDefaultAsync();
            if (user != null)
            {
                string pass = _passProcess.GetHashCode(password, user.Salt);
                if (user.Password == pass)
                    return user.Id;
            }
            throw new ArgumentNullException(nameof(user));
        }

        #region GetMethods
        public async Task<UserIdentityDTO> GetUserIdentityById(long id)
        {
            var user = await _ctx.Set<User>().Where(x => x.Id == id && !x.IsDelete).
                Include(x => x.Role).SingleOrDefaultAsync();
             if(user == null) throw new ArgumentNullException(nameof(user));
            
            var userIdentity = new UserIdentityDTO()
            {
                RoleName = user.Role.RoleName,
                UserId = user.Id,
                Username = user.Username
            };
            return userIdentity;
        
        }
        #endregion
    }
}

