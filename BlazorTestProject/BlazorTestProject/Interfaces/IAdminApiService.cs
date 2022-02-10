using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Interfaces
{
    public interface IAdminApiService
    {
        Task<List<UserInfoModel>> GetUsers();
        Task<HttpResponseMessage> BlockUser(long userId);
        Task<HttpResponseMessage> UnBlockUser(long userId);
        Task<HttpResponseMessage> SoftDeleteUser(long userId);
        Task<HttpResponseMessage> ChangeUserRole(long userId, string roleName);
    }
}