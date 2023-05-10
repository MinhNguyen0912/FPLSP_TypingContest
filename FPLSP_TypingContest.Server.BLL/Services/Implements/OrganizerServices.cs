using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class OrganizerServices : IOrganizerServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrganizerServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<bool> AddAsync(OrganizerCreateVM request)
        {
            try
            {
                // Tạo một đối tượng Organizer mới và thiết lập các thuộc tính

                var obj = new Organizer()
                {
                    Id = request.Id,
                    CreatedDate = DateTime.Now,
                    Email = request.Email,
                    IdTrainingFacility = request.IdFacility,
                    CreatedBy = request.CreateBy
                    
                };

                // Thêm đối tượng Organizer mới vào database context và lưu thay đổi vào database
                await _dbContext.Organizers.AddAsync(obj);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<OrganizerVM>> GetAllActiveAsync()
        {
            var organizersVMs = await _dbContext.Organizers
            .Include(o => o.TrainingFacility)
            .Where(o => o.Status != 1)
            .ProjectTo<OrganizerVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return organizersVMs;
        }

        public async Task<List<OrganizerVM>> GetAllAsync()
        {
            var organizersVMs = await _dbContext.Organizers
            .Include(o => o.TrainingFacility)
            .ProjectTo<OrganizerVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return organizersVMs;
        }

        public async Task<OrganizerVM> GetByIdAsync(Guid id)
        {
            var organizer = await _dbContext.Organizers
            .Include(o => o.TrainingFacility)
            .FirstOrDefaultAsync(o => o.Id == id);
            var organizerVM = _mapper.Map<OrganizerVM>(organizer);
            return organizerVM;
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUser)
        {
            try
            {
                // Status xóa: mặc định = 1
                var listObj = await _dbContext.Organizers.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);

                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                obj.DeletedBy = idUser;

                _dbContext.Organizers.Attach(obj);
                await Task.FromResult<Organizer>(_dbContext.Organizers.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Guid id, OrganizerUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.Organizers.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                // Property cần update
                objForUpdate.Status = request.Status;
                objForUpdate.ModifiedDate = DateTime.Now;
                objForUpdate.IdTrainingFacility = request.IdFacility;
                objForUpdate.ModifiedBy = request.ModifiedBy;

                _dbContext.Organizers.Attach(objForUpdate);
                await Task.FromResult<Organizer>(_dbContext.Organizers.Update(objForUpdate).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
