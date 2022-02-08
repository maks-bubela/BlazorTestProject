
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Interfaces
{
    public interface IAuthenticationApiService
    {
        Task<HttpResponseMessage> Login(UserLoginModel loginRequest);
        Task<HttpResponseMessage> Logout();
        Task<CurrentUser> CurrentUserInfo();
        Task<HttpResponseMessage> Register(UserRegistrationModel registerRequest);

    }
}
