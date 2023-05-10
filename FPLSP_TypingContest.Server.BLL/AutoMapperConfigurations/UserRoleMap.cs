using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.User;
using FPLSP_TypingContest.Server.BLL.ViewModels.UserRole;
using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class UserRoleMap : Profile
    {
        public UserRoleMap()
        {
            CreateMap<UserRole, UserRoleVM>().ReverseMap();
        }
    }
}
