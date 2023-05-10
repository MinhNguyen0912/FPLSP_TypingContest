using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Participant;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class ParticipantsRepositories : IParticipantsRepositories
    {
        private readonly HttpClient _httpClient;
        public ParticipantsRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(ParticipantCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/Participants", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<ParticipantVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ParticipantVM>>("api/Participants/allactive");
        }

        public async Task<List<ParticipantVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ParticipantVM>>("api/Participants/all");
        }

        public async Task<ParticipantVM> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ParticipantVM>($"api/Participants/{id}");
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUser)
        {
            var resutl = await _httpClient.DeleteAsync($"api/Participants/{id}/{idUser}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, ParticipantUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/Participants/{id}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
