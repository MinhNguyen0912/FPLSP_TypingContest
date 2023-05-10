using FPLSP_TypingContest.Repositories.Interfaces;
using FPLSP_TypingContest.Server.BLL.ViewModels.UserIdentityVM;
using FPLSP_TypingContest.Server.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FPLSP_TypingContest.Repositories.Services
{
    public class UserIdentityRespositories : IUserIdentityRespositories
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepositories _userRepositories;
        public UserIdentityRespositories(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepositories userRepositories)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepositories = userRepositories;
        }

        public async Task<UserIdentityVM> GetUserByIdIdentityAsync(string Id)
        {
            var useridentity = await _userManager.FindByIdAsync(Id);
            var roles = await _userManager.GetRolesAsync(useridentity);
            UserIdentityVM userIdentityVM = new UserIdentityVM()
            {
                Id = useridentity.Id,
                Email = useridentity.Email,
                UserName = useridentity.UserName,
                Roles = roles.ToList()
            };
            return userIdentityVM;

        }

        //public async Task<bool> CreateUserIdentityAsync(UserIdentityVM userIdentityVM)
        //{
        //    try
        //    {
        //        var createusre = await _userManager.CreateAsync(userIdentityVM);
        //        if (createusre.Succeeded)
        //        {
        //            await _userManager.AddToRolesAsync(userIdentityVM, userIdentityVM.Roles);
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<UserIdentityVM>> GetUsersIdentityAsync()
        {
            List<UserIdentityVM> userIdentityVMs = new();
            var userIdentitys = await _userManager.Users.ToListAsync();
            foreach (var userIdentity in userIdentitys)
            {
                var user = await _userRepositories.GetByIdAsync(Guid.Parse(userIdentity.Id));
                var rolesForUser = await _userManager.GetRolesAsync(userIdentity);
                UserIdentityVM userIdentityVM = new UserIdentityVM()
                {
                    Id = userIdentity.Id,
                    Email = userIdentity.Email,
                    UserName = userIdentity.UserName,
                    Roles = rolesForUser.ToList(),
                    IdTrainingFacility = user.IdTrainingFacility
                };
                userIdentityVMs.Add(userIdentityVM);
            }
            return userIdentityVMs;
        }

        public async Task<bool> UpdateUserIdentityAsync(UserIdentityVM userIdentityVM)
        {
            try
            {
                var identityUser = await _userManager.FindByIdAsync(userIdentityVM.Id);
                var GetAllRoles = _roleManager.Roles.ToList();
                var rolesForUser = await _userManager.GetRolesAsync(identityUser);

                foreach (var role in GetAllRoles)
                {
                    if (!userIdentityVM.Roles.Any(c => c == role.Name) && rolesForUser.Any(c => c == role.Name))
                    {
                        await _userManager.RemoveFromRoleAsync(identityUser, role.Name);
                    }
                    if (userIdentityVM.Roles.Any(c => c == role.Name) && !rolesForUser.Any(c => c == role.Name))
                    {
                        await _userManager.AddToRoleAsync(identityUser, role.Name);
                    }
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
