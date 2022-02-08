using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Interfaces
{
    public interface IAdminApiService
    {
        Task<List<UserModel>> GetUsers();
    }
}