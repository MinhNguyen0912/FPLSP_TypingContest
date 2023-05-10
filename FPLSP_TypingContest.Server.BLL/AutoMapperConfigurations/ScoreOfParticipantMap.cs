using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant;
using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class ScoreOfParticipantMap : Profile
    {
        public ScoreOfParticipantMap()
        {
            CreateMap<ScoreOfParticipant, ScoreOfParticipantVM>().ReverseMap();
        }
    }
}
