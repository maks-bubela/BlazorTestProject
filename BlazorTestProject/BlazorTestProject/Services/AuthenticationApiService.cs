using System;
using System.Collections.Generic;
using BlazorTestProject.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public async Task<HttpResponseMessage> LoginAsync(UserLoginModel loginRequest)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync("api/authentication/token", loginRequest);
            return httpResponse;
        }

        public async Task<List<RoleNamesModel>> GetRolesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RoleNamesModel>>
                ("api/authentication/users/get/roles");
            return result;
        }

        public async Task<CurrentUser> CurrentUserInfoAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/authentication/user/info");
            return result;
        }

        public async Task<HttpResponseMessage> RegisterAsync(UserRegistrationModel registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync
                ("api/authentication/registration", registerRequest);
            return result.EnsureSuccessStatusCode();
        }
    }
}
