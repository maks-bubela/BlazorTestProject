using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;
using BlazorTestProject.Models.Models;

namespace BlazorTestProject.Services
{
    public class AdminApiService : IAdminApiService
    {
        private readonly HttpClient _httpClient;
        public AdminApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserInfoModel>> GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserInfoModel>>("api/admin/get/users");
            if (result == null)
                throw new ArgumentNullException(nameof(List<UserInfoModel>));
            return result;
        }

        public async Task<HttpResponseMessage> BlockUser( long userId)
        {
            var result = await _httpClient.PutAsJsonAsync("api/admin/user/block", userId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<HttpResponseMessage> UnBlockUser(long userId)
        {
            var result = await _httpClient.PutAsJsonAsync("api/admin/user/unblock", userId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }
        public async Task<HttpResponseMessage> SoftDeleteUser(long userId)
        {
            var result = await _httpClient.PutAsJsonAsync("api/admin/user/soft/delete", userId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }
        public async Task<HttpResponseMessage> ChangeUserRole(long userId, string roleName)
        {
            var changeRoleModel = new UserChangeRoleModel()
            {
                userId = userId,
                roleName = roleName
            };
            var result = await _httpClient.PutAsJsonAsync("api/admin/user/role/change", changeRoleModel);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }
    }
}