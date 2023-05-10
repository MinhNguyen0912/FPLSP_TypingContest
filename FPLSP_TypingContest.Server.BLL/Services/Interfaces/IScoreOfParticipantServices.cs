using FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IScoreOfParticipantServices
    {
        public Task<List<ScoreOfParticipantVM>> GetAllAsync();
        public Task<List<ScoreOfParticipantVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ScoreOfParticipantVM> GetByIdAsync(Guid idScoreOfParticipant);
        public Task<bool> AddAsync(ScoreOfParticipantCreateVM request);
        public Task<bool> UpdateAsync(Guid idScoreOfParticipant, ScoreOfParticipantUpdateVM request);
        public Task<bool> RemoveAsync(Guid idScoreOfParticipant, Guid idUser);
    }
}
