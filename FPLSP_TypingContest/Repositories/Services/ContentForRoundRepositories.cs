using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class ContentForRoundRepositories : IContentForRoundRepositories
    {
        private readonly HttpClient _httpClient;
        public ContentForRoundRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(ContentForRoundCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/ContentForRounds", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<ContentForRoundVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ContentForRoundVM>>("api/ContentForRounds/allactive");
        }

        public async Task<List<ContentForRoundVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ContentForRoundVM>>("api/ContentForRounds/all");
        }

        public async Task<ContentForRoundVM> GetByIdAsync(Guid idContentForRound)
        {
            return await _httpClient.GetFromJsonAsync<ContentForRoundVM>($"api/ContentForRounds/{idContentForRound}");
        }

        public async Task<bool> RemoveAsync(Guid idContentForRound, Guid idUser)
        {
            var resutl = await _httpClient.DeleteAsync($"api/ContentForRounds/{idContentForRound}/{idUser}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid idContentForRound, ContentForRoundUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/ContentForRounds/{idContentForRound}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
