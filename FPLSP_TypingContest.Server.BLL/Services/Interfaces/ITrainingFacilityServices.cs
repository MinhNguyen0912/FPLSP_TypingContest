using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface ITrainingFacilityServices
    {
        public Task<List<TrainingFacilityVM>> GetAllAsync();
        public Task<List<TrainingFacilityVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<TrainingFacilityVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(TrainingFacilityCreateVM request);
        public Task<bool> UpdateAsync(Guid idFaci, TrainingFacilityUpdateVM request);
        public Task<bool> RemoveAsync(Guid idFaci, Guid idUser);
    }
}
