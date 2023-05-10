using FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IScoreOfParticipantRepositories
    {
        public Task<List<ScoreOfParticipantVM>> GetAllAsync();
        public Task<List<ScoreOfParticipantVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ScoreOfParticipantVM> GetByIdAsync(Guid idScoreOfParticipant);
        public Task<bool> AddAsync(ScoreOfParticipantCreateVM request);
        public Task<bool> UpdateAsync(Guid idScoreOfParticipant, ScoreOfParticipantUpdateVM request);
        public Task<bool> RemoveAsync(Guid idScoreOfParticipant, Guid idUser);
    }
}
