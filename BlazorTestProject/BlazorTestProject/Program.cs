using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using Microsoft.AspNetCore.Http;
using BlazorTestProject.Providers;
using BlazorTestProject.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorTestProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add< App>("app");
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44323/") });
            builder.Services.AddAuthenticationCore();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
            builder.Services.AddScoped<IAuthenticationApiService, AuthenticationApiService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<IAdminApiService, AdminApiService>();
            builder.Services.AddScoped<IUserApiService, UserApiService>();
            builder.Services.AddHttpClientInterceptor();
            await builder.Build().RunAsync();
        }
    }
}
