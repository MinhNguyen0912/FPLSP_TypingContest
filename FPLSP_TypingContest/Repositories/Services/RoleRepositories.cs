using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Role;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.Entities;
using System.Net.Http;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class RoleRepositories : IRoleRepositories
    {
        private readonly HttpClient _httpClient;
        public RoleRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(RoleCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/Role", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<RoleVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<RoleVM>>("api/Role/allactive");
        }

        public async Task<List<RoleVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<RoleVM>>("api/Role/all");
        }

        public async Task<RoleVM> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<RoleVM>($"api/Role/{id}");
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUserdelete)
        {
            var resutl = await _httpClient.DeleteAsync($"api/Role/{id}/{idUserdelete}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, RoleUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/Role/{id}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
