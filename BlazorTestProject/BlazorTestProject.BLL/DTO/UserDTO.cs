﻿
namespace BlazorTestProject.BLL.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }
        public long RoleId { get; set; }
        public bool IsDelete { get; set; }
        public bool IsBlock { get; set; }
    }
}
