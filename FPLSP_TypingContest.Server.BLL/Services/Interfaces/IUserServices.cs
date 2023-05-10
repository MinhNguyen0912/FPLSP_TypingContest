using FPLSP_TypingContest.Server.BLL.ViewModels.User;
using System;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<List<UserVM>> GetAllAsync();
        public Task<List<UserVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<UserVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(UserCreateVM request);
        public Task<bool> UpdateAsync(Guid id, UserUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUserdelete);
    }
}
