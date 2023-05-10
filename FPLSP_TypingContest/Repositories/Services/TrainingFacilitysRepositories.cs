using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class TrainingFacilitysRepositories : ITrainingFacilitysRepositories
    {
        private readonly HttpClient _httpClient;
        public TrainingFacilitysRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddAsync(TrainingFacilityCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/TrainingFacilities", request);
            return resutl.IsSuccessStatusCode;
        }
        //Nên check thêm    
        public async Task<List<TrainingFacilityVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TrainingFacilityVM>>("api/TrainingFacilities/allactive");
        }

        public async Task<List<TrainingFacilityVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TrainingFacilityVM>>("api/TrainingFacilities/all");
        }

        public async Task<TrainingFacilityVM> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<TrainingFacilityVM>($"api/TrainingFacilities/{id}");
        }

        public async Task<bool> RemoveAsync(Guid idFaci, Guid idUser)
        {
            var resutl = await _httpClient.DeleteAsync($"api/TrainingFacilities/{idFaci}/{idUser}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid idFaci, TrainingFacilityUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/TrainingFacilities/{idFaci}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
