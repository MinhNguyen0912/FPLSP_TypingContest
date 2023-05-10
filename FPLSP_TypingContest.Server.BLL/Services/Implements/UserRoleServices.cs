using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.UserRole;
using FPLSP_TypingContest.Server.DAL.ApplicationDbContext;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FPLSP_TypingContest.Server.BLL.Services.Implements
{
    public class UserRoleServices : IUserRoleServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRoleServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(UserRoleCreateVM request)
        {
            try
            {
                var obj = new UserRole()
                {
                    CreatedDate = DateTime.Now,
                    IdRole= request.RoleId,
                    IdUser = request.UserId,
                    CreatedBy = request.CreateBy,
                };

                await _dbContext.UserRoles.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<UserRoleVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.UserRoles.ProjectTo<UserRoleVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<UserRoleVM>> GetAllAsync()
        {
            var list = await _dbContext.UserRoles.ProjectTo<UserRoleVM>(_mapper.ConfigurationProvider).ToListAsync();

            return list;
        }

        public async Task<List<UserRoleVM>> GetByIdAsync(Guid RoleId, Guid UserId)
        {
            //var obj = await _dbContext.UserRoles.AsQueryable().SingleOrDefaultAsync(c => c.IdRole == RoleId && c.IdUser == UserId);
            //var objVM = _mapper.Map<UserRoleVM>(obj);

            var list = await _dbContext.UserRoles.ProjectTo<UserRoleVM>(_mapper.ConfigurationProvider).Where(c => c.UserId == UserId && c.RoleId == RoleId).ToListAsync();
            return list;
        }

        public async Task<bool> RemoveAsync(Guid RoleId, Guid UserId, Guid idUserdelete)
        {
            try
            {
                var listObj = await _dbContext.UserRoles.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.IdRole == RoleId && c.IdUser == UserId);
                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                obj.DeletedBy = idUserdelete;

                _dbContext.UserRoles.Attach(obj);
                await Task.FromResult<UserRole>(_dbContext.UserRoles.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid RoleId, Guid UserId, UserRoleUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.UserRoles.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.IdRole == RoleId && c.IdUser == UserId);
                objForUpdate.Status = request.Status;
                objForUpdate.ModifiedDate = DateTime.Now;
                objForUpdate.ModifiedBy = request.ModifiedBy;

                _dbContext.UserRoles.Attach(objForUpdate);
                await Task.FromResult<UserRole>(_dbContext.UserRoles.Update(objForUpdate).Entity);
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
