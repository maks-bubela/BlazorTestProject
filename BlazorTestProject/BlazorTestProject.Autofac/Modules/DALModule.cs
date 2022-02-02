using Autofac;
using BlazorTestProject.DAL.Context;

namespace BlazorTestProject.Autofac.Modules
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var connectionString = MintyIssueTrackerCoreConfiguration.CreateFromConfigurations().SqlConnectionString;

            builder.Register(ctx => new BlazoreTestProjectContext("")).AsSelf();

            base.Load(builder);
        }
    }
}