using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IContestRespositories
    {
        public Task<List<ContestVM>> GetAllAsync();
        public Task<List<ContestVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ContestVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(ContestCreateVM request);
        public Task<bool> UpdateAsync(Guid id, ContestUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy);
    }
}
