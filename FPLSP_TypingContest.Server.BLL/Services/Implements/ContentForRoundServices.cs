using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class ContentForRoundServices : IContentForRoundServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContentForRoundServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(ContentForRoundCreateVM request)
        {
            try
            {
                var obj = new ContentForRound();

                // Add Foreign key
                obj.IdTextTemplate = request.IdTextTemplate;
                obj.IdRound = request.IdRound;

                // Add property
                obj.Content = request.Content;

                // Base Create
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = request.CreatedBy;
                

                await _dbContext.ContentForRounds.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ContentForRoundVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.ContentForRounds.ProjectTo<ContentForRoundVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<ContentForRoundVM>> GetAllAsync()
        {
            var list = await _dbContext.ContentForRounds.ProjectTo<ContentForRoundVM>(_mapper.ConfigurationProvider).ToListAsync();

            return list;
        }

        public async Task<ContentForRoundVM> GetByIdAsync(Guid idContentForRound)
        {
            var obj = await _dbContext.ContentForRounds.AsQueryable().SingleOrDefaultAsync(c => c.Id == idContentForRound);
            var objVM = _mapper.Map<ContentForRoundVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid idContentForRound, Guid idUser)
        {
            try
            {
                // Status xóa: mặc định = 1
                var obj = await _dbContext.ContentForRounds.FirstOrDefaultAsync(c => c.Id == idContentForRound);
                if (obj == null) return false;

                // Base Delete
                obj.Status = 1;
                obj.DeletedDate= DateTime.Now;
                obj.DeletedBy = idUser;

                _dbContext.ContentForRounds.Attach(obj);
                await Task.FromResult<ContentForRound>(_dbContext.ContentForRounds.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid idContentForRound, ContentForRoundUpdateVM request)
        {
            try
            {
                var obj = await _dbContext.ContentForRounds.FirstOrDefaultAsync(c => c.Id == idContentForRound);
                if(obj == null) return false;

                // Update Foreign Key
                obj.IdTextTemplate = request.IdTextTemplate;
                obj.IdRound = request.IdRound;

                // Update Property
                obj.Content = request.Content;

                // Base Update
                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedBy = request.ModifiedBy;


                _dbContext.ContentForRounds.Attach(obj);
                await Task.FromResult<ContentForRound>(_dbContext.ContentForRounds.Update(obj).Entity);
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
