using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface ITrainingFacilitysRepositories
    {
        public Task<List<TrainingFacilityVM>> GetAllAsync();
        public Task<List<TrainingFacilityVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<TrainingFacilityVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(TrainingFacilityCreateVM request);
        public Task<bool> UpdateAsync(Guid idFaci, TrainingFacilityUpdateVM request);
        public Task<bool> RemoveAsync(Guid idFaci, Guid idUser);

    }
}
