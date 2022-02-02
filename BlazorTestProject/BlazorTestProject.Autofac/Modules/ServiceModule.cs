using Autofac;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.BLL.Services;

namespace BlazorTestProject.Autofac.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            base.Load(builder);
        }
    }
}