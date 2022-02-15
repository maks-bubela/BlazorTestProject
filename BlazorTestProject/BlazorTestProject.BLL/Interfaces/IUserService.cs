using System.Threading.Tasks;
using BlazorTestProject.BLL.DTO;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsBlockUser(long id);
        Task<bool> UserChangePass(UserChangePasswordDTO dto, long userId);
    }
}