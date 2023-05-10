using FPLSP_TypingContest.Server.BLL.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IRoleServices
    {
        public Task<List<RoleVM>> GetAllAsync();
        public Task<List<RoleVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<RoleVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(RoleCreateVM request);
        public Task<bool> UpdateAsync(Guid id, RoleUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUserdelete);
    }
}
