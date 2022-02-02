using BlazorTestProject.DAL.Interfaces;
using System.Collections.Generic;

namespace BlazorTestProject.DAL.Entities
{
    public class Role : IEntity
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; private set; } = new HashSet<User>();
    }
}
