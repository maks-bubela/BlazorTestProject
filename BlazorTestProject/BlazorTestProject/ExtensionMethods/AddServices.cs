using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorTestProject.ExtensionMethods
{
    public static class AddServices
    {
        private const string HostApi = "https://localhost:44323/";
        public static void AddService(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<HttpContextAccessor>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(HostApi) });
            builder.Services.AddAuthenticationCore();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddApiService();
            builder.Services.AddHttpClientInterceptor();
        }
    }
}
