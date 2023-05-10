using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.User;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<User, UserVM>().ForMember(dest => dest.address, opt => opt.MapFrom(src => src.TrainingFacility.Address)).ReverseMap();
        }
    }
}
