using Autofac;
using BlazorTestProject.Configuration;
using BlazorTestProject.DAL.Context;

namespace BlazorTestProject.Autofac.Modules
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = BlazorTestProjectConfiguration.CreateFromConfigurations().SqlConnectionString;

            builder.Register(ctx => new BlazoreTestProjectContext(connectionString)).AsSelf();

            base.Load(builder);
        }
    }
}