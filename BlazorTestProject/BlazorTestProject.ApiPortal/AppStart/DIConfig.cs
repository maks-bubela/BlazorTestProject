using Autofac;
using AutoMapper;
using BlazorTestProject.ApiPortal.Interfaces;
using BlazorTestProject.ApiPortal.JwtConfig.Provider;
using BlazorTestProject.ApiPortal.MappingProfiles;
using BlazorTestProject.Autofac.Modules;
using BlazorTestProject.BLL.MappingProfiles;

namespace BlazorTestProject.ApiPortal.AppStart
{
    public class DIConfig
    {
        public static ContainerBuilder Configure(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<DALModule>();
            containerBuilder.RegisterType<AuthOptions>().As<IAuthOptions>();
            containerBuilder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfileBLL());
                cfg.AddProfile(new UserProfileController());
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            return containerBuilder;
        }
    }
}
