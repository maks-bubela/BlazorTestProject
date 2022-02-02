
using AutoMapper;
using BlazorTestProject.BLL.DTO;
using BlazorTestProject.BLL.Exceptions;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.DAL.Context;
using BlazorTestProject.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace BlazorTestProject.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly BlazoreTestProjectContext _ctx;
        private readonly IMapper _mapper;
        private const long ID_NOT_FOUND = 0;

        public AuthenticationService(BlazoreTestProjectContext ctx, IMapper mapper)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public async Task<long> AddNewAzureBlobTypeAsync(UserDTO dto)
        {
            if (dto == null) throw new EntityArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Firstname)) throw new EntityArgumentNullException(nameof(dto.Firstname));
            if (string.IsNullOrWhiteSpace(dto.Username)) throw new EntityArgumentNullException(nameof(dto.Username));
            if (string.IsNullOrWhiteSpace(dto.Lastname)) throw new EntityArgumentNullException(nameof(dto.Lastname));
            if (string.IsNullOrWhiteSpace(dto.Password)) throw new EntityArgumentNullException(nameof(dto.Password));
            if (dto.RoleId <= ID_NOT_FOUND) throw new EntityArgumentNullException(nameof(dto.RoleId));

            var user = _mapper.Map<User>(dto);
            await _ctx.Set<User>().AddAsync(user);
            await _ctx.SaveChangesAsync();
            if (user.Id > ID_NOT_FOUND)
                return user.Id;
            throw new FailedAddToDatabaseException();
        }
    }
}
