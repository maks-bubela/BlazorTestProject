using BlazorTestProject.DAL.Interfaces;

namespace BlazorTestProject.DAL.Entities
{
    public class BearerTokenSetting : IEntity
    {
        public long Id { get; set; }

        public byte LifeTime { get; set; }

        public long EnvironmentTypeId { get; set; }
        public virtual EnvironmentType EnvironmentType { get; private set; }
    }
}
