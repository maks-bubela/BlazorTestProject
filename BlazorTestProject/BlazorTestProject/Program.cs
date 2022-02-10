using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTestProject.ExtensionMethods;
using BlazorTestProject.Interfaces;
namespace BlazorTestProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add< App>("app");
            builder.AddService();
            await builder.Build().RunAsync();
        }
    }
}
