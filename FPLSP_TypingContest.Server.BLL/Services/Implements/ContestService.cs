using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
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
    public class ContestService : IContestService
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContestService(IMapper mapper)
        {
            _dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(ContestCreateVM request)
        {
            try
            {


                var obj = new Contest()
                {
                    CreatedDate = DateTime.Now,
                    Status = 0,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    ImageUrl = request.ImageUrl,
                    Description = request.Description,
                    IdOrganizer = request.IdOrganizer,
                    Id = Guid.NewGuid(),
                    CreatedBy = request.CreateBy,
                    Name = request.Name
                    // Value của Property lấy từ object request
                    //CreatedBy = request.CreatedBy, ...    
                };

                await _dbContext.Contests.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ContestVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.Contests.Include(p => p.Organizer).ProjectTo<ContestVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<ContestVM>> GetAllAsync()
        {
            var list = await _dbContext.Contests.Include(p => p.Organizer).ProjectTo<ContestVM>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }

        public async Task<ContestVM> GetByIdAsync(Guid id)
        {
            var obj = await _dbContext.Contests.AsQueryable().Include(p => p.Organizer).FirstOrDefaultAsync(c => c.Id == id);
            var objVM = _mapper.Map<ContestVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid id, Guid IdDeleteBy)
        {
            var contest = _dbContext.Contests.FirstOrDefault(p => p.Id == id);

                try
                {
                    // Status xóa: mặc định = 1
                    contest.Status = 1;
                    contest.DeletedDate = DateTime.Now;
                    contest.DeletedBy = IdDeleteBy;
                    _dbContext.Contests.Update(contest);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }            
          
        }

        public async Task<bool> UpdateAsync(Guid id, ContestUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.Contests.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);
                if (objForUpdate != null)
                {
                    objForUpdate.Status = request.Status;
                    objForUpdate.StartTime = request.StartTime;
                    objForUpdate.IdOrganizer = request.IdOrganizer;
                    objForUpdate.EndTime = request.EndTime;
                    objForUpdate.Description = request.Description;
                    objForUpdate.ModifiedDate =DateTime.Now;
                    objForUpdate.ImageUrl = request.ImageUrl;
                    objForUpdate.Name = request.Name;
                    objForUpdate.ModifiedBy = request.ModifiedBy;
                    // Property cần update
                    //objForUpdate.Status = request.Status;

                    _dbContext.Contests.Attach(objForUpdate);
                    await Task.FromResult<Contest>(_dbContext.Contests.Update(objForUpdate).Entity);
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
