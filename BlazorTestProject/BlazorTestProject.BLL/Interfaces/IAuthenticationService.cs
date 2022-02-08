
using BlazorTestProject.BLL.DTO;
using System.Threading.Tasks;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<long> RegisterUserAsync(UserDTO dto);
        Task<long> VerifyCredentialsAsync(string username, string password);
        Task<UserIdentityDTO> GetUserIdentityById(long id);
    }
}
