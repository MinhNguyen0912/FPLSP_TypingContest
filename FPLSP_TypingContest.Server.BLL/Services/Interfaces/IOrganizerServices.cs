using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Interfaces
{
    public interface IOrganizerServices
    {
        public Task<List<OrganizerVM>> GetAllAsync();
        public Task<List<OrganizerVM>> GetAllActiveAsync(); // Statucs != 1
        public Task<OrganizerVM> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(OrganizerCreateVM request);
        public Task<bool> UpdateAsync(Guid id,  OrganizerUpdateVM request);
        public Task<bool> RemoveAsync(Guid id, Guid idUser);
    }
}
