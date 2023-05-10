using AutoMapper;
using FPLSP_TypingContest.Server.BLL.ViewModels.RatingOfRound;
using FPLSP_TypingContest.Server.DAL.Entities;

namespace FPLSP_TypingContest.Server.BLL.AutoMapperConfigurations
{
    public class RatingOfRoundMap : Profile // phải kế thừa Profile của Automaper Khi tạo mới
    {
        public RatingOfRoundMap() // Tạo Constructor cho Class và Create map tại Đây
        {
            //CreateMap<RatingOfRound, RatingOfRoundVM>();
            CreateMap<RatingOfRound, RatingOfRoundVM>().ReverseMap(); // ReverseMap() dùng để máp ngược lại từ RatingOfRoundVM => RatingOfRound ||| 
        }
    }
}
