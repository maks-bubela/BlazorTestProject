using System.Net.Http;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Interfaces
{
    public interface IUserApiService
    {
        Task<bool> IsUserBlocked();
        Task<HttpResponseMessage> ChangePass(ChangePasswordModel model);
    }
}