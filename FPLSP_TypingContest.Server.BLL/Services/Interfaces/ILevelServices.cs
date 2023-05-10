using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface ILevelServices
    {
        public Task<List<LevelVM>> GetAllAsync();
        public Task<List<LevelVM>> GetAllActiveAsync();
        public Task<LevelVM> GetByIdAsync(Guid levelId);
        public Task<bool> AddAsync(LevelCreateVM request);
        public Task<bool> UpdateAsync(Guid levelId, LevelUpdateVM request);
        public Task<bool> RemoveAsync(Guid levelId, Guid DeleteBy);
    }
}
