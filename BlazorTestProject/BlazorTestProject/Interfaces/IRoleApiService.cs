using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Interfaces
{
    public interface IRoleApiService
    {
        Task<List<RoleNamesModel>> GetRolesAsync();
    }
}