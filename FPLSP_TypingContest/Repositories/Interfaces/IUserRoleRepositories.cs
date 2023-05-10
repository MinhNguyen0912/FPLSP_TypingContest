using FPLSP_TypingContest.Server.BLL.ViewModels.UserRole;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IUserRoleRepositories
    {
        public Task<List<UserRoleVM>> GetAllAsync();
        public Task<List<UserRoleVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<UserRoleVM> GetByIdAsync(Guid RoleId, Guid UserId);
        public Task<bool> AddAsync(UserRoleCreateVM request);
        public Task<bool> UpdateAsync(Guid RoleId, Guid UserId, UserRoleUpdateVM request);
        public Task<bool> RemoveAsync(Guid RoleId, Guid UserId, Guid idUserdelete);
    }
}
