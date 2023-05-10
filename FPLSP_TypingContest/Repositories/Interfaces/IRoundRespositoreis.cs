using FPLSP_TypingContest.Server.BLL.ViewModel.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.Round;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IRoundRespositoreis
    {
        public Task<List<RoundVM>> GetAllAsync();
        public Task<List<RoundVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<RoundVM> GetByIdAsync(Guid id);
        public Task<List<RoundVM>> GetByIdContestAsync(string id);
        public Task<bool> AddAsync(RoundCreateVM request);
        public Task<bool> UpdateAsync(Guid id, RoundUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy);
    }
}
