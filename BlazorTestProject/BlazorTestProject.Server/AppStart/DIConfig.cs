using Autofac;
using AutoMapper;
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
            containerBuilder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfileBLL());
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            return containerBuilder;
        }
    }
}
