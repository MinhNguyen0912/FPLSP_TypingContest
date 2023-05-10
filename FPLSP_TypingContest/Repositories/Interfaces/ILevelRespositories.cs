using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface ILevelRespositories
    {
        public Task<List<LevelVM>> GetAllAsync();
        public Task<List<LevelVM>> GetAllActiveAsync();
        public Task<LevelVM> GetByIdAsync(Guid levelId);
        public Task<bool> AddAsync(LevelCreateVM request);
        public Task<bool> UpdateAsync(Guid levelId, LevelUpdateVM request);
        public Task<bool> RemoveAsync(Guid levelId, Guid DeleteBy);
    }
}
