using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Services
{
    public class RoleApiService : IRoleApiService
    {
        private readonly HttpClient _httpClient;
        #region Const
        private const string GetRoleEndpoint = "api/role/get/roles";
        #endregion
        public RoleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<RoleNamesModel>> GetRolesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RoleNamesModel>>
                (GetRoleEndpoint);
            return result;
        }
    }
}