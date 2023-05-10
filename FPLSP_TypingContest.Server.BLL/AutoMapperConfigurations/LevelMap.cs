using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class LevelMap:Profile
    {
        public LevelMap()
        {
            CreateMap<Level,LevelVM>().ReverseMap();
        }
    }
}
