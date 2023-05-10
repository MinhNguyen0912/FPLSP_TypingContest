using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant;
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
    public class ScoreOfParticipantServices : IScoreOfParticipantServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public ScoreOfParticipantServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(ScoreOfParticipantCreateVM request)
        {
            try
            {
                var obj = new ScoreOfParticipant();

                // Add Foreign key
                obj.IdParticipant = request.IdParticipant;
                obj.IdContentForRound = request.IdContentForRound;

                // Add property
                obj.Accuracy = request.Accuracy;
                obj.Speed = request.Speed;

                // Base Create
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = request.CreatedBy;


                await _dbContext.ScoreOfParticipants.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ScoreOfParticipantVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.ScoreOfParticipants.ProjectTo<ScoreOfParticipantVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<ScoreOfParticipantVM>> GetAllAsync()
        {
            var list = await _dbContext.ScoreOfParticipants.ProjectTo<ScoreOfParticipantVM>(_mapper.ConfigurationProvider).ToListAsync();

            return list;
        }

        public async Task<ScoreOfParticipantVM> GetByIdAsync(Guid idScoreOfParticipant)
        {
            var obj = await _dbContext.ScoreOfParticipants.AsQueryable().SingleOrDefaultAsync(c => c.Id == idScoreOfParticipant);
            var objVM = _mapper.Map<ScoreOfParticipantVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid idScoreOfParticipant, Guid idUser)
        {
            try
            {
                // Status xóa: mặc định = 1
                var obj = await _dbContext.ScoreOfParticipants.FirstOrDefaultAsync(c => c.Id == idScoreOfParticipant);
                if (obj == null) return false;

                // Base Delete
                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                obj.DeletedBy = idUser;

                _dbContext.ScoreOfParticipants.Attach(obj);
                await Task.FromResult<ScoreOfParticipant>(_dbContext.ScoreOfParticipants.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid idScoreOfParticipant, ScoreOfParticipantUpdateVM request)
        {
            try
            {
                var obj = await _dbContext.ScoreOfParticipants.FirstOrDefaultAsync(c => c.Id == idScoreOfParticipant);
                if (obj == null) return false;

                // Update Foreign Key
                obj.IdParticipant = request.IdParticipant;
                obj.IdContentForRound = request.IdContentForRound;

                // Update Property
                obj.Accuracy = request.Accuracy;
                obj.Speed = request.Speed;

                // Base Update
                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedBy = request.ModifiedBy;


                _dbContext.ScoreOfParticipants.Attach(obj);
                await Task.FromResult<ScoreOfParticipant>(_dbContext.ScoreOfParticipants.Update(obj).Entity);
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
