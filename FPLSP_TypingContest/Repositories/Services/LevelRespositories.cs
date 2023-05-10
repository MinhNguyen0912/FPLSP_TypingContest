using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.Participant;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class LevelRespositories : ILevelRespositories
    {
        private readonly HttpClient _httpClient;
        public LevelRespositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(LevelCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/Levels", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<LevelVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LevelVM>>("api/Levels/allactive");
        }

        public async Task<List<LevelVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LevelVM>>("api/Levels/all");
        }

        public async Task<LevelVM> GetByIdAsync(Guid levelId)
        {
            return await _httpClient.GetFromJsonAsync<LevelVM>($"api/Levels/getbyid/{levelId}");
        }

        public async Task<bool> RemoveAsync(Guid levelId, Guid DeleteBy)
        {
            var resutl = await _httpClient.DeleteAsync($"api/Levels/delete/{levelId}/{DeleteBy}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid levelId, LevelUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/Levels/update/{levelId}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
