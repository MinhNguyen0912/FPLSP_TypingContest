using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IRatingOfRoundServices
    {
        public Task<List<RatingOfRoundVM>> GetAllAsync();
        public Task<List<RatingOfRoundVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<RatingOfRoundVM> GetByIdAsync(Guid idParticipant);
        public Task<bool> AddAsync(RatingOfRoundCreateVM request);
        public Task<bool> UpdateAsync(Guid idParticipant, RatingOfRoundUpdateVM request);
        public Task<bool> RemoveAsync(Guid idParticipant);

    }
}
