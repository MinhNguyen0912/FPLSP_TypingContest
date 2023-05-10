using FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface ITextTemplateRespositories
    {
        public Task<List<TextTemplateVM>> GetAllAsync();
        public Task<List<TextTemplateVM>> GetAllByLevelIdAsync(Guid LevelId);
        public Task<List<TextTemplateVM>> GetAllActiveAsync();
        public Task<TextTemplateVM> GetByIdAsync(Guid TextTemplateId);
        public Task<bool> AddAsync(TextTemplateCreateVM request);
        public Task<bool> UpdateAsync(Guid TextTemplateId, TextTemplateUpdateVM request);
        public Task<bool> RemoveAsync(Guid TextTemplateId, Guid DeleteBy);
    }
}
