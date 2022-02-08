namespace BlazorTestProject.Models.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long RoleId { get; set; }
        public bool IsDelete { get; set; }
        public bool IsBlock { get; set; }
    }
}