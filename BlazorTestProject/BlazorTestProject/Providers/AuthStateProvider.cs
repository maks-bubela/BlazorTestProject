using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using BlazorTestProject.Models.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorTestProject.Providers
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthenticationApiService _api;
        private readonly ILocalStorageService _localStorage;
        private CurrentUser _currentUser;
        private const string TokenKey = "token";
        public AuthStateProvider(IAuthenticationApiService api, ILocalStorageService localStorage)
        {
            _api = api ?? throw new ArgumentNullException(nameof(IAuthenticationApiService));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(ILocalStorageService));
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
                    identity = new ClaimsIdentity(claims, TokenKey);
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
            var token = await _localStorage.GetItem<string>(TokenKey);
            _currentUser = await _api.CurrentUserInfoAsync(token);
            return _currentUser;
        }

        public async Task Logout()
        {
            _currentUser = null;
            await _localStorage.RemoveItem(TokenKey);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        }
        public async Task<HttpResponseMessage> Login(UserLoginModel loginParameters)
        {
            var response = await _api.LoginAsync(loginParameters);
            var token = await response.Content.ReadAsStringAsync();
            await _localStorage.SetItem(TokenKey, token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return response;
        }
        public async Task<HttpResponseMessage> Register(UserRegistrationModel registerParameters)
        {
            var result = await _api.RegisterAsync(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return result;
        }
    }
}