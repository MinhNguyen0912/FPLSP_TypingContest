using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class ScoreOfParticipantRepositories : IScoreOfParticipantRepositories
    {
        private readonly HttpClient _httpClient;
        public ScoreOfParticipantRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(ScoreOfParticipantCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/ScoreOfParticipants", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<ScoreOfParticipantVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ScoreOfParticipantVM>>("api/ScoreOfParticipants/allactive");
        }

        public async Task<List<ScoreOfParticipantVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ScoreOfParticipantVM>>("api/ScoreOfParticipants/all");
        }

        public async Task<ScoreOfParticipantVM> GetByIdAsync(Guid idScoreOfParticipant)
        {
            return await _httpClient.GetFromJsonAsync<ScoreOfParticipantVM>($"api/ScoreOfParticipants/{idScoreOfParticipant}");
        }

        public async Task<bool> RemoveAsync(Guid idScoreOfParticipant, Guid idUser)
        {
            var resutl = await _httpClient.DeleteAsync($"api/ScoreOfParticipants/{idScoreOfParticipant}/{idUser}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid idScoreOfParticipant, ScoreOfParticipantUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/ScoreOfParticipants/{idScoreOfParticipant}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
