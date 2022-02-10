using System.ComponentModel.DataAnnotations;

namespace BlazorTestProject.Models.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Username is required field"), MinLength(4), MaxLength(16)]
        public string Username { get; set; }
        [Required, MinLength(6), MaxLength(16), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, MinLength(3), MaxLength(16),Compare("Password", ErrorMessage = "Password dont match")]
        public string RePassword { get; set; }
        [Required, MinLength(3), MaxLength(16)]
        public string Firstname { get; set; }
        [Required, MinLength(3), MaxLength(16)]
        public string Lastname { get; set; }
    }
}
