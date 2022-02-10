using BlazorTestProject.Interfaces;
using BlazorTestProject.Providers;
using BlazorTestProject.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTestProject.ExtensionMethods
{
    public static class AddApiServices
    {
        public static void AddApiService(this IServiceCollection Services)
        {
            Services.AddScoped<AuthStateProvider>();
            Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
            Services.AddScoped<IAuthenticationApiService, AuthenticationApiService>();
            Services.AddScoped<ILocalStorageService, LocalStorageService>();
            Services.AddScoped<IAdminApiService, AdminApiService>();
            Services.AddScoped<IUserApiService, UserApiService>();
            Services.AddScoped<IRoleApiService, RoleApiService>();
        }
    }
}