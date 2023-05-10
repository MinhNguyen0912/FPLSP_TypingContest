using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.Contest;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class ContestMap : Profile
    {
        public ContestMap()
        {
            CreateMap<Contest, ContestVM>().ReverseMap();
        }
    }
}
