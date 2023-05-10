using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
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
    public class LevelServices : ILevelServices
    {
        private readonly FPLSP_TypingContestDbContext _context;
        private readonly IMapper _mapper;
        
        public LevelServices(IMapper mapper)
        {
            _context = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(LevelCreateVM request)
        {
            try
            {
                var level = new Level()
                {
                    Id = new Guid(),
                    Name = request.Name,
                    Description = request.Description,
                    CreatedDate = DateTime.Now,
                    CreatedBy = request.CreatedBy,
                    Status = 0
                };
                await _context.Levels.AddAsync(level);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<List<LevelVM>> GetAllActiveAsync()
        {
            var list = await _context.Levels.ProjectTo<LevelVM>(_mapper.ConfigurationProvider).Where(p=>p.Status!=1).ToListAsync();
            return list;
        }

        public async Task<List<LevelVM>> GetAllAsync()
        {
            var list = await _context.Levels.ProjectTo<LevelVM>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }

        public async Task<LevelVM> GetByIdAsync(Guid levelId)
        {
            var obj = _context.Levels.FirstOrDefault(p=>p.Id == levelId);
            var objVM = _mapper.Map<LevelVM>(obj);
            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid levelId, Guid DeleteBy)
        {
            var level = _context.Levels.FirstOrDefault(p=>p.Id==levelId);
            if (level != null)
            {
                level.Status = 1;
                level.DeletedDate = DateTime.Now;
                level.DeletedBy = DeleteBy;
                _context.Levels.Update(level);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        public async Task<bool> UpdateAsync(Guid levelId, LevelUpdateVM request)
        {
            var level = _context.Levels.FirstOrDefault(p => p.Id == levelId);
            if (level != null)
            {
                level.ModifiedDate = DateTime.Now;
                level.Name = request.Name;
                level.Description = request.Description;
                level.ModifiedBy = request.ModifiedBy;
                _context.Levels.Update(level);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
