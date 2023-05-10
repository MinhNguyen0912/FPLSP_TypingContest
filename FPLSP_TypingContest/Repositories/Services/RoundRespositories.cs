using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModel.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.Round;
using System.Text.Json;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class RoundRespositories : IRoundRespositoreis
    {
        private readonly HttpClient _httpClient;
        public RoundRespositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddAsync(RoundCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/Rounds/Add", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<RoundVM>> GetAllActiveAsync()
        {
            var resutl = await _httpClient.GetFromJsonAsync<List<RoundVM>>("api/Rounds/allactive");
            if(resutl !=null) return resutl;
            return new List<RoundVM>();
        }

        public async Task<List<RoundVM>> GetAllAsync()
        {
            var resutl = await _httpClient.GetFromJsonAsync<List<RoundVM>>("api/Rounds/All");
            if (resutl != null) return resutl;
            return new List<RoundVM>();
        }

        public async Task<RoundVM> GetByIdAsync(Guid id)
        {
            var resutl = await _httpClient.GetFromJsonAsync<RoundVM>($"api/Rounds/{id}");
            if (resutl != null) return resutl;
            throw new InvalidOperationException("Contest not found for the given ID.");
        }



        public async Task<List<RoundVM>> GetByIdContestAsync(string idContest)
        {
            var resutl = await _httpClient.GetFromJsonAsync<List<RoundVM>>($"api/Rounds/GetByContest/{idContest}");
            if (resutl != null) return resutl;
            throw new InvalidOperationException("Contest not found for the given ID.");
        }

        public async Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy)
        {
            var resutl = await _httpClient.DeleteAsync($"api/Rounds/Delete/{id}/{IdDeleteBy}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, RoundUpdateVM request)
        {
            var reult = await _httpClient.PutAsJsonAsync($"api/Rounds/Update/{id}", request);
            return reult.IsSuccessStatusCode;
        }
    }
}
