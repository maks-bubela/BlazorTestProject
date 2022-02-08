
using System;
using BlazorTestProject.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Services
{
    public class AuthenticationApiService : IAuthenticationApiService
    {
        private readonly HttpClient _httpClient;
        public AuthenticationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Login(UserLoginModel loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/login", loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
        public async Task<HttpResponseMessage> Logout()
        {
            var result = await _httpClient.PostAsync("api/authentication/logout", null);
            return result.EnsureSuccessStatusCode();
        }

        public async Task<CurrentUser> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/authentication/user/info");
            return result;
        }

        public async Task<HttpResponseMessage> Register(UserRegistrationModel registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync
                ("api/authentication/registration", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result.EnsureSuccessStatusCode();
        }
    }
}
