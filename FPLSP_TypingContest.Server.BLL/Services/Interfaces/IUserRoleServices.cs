
using FPLSP_TypingContest.Server.BLL.ViewModels.UserRole;


namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IUserRoleServices
    {
        public Task<List<UserRoleVM>> GetAllAsync();
        public Task<List<UserRoleVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<List<UserRoleVM>> GetByIdAsync(Guid RoleId, Guid UserId);
        public Task<bool> AddAsync(UserRoleCreateVM request);
        public Task<bool> UpdateAsync(Guid RoleId, Guid UserId, UserRoleUpdateVM request);
        public Task<bool> RemoveAsync(Guid RoleId, Guid UserId, Guid idUserdelete);

    }
}
