using FPLSP_TypingContest.Server.BLL.ViewModels.Participant;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IParticipantsRepositories
    {
        public Task<List<ParticipantVM>> GetAllAsync();
        public Task<List<ParticipantVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ParticipantVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(ParticipantCreateVM request);
        public Task<bool> UpdateAsync(Guid id, ParticipantUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUser);
    }
}
