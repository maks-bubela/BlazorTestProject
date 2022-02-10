using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTestProject.BLL.DTO;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<List<UserInfoDTO>> ListUsersAsync();
        Task<bool> BlockUser(long id);
        Task<bool> UserSoftDelete(long id);
        Task<bool> UnBlockUser(long id);
        Task<bool> ChangeUserRole(long userId, string roleName);
    }
}