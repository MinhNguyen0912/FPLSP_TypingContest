using FPLSP_TypingContest.Server.BLL.ViewModels.UserIdentityVM;

namespace FPLSP_TypingContest.Repositories.Interfaces
{
    public interface IUserIdentityRespositories
    {
        public Task<List<UserIdentityVM>> GetUsersIdentityAsync();
        public Task<UserIdentityVM> GetUserByIdIdentityAsync(string Id);
        //public Task<bool> CreateUserIdentityAsync(UserIdentityVM userIdentityVM);
        public Task<bool> UpdateUserIdentityAsync(UserIdentityVM userIdentityVM);
    }
}
