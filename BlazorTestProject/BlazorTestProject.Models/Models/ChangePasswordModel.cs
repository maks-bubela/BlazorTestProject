using System.ComponentModel.DataAnnotations;

namespace BlazorTestProject.Models.Models
{
    public class ChangePasswordModel
    {
        [Required, MinLength(6), MaxLength(16), DataType(DataType.Password)]
        public string NowPassword { get; set; }
        [Required, MinLength(6), MaxLength(16), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MinLength(3), MaxLength(16), Compare("Password", ErrorMessage = "Password dont match")]
        public string RePassword { get; set; }
    }
}