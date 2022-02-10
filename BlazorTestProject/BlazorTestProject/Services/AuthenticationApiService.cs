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
        #region Services
        private readonly HttpClient _httpClient;
        #endregion
        #region Const
        private const string GetUsersTokenEndpoint = "api/authentication/token";
        private const string GetCurrentUserEndpoint = "api/authentication/user/info";
        private const string RegistrationUserEndpoint = "api/authentication/registration";
        #endregion
        #region MyRegion
        public AuthenticationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        #region Login
        public async Task<HttpResponseMessage> LoginAsync(UserLoginModel loginRequest)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(GetUsersTokenEndpoint, loginRequest);
            return httpResponse;
        }
        #endregion
        #region InfoMethods
        public async Task<CurrentUser> CurrentUserInfoAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>(GetCurrentUserEndpoint);
            return result;
        }
        #endregion
        #region Registration
        public async Task<HttpResponseMessage> RegisterAsync(UserRegistrationModel registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync
                (RegistrationUserEndpoint, registerRequest);
            return result.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
