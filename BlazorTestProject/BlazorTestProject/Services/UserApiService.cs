using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _httpClient;
        #region Const
        private const string UserBlockStatus = "api/user/block/status";
        private const string UserChangePass = "api/user/change/password";
        #endregion
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> IsUserBlocked()
        {
            var result = await _httpClient.GetFromJsonAsync<bool>(UserBlockStatus);
            return result;
        }

        public async Task<HttpResponseMessage> ChangePass(ChangePasswordModel model)
        {
            var result = await _httpClient.PutAsJsonAsync(UserChangePass, model);
            return result;
        }
    }
}