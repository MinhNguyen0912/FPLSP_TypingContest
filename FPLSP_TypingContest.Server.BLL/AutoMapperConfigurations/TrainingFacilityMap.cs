using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class TrainingFacilityMap : Profile
    {
        public TrainingFacilityMap()
        {
            CreateMap<TrainingFacility, TrainingFacilityVM>().ReverseMap();
        }
    }
}
