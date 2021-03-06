using BlazorTestProject.DAL.Interfaces;

namespace BlazorTestProject.DAL.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }
        public string Salt { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; private set; }
        public bool IsDelete { get; set; }
        public bool IsBlock { get; set; }
    }
}
