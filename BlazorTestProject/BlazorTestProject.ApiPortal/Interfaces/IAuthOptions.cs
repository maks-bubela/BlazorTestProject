using BlazorTestProject.BLL.DTO;

namespace BlazorTestProject.ApiPortal.Interfaces
{
    public interface IAuthOptions
    {
        string GetSymmetricSecurityKey(TokenSettingsDTO settingsDto);
    }
}
