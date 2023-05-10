using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Participant;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class ParticipantServices : IParticipantServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public ParticipantServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> AddAsync(ParticipantCreateVM request)
        {
            try
            {

                var obj = new Participant()
                {
                    Id = request.Id,
                    CreatedDate = DateTime.Now,
                    CreatedBy = request.CreateBy,
                    Email = request.Email,
                    IdRound = request.IdRound,
                    IdUser = request.IdUser

                };

                // Thêm đối tượng Organizer mới vào database context và lưu thay đổi vào database
                await _dbContext.Participants.AddAsync(obj);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ParticipantVM>> GetAllActiveAsync()
        {
            var participantVMs = await _dbContext.Participants
            //.Include(o => o.RatingOfRound)
            .Where(o => o.Status != 1)
            .ProjectTo<ParticipantVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return participantVMs;
        }

        public async Task<List<ParticipantVM>> GetAllAsync()
        {
            var participantVMs = await _dbContext.Participants
            //.Include(o => o.RatingOfRound)
            .ProjectTo<ParticipantVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
            return participantVMs;
        }

        public async Task<ParticipantVM> GetByIdAsync(Guid id)
        {
            var participantVMs = await _dbContext.Participants
            //.Include(o => o.RatingOfRound)
            .FirstOrDefaultAsync(o => o.Id == id);
            var participantVM = _mapper.Map<ParticipantVM>(participantVMs);
            return participantVM;
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUser)
        {
            try
            {
                // Status xóa: mặc định = 1
                var listObj = await _dbContext.Participants.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);

                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                obj.DeletedBy = idUser;
                _dbContext.Participants.Attach(obj);
                await Task.FromResult<Participant>(_dbContext.Participants.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, ParticipantUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.Participants.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                // Property cần update
                objForUpdate.Status = request.Status;
                objForUpdate.ModifiedDate = DateTime.Now;
                objForUpdate.ModifiedBy = request.ModifiedBy;
                objForUpdate.IdRound = request.IdRound;
                objForUpdate.IdUser = request.IdUser;
                _dbContext.Participants.Attach(objForUpdate);
                await Task.FromResult<Participant>(_dbContext.Participants.Update(objForUpdate).Entity);
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
