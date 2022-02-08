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
        public async Task<List<UserModel>> GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserModel>>("api/admin/get/users");
            if (result == null)
                throw new ArgumentNullException(nameof(List<UserModel>));
            return result;
        }
    }
}