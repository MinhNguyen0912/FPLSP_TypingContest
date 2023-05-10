using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModel.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.BLL.ViewModels.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class RoundService : IRoundService
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public RoundService(IMapper mapper)
        {
            _dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(RoundCreateVM request)
        {
            try
            {

                var obj = new Round()
                {
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StartTime = request.StartTime.Value,
                    EndTime = request.EndTime.Value,
                    ImageUrl = request.ImageUrl,
                    Description = request.Description,
                    IdContest = request.IdContest,
                    Id = Guid.NewGuid(),
                    CreatedBy = request.CreatedBy,
                    Name = request.Name,
                    IsDisableBackspace = request.IsDisableBackspace,
                    IsHavingSpecialChar = request.IsHavingSpecialChar,
                    TotalTime = request.TotalTime.Value,
                    MaxAccess = request.MaxAccess,
                    Availability = request.availability,
                    IsFinal = request.IsFinal
                    // Value của Property lấy từ object request
                    //CreatedBy = request.CreatedBy, ...    
                };

                await _dbContext.Rounds.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoundVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.Rounds.Include(p => p.Contest).ProjectTo<RoundVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<RoundVM>> GetAllAsync()
        {
            var list = await _dbContext.Rounds.Include(p => p.Contest).ProjectTo<RoundVM>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }

        public async Task<RoundVM> GetByIdAsync(Guid id)
        {
            var obj = await _dbContext.Rounds.AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
            var objVM = _mapper.Map<RoundVM>(obj);

            return objVM;
        }

        public async Task<List<RoundVM>> GetByIdContestAsync(string id)
        {
            var list = await _dbContext.Rounds.Include(p => p.Contest).ProjectTo<RoundVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1 && c.IdContest == Guid.Parse(id)).OrderBy(c=>c.StartTime).ToListAsync();

            return list;
        }

        public async Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy)
        {
            try
            {
                // Status xóa: mặc định = 1
                var listObj = await _dbContext.Rounds.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);

                    obj.Status = 1;
                    obj.DeletedDate = DateTime.Now;
                    obj.DeletedBy = IdDeleteBy;
                    _dbContext.Rounds.Attach(obj);
                    await Task.FromResult<Round>(_dbContext.Rounds.Update(obj).Entity);
                    await _dbContext.SaveChangesAsync();
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Guid id, RoundUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.Rounds.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);
                if (objForUpdate != null)
                {
                    objForUpdate.Status = request.Status;
                    objForUpdate.StartTime = request.StartTime;
                    objForUpdate.IdContest = request.IdContest;
                    objForUpdate.EndTime = request.EndTime;
                    objForUpdate.Description = request.Description;
                    objForUpdate.ModifiedDate = DateTime.Now;
                    objForUpdate.ImageUrl = request.ImageUrl;
                    objForUpdate.Name = request.Name;
                    objForUpdate.ModifiedBy = request.ModifiedBy;
                    objForUpdate.IsHavingSpecialChar = request.IsHavingSpecialChar;
                    objForUpdate.IsDisableBackspace = request.IsDisableBackspace;
                    objForUpdate.TotalTime = request.TotalTime;
                    objForUpdate.MaxAccess = request.MaxAccess;
                    objForUpdate.Availability = request.availability;
                    objForUpdate.IsFinal = request.IsFinal;
                    // Property cần update
                    //objForUpdate.Status = request.Status;

                    _dbContext.Rounds.Attach(objForUpdate);
                    await Task.FromResult<Round>(_dbContext.Rounds.Update(objForUpdate).Entity);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
