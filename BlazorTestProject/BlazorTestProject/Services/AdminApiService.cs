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
        #region Services
        private readonly HttpClient _httpClient;
        #endregion
        #region Const
        private const string GetUsersEndpoint = "api/admin/get/users";
        private const string BlockUserEndpoint = "api/admin/user/block";
        private const string UnblockUserEndpoint = "api/admin/user/unblock";
        private const string SoftDeleteUserEndpoint = "api/admin/user/soft/delete";
        private const string RoleChangeUserEndpoint = "api/admin/user/role/change";
        #endregion
        #region Constructor
        public AdminApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        #region GetMethods
        public async Task<List<UserInfoModel>> GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserInfoModel>>(GetUsersEndpoint);
            if (result == null)
                throw new ArgumentNullException(nameof(List<UserInfoModel>));
            return result;
        }
        #endregion
        #region Block/Unblock
        public async Task<HttpResponseMessage> BlockUser( long userId)
        {
            var result = await _httpClient.PutAsJsonAsync(BlockUserEndpoint, userId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<HttpResponseMessage> UnBlockUser(long userId)
        {
            var result = await _httpClient.PutAsJsonAsync(UnblockUserEndpoint, userId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }
        #endregion
        #region SoftDelete
        public async Task<HttpResponseMessage> SoftDeleteUser(long userId)
        {
            var result = await _httpClient.PutAsJsonAsync(SoftDeleteUserEndpoint, userId);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }
        #endregion
        #region ChangeDataMethods
        public async Task<HttpResponseMessage> ChangeUserRole(long userId, string roleName)
        {
            var changeRoleModel = new UserChangeRoleModel()
            {
                userId = userId,
                roleName = roleName
            };
            var result = await _httpClient.PutAsJsonAsync(RoleChangeUserEndpoint, changeRoleModel);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }
        #endregion
    }
}