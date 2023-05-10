using FPLSP_TypingContest.Server.BLL.ViewModels.User;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IUserRepositories
    {
        public Task<List<UserVM>> GetAllAsync();
        public Task<List<UserVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<UserVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(UserCreateVM request);
        public Task<bool> UpdateAsync(Guid id, UserUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUserdelete);

    }
}
