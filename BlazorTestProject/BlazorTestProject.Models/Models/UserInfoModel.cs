namespace BlazorTestProject.Models.Models
{
    public class UserInfoModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string RoleName { get; set; }
        public bool IsDelete { get; set; }
        public bool IsBlock { get; set; }
    }
}