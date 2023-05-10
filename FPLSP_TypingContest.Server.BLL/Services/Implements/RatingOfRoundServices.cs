using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class RatingOfRoundServices : IRatingOfRoundServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;

        public RatingOfRoundServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> AddAsync(RatingOfRoundCreateVM request)
        {
            try
            {
                var obj = new RatingOfRound()
                {
                    CreatedDate = DateTime.Now,

                    // Value của Property lấy từ object request
                    //CreatedBy = request.CreatedBy, ...    
                };

                await _dbContext.RatingOfRounds.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        public async Task<List<RatingOfRoundVM>> GetAllAsync()
        {
            var list = await _dbContext.RatingOfRounds.ProjectTo<RatingOfRoundVM>(_mapper.ConfigurationProvider).ToListAsync();

            return list;
        }

        public async Task<List<RatingOfRoundVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.RatingOfRounds.ProjectTo<RatingOfRoundVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<RatingOfRoundVM> GetByIdAsync(Guid idParticipant)
        {
            var obj = await _dbContext.RatingOfRounds.AsQueryable().SingleOrDefaultAsync(c => c.IdParticipant == idParticipant);
            var objVM = _mapper.Map<RatingOfRoundVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid idParticipant)
        {
            try
            {
                // Status xóa: mặc định = 1
                var listObj = await _dbContext.RatingOfRounds.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.IdParticipant == idParticipant);
                obj.Status = 1;

                _dbContext.RatingOfRounds.Attach(obj);
                await Task.FromResult<RatingOfRound>(_dbContext.RatingOfRounds.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid idParticipant, RatingOfRoundUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.RatingOfRounds.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.IdParticipant == idParticipant);

                // Property cần update
                //objForUpdate.Status = request.Status;

                _dbContext.RatingOfRounds.Attach(objForUpdate);
                await Task.FromResult<RatingOfRound>(_dbContext.RatingOfRounds.Update(objForUpdate).Entity);
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
