using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class ContestRespositories : IContestRespositories
    {
        private readonly HttpClient _httpClient;
        public ContestRespositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(ContestCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/Contest/Add", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<ContestVM>> GetAllActiveAsync()
        {
            var list = await _httpClient.GetFromJsonAsync<List<ContestVM>>("api/Contest/allactive");
            if (list != null) return list;
            return new List<ContestVM>();
        }

        public async Task<List<ContestVM>> GetAllAsync()
        {
            var list = await _httpClient.GetFromJsonAsync<List<ContestVM>>("api/Contest/All");
            if (list != null) return list;
            return new List<ContestVM>();
        }

        public async Task<ContestVM> GetByIdAsync(Guid id)
        {
            var list = await _httpClient.GetFromJsonAsync<ContestVM>($"api/Contest/{id}");
            if(list !=null)
            return list;
            throw new InvalidOperationException("Contest not found for the given ID.");
        }

        public async Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy)
        {
            var resutl = await _httpClient.DeleteAsync($"api/Contest/Delete/{id}/{IdDeleteBy}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, ContestUpdateVM request)
        {
            var reult = await _httpClient.PutAsJsonAsync($"api/Contest/Update/{id}",request);
            return reult.IsSuccessStatusCode;
        }
    }
}
