using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class OrganizersRepositories : IOrganizersRepositories
    {
        private readonly HttpClient _httpClient;
        public OrganizersRepositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(OrganizerCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/Organizers", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<OrganizerVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrganizerVM>>("api/Organizers/allactive");
        }

        public async Task<List<OrganizerVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrganizerVM>>("api/Organizers/all");
        }

        public async Task<OrganizerVM> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<OrganizerVM>($"api/Organizers/{id}");
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUser)
        {
            var resutl = await _httpClient.DeleteAsync($"api/Organizers/{id}/{idUser}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid id, OrganizerUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/Organizers/{id}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
