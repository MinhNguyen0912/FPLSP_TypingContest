using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.BLL.ViewModels.User;
using FPLSP_TypingContest.Server.DAL.Entities;
using System.Net.Http.Json;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class UserRepositories : IUserRepositories
    {
        private readonly HttpClient _httpClient;
        public UserRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddAsync(UserCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/User", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<UserVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserVM>>("api/User/allactive");
        }

        public async Task<List<UserVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserVM>>("api/User/all");
        }

        public async Task<UserVM> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<UserVM>($"api/User/{id}");
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUserdelete)
        {
            var resutl = await _httpClient.DeleteAsync($"api/User/{id}/{idUserdelete}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, UserUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/User/{id}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
