using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.Role;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class RoleMap : Profile
    {
        public RoleMap()
        {
            CreateMap<Role, RoleVM>().ReverseMap();
        }
    }
}
