using FPLSP_TypingContest.Server.BLL.ViewModel.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.BLL.ViewModels.Round;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IRoundService
    {
        public Task<List<RoundVM>> GetAllAsync();
        public Task<List<RoundVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<RoundVM> GetByIdAsync(Guid id);
        public Task<List<RoundVM>> GetByIdContestAsync(string id);
        public Task<bool> AddAsync(RoundCreateVM request);
        public Task<bool> UpdateAsync(Guid id, RoundUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy);
    }
}
