using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.Round;
using FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate;
using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class RoundMap : Profile
    {
            public RoundMap()
            {
                CreateMap<Round, RoundVM>().ReverseMap();
            }
    }
}
