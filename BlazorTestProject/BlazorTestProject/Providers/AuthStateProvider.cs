using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorTestProject.Providers
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationApiService api;
        private readonly ILocalStorageService _localStorage;
        private CurrentUser _currentUser;
        public AuthStateProvider(IAuthenticationApiService api, ILocalStorageService localStorage)
        {
            this.api = api;
            _localStorage = localStorage;
            _currentUser = new CurrentUser();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }
                        .Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser = await api.CurrentUserInfo();
            return _currentUser;
        }

        public async Task<HttpResponseMessage> Logout()
        {
            var result = await api.Logout();
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return result;
        }
        public async Task<HttpResponseMessage> Login(UserLoginModel loginParameters)
        {
            var result = await api.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return result;
        }
        public async Task<HttpResponseMessage> Register(UserRegistrationModel registerParameters)
        {
            var result = await api.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return result;
        }
    }
}