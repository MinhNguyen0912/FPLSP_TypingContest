using AutoMapper;
using AutoMapper.QueryableExtensions;
using FPLSP_TypingContest.Server.BLL.Services.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.Role;
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
    public class RoleServices : IRoleServices
    {
        private readonly FPLSP_TypingContestDbContext _dbContext;
        private readonly IMapper _mapper;
        public RoleServices(IMapper mapper)
        {
            this._dbContext = new FPLSP_TypingContestDbContext();
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddAsync(RoleCreateVM request)
        {
            try
            {
                var obj = new Role()
                {
                    Name = request.Name,
                    CreatedDate = DateTime.Now,
                    CreatedBy = request.CreateBy,
                };

                await _dbContext.Roles.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoleVM>> GetAllActiveAsync()
        {
            var list = await _dbContext.Roles.ProjectTo<RoleVM>(_mapper.ConfigurationProvider).Where(c => c.Status != 1).ToListAsync();

            return list;
        }

        public async Task<List<RoleVM>> GetAllAsync()
        {
            var list = await _dbContext.Roles.ProjectTo<RoleVM>(_mapper.ConfigurationProvider).ToListAsync();

            return list;
        }

        public async Task<RoleVM> GetByIdAsync(Guid id)
        {
            var obj = await _dbContext.Roles.AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
            var objVM = _mapper.Map<RoleVM>(obj);

            return objVM;
        }

        public async Task<bool> RemoveAsync(Guid id, Guid idUserdelete)
        {
            try
            {
                // Status xóa: mặc định = 1
                var listObj = await _dbContext.Roles.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;
                obj.DeletedDate = DateTime.Now;
                obj.DeletedBy = idUserdelete;

                _dbContext.Roles.Attach(obj);
                await Task.FromResult<Role>(_dbContext.Roles.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, RoleUpdateVM request)
        {
            try
            {
                var listObj = await _dbContext.Roles.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);
                objForUpdate.Status = request.Status;
                objForUpdate.Name = request.Name;
                objForUpdate.ModifiedDate = DateTime.Now;
                objForUpdate.ModifiedBy = request.ModifiedBy;
                _dbContext.Roles.Attach(objForUpdate);
                await Task.FromResult<Role>(_dbContext.Roles.Update(objForUpdate).Entity);
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
