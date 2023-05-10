using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface ITextTemplateServices
    {
        public Task<List<TextTemplateVM>> GetAllAsync();
        public Task<List<TextTemplateVM>> GetAllByLevelIdAsync(Guid LevelId);
        public Task<List<TextTemplateVM>> GetAllActiveAsync();
        public Task<TextTemplateVM> GetByIdAsync(Guid TextTemplateId);
        public Task<bool> AddAsync(TextTemplateCreateVM request);
        public Task<bool> UpdateAsync(Guid TextTemplateId, TextTemplateUpdateVM request);
        public Task<bool> RemoveAsync(Guid TextTemplateId, Guid DeleteBy);
    }
}
