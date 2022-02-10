using Autofac;
using BlazorTestProject.BLL.Cryptography;
using BlazorTestProject.BLL.Interfaces;
using BlazorTestProject.BLL.Services;

namespace BlazorTestProject.Autofac.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<AdminService>().As<IAdminService>();
            builder.RegisterType<PasswordProcessing>().As<IPasswordProcessing>();
            builder.RegisterType<TokenService>().As<ITokenService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            base.Load(builder);
        }
    }
}