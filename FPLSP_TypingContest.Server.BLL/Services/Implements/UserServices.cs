using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.User;
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
    public class UserServices : IUserServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(UserCreateVM request)
        {
            try
            {
                var obj = new User()
                {
                    Email = request.Email,
                    CreatedDate = DateTime.Now,
                    IdTrainingFacility = request.IdFacility,
                    Id = request.Id,
                    CreatedBy = request.CreateBy,
                };

                await _dbContext.Users.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<UserVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.Users.ProjectTo<UserVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<UserVM>> GetAllAsync()
        {
            var list = await _dbContext.Users.Include(c=>c.TrainingFacility).ProjectTo<UserVM>(_mapper.ConfigurationProvider).ToListAsync();

            return list;
        }

        public async Task<UserVM> GetByIdAsync(Guid id)
        {
            var obj = await _dbContext.Users.AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
            var objVM = _mapper.Map<UserVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid id,Guid idUserdelete)
        {
            try
            {
                // Status xóa: mặc định = 1
                var listObj = await _dbContext.Users.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                obj.DeletedBy = idUserdelete;

                _dbContext.Users.Attach(obj);
                await Task.FromResult<User>(_dbContext.Users.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, UserUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.Users.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                objForUpdate.Status = request.Status;
                objForUpdate.ModifiedDate = DateTime.Now;
                objForUpdate.IdTrainingFacility = request.IdFacility;
                objForUpdate.ModifiedBy = request.ModifiedBy;

                _dbContext.Users.Attach(objForUpdate);
                await Task.FromResult<User>(_dbContext.Users.Update(objForUpdate).Entity);
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
