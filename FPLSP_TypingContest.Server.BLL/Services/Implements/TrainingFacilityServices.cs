using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class TrainingFacilityServices : ITrainingFacilityServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;

        public TrainingFacilityServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<bool> AddAsync(TrainingFacilityCreateVM request)
        {
            try
            {
                var obj = new TrainingFacility()
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = request.CreateBy,
                    Name = request.Name,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                    // Value của Property lấy từ object request
                    //CreatedBy = request.CreatedBy, ...    
                };

                await _dbContext.TrainingFacilities.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<TrainingFacilityVM>> GetAllActiveAsync()
        {
            var traningFacilities = await _dbContext.TrainingFacilities
            .Where(o => o.Status != 1)
            .ProjectTo<TrainingFacilityVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return traningFacilities;
        }
        public async Task<List<TrainingFacilityVM>> GetAllAsync()
        {
            var list = await _dbContext.TrainingFacilities
            .ProjectTo<TrainingFacilityVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return list;
        }

        public async Task<TrainingFacilityVM> GetByIdAsync(Guid id)
        {
            var obj = await _dbContext.TrainingFacilities.AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
            var objVM = _mapper.Map<TrainingFacilityVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid idFaci, Guid idUser)
        {
            try
            {
                var listObj = await _dbContext.TrainingFacilities.ToListAsync();

                var objForUpdate = listObj.FirstOrDefault(c => c.Id == idFaci);

                if (objForUpdate == null)
                {
                    return false;
                }

                objForUpdate.Status = 1;
                objForUpdate.DeletedDate = DateTime.Now;
                objForUpdate.DeletedBy = idUser;
                _dbContext.TrainingFacilities.Attach(objForUpdate);

                await Task.FromResult<TrainingFacility>(_dbContext.TrainingFacilities.Update(objForUpdate).Entity);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Guid idFaci, TrainingFacilityUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.TrainingFacilities.ToListAsync();

                var objForUpdate = listObj.FirstOrDefault(c => c.Id == idFaci);

                if (objForUpdate == null)
                {
                    return false;
                }

                objForUpdate.Name = request.Name;
                objForUpdate.Email = request.Email;
                objForUpdate.Address = request.Address;
                objForUpdate.PhoneNumber = request.PhoneNumber;
                objForUpdate.Status = request.Status;
                objForUpdate.ModifiedDate = DateTime.Now;
                objForUpdate.ModifiedBy = request.ModifiedBy;
                _dbContext.TrainingFacilities.Attach(objForUpdate);

                await Task.FromResult<TrainingFacility>(_dbContext.TrainingFacilities.Update(objForUpdate).Entity);

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
