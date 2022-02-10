using System.Threading.Tasks;
using BlazorTestProject.BLL.Enums;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<int> GetTokenSettingsAsync(EnvirementTypes type);
    }
}
