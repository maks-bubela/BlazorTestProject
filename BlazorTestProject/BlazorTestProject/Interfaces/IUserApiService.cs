using System.Threading.Tasks;

namespace BlazorTestProject.Interfaces
{
    public interface IUserApiService
    {
        Task<bool> IsUserBlocked();
    }
}