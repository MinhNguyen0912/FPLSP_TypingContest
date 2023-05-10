using FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IContentForRoundRepositories
    {
        public Task<List<ContentForRoundVM>> GetAllAsync();
        public Task<List<ContentForRoundVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ContentForRoundVM> GetByIdAsync(Guid idContentForRound);
        public Task<bool> AddAsync(ContentForRoundCreateVM request);
        public Task<bool> UpdateAsync(Guid idContentForRound, ContentForRoundUpdateVM request);
        public Task<bool> RemoveAsync(Guid idContentForRound, Guid idUser);
    }
}
