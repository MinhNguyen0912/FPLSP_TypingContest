using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.Participant;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class ParticipantMap : Profile
    {
        public ParticipantMap()
        {
            CreateMap<Participant, ParticipantVM>()
           //.ForMember(dest => dest.Accuracy, opt => opt.MapFrom(src => src.RatingOfRound.Accuracy))
           //.ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.RatingOfRound.Speed))
           .ReverseMap();
        }
    }
}
