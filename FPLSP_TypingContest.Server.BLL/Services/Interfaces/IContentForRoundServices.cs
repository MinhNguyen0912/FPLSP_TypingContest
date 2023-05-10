using FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IContentForRoundServices
    {
        public Task<List<ContentForRoundVM>> GetAllAsync();
        public Task<List<ContentForRoundVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<ContentForRoundVM> GetByIdAsync(Guid idContentForRound);
        public Task<bool> AddAsync(ContentForRoundCreateVM request);
        public Task<bool> UpdateAsync(Guid idContentForRound, ContentForRoundUpdateVM request);
        public Task<bool> RemoveAsync(Guid idContentForRound, Guid idUser);
    }
}
