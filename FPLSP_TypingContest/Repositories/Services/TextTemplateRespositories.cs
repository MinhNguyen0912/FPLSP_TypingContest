using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class TextTemplateRespositories : ITextTemplateRespositories
    {
        private readonly HttpClient _httpClient;
        public TextTemplateRespositories(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAsync(TextTemplateCreateVM request)
        {
            var resutl = await _httpClient.PostAsJsonAsync("api/TextTemplate", request);
            return resutl.IsSuccessStatusCode;
        }

        public async Task<List<TextTemplateVM>> GetAllActiveAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TextTemplateVM>>("api/TextTemplate/allactive");
        }

        public async Task<List<TextTemplateVM>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TextTemplateVM>>("api/TextTemplate/all");
        }

        public async Task<List<TextTemplateVM>> GetAllByLevelIdAsync(Guid LevelId)
        {
            return await _httpClient.GetFromJsonAsync<List<TextTemplateVM>>($"api/TextTemplate/alloflevel/{LevelId}");
        }

        public async Task<TextTemplateVM> GetByIdAsync(Guid TextTemplateId)
        {
            return await _httpClient.GetFromJsonAsync<TextTemplateVM>($"api/TextTemplate/getbyid/{TextTemplateId}");
        }

        public async Task<bool> RemoveAsync(Guid TextTemplateId, Guid DeleteBy)
        {
            var resutl = await _httpClient.DeleteAsync($"api/TextTemplate/delete/{TextTemplateId}/{DeleteBy}");
            return resutl.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Guid TextTemplateId, TextTemplateUpdateVM request)
        {
            var resutl = await _httpClient.PutAsJsonAsync($"api/TextTemplate/update/{TextTemplateId}", request);
            return resutl.IsSuccessStatusCode;
        }
    }
}
