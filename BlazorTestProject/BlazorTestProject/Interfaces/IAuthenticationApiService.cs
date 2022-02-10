
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Interfaces
{
    public interface IAuthenticationApiService
    {
        Task<HttpResponseMessage> LoginAsync(UserLoginModel loginRequest);
        Task<CurrentUser> CurrentUserInfoAsync(string token);
        Task<HttpResponseMessage> RegisterAsync(UserRegistrationModel registerRequest);
    }
}
