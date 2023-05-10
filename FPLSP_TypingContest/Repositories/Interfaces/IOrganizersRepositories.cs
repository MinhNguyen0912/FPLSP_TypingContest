using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IOrganizersRepositories
    {
        public Task<List<OrganizerVM>> GetAllAsync();
        public Task<List<OrganizerVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<OrganizerVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(OrganizerCreateVM request);
        public Task<bool> UpdateAsync(Guid id, OrganizerUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUser);
    }
}
