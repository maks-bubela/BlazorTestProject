using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTestProject.BLL.DTO;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IAdminService
    {
        Task<List<UserDTO>> ListUsersAsync();
    }
}