using System.Threading.Tasks;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsBlockUser(long id);
    }
}