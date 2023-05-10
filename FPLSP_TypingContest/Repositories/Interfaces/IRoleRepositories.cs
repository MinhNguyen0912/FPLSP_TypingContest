using FPLSP_TypingContest.Server.BLL.ViewModels.Role;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IRoleRepositories
    {
        public Task<List<RoleVM>> GetAllAsync();
        public Task<List<RoleVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<RoleVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(RoleCreateVM request);
        public Task<bool> UpdateAsync(Guid id, RoleUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUserdelete);
    }
}
