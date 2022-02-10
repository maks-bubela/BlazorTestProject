﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestProject.Interfaces;

namespace BlazorTestProject.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly HttpClient _httpClient;
        #region Const
        private const string UserBlockStatus = "api/user/blockstatus";
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
    }
}