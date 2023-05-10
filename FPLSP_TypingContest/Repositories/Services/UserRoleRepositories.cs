using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.BLL.ViewModels.UserRole;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class UserRoleRepositories : IUserRoleRepositories
    {
        private readonly HttpClient _httpClient;
        public UserRoleRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(UserRoleCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/UserRole", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<UserRoleVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserRoleVM>>("api/UserRole/allactive");
        }

        public async Task<List<UserRoleVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UserRoleVM>>("api/UserRole/all");
        }

        public async Task<UserRoleVM> GetByIdAsync(Guid RoleId, Guid UserId)
        {
            return await _httpClient.GetFromJsonAsync<UserRoleVM>($"api/UserRole/{RoleId}/{UserId}");
        }

        public async Task<bool> RemoveAsync(Guid RoleId, Guid UserId, Guid idUserdelete)
        {
            var resutl = await _httpClient.DeleteAsync($"api/UserRole/{RoleId}/{UserId}/{idUserdelete}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid RoleId, Guid UserId, UserRoleUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/UserRole/{RoleId}/{UserId}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
