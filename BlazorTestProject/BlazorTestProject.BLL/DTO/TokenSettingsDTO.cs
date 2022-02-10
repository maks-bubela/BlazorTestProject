using System.Security.Claims;

namespace BlazorTestProject.BLL.DTO
{
    public class TokenSettingsDTO
    {
        public ClaimsIdentity Identity { get; set; }
        public int LifeTime { get; set; }
    }
}