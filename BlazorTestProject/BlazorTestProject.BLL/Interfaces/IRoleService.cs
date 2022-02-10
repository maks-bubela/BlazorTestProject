using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTestProject.BLL.DTO;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetRoles();
    }
}