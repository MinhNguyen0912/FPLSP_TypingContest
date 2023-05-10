using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.Organizer;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class OrganizerMap : Profile
    {
        public OrganizerMap()
        {
            CreateMap<Organizer, OrganizerVM>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.TrainingFacility.Address))
            .ForMember(dest => dest.NameFaci, opt => opt.MapFrom(src => src.TrainingFacility.Name))
            .ReverseMap();
        }
    }
}
