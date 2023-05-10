using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IContestService
    {
        public Task<List<ContestVM>> GetAllAsync();
        public Task<List<ContestVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ContestVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(ContestCreateVM request);
        public Task<bool> UpdateAsync(Guid id, ContestUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy);
    }
}
