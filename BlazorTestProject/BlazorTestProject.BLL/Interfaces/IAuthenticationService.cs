
using BlazorTestProject.BLL.DTO;
using System.Threading.Tasks;

namespace BlazorTestProject.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<long> AddNewAzureBlobTypeAsync(UserDTO dto);
    }
}
