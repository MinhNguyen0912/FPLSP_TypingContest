using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound
{
    public class ContentForRoundCreateVM
    {
        // Khóa ngoại
        public Guid IdTextTemplate { get; set; }
        public Guid IdRound { get; set; }

        //Trường
        public string? Content { get; set; }

        //Base
        public Guid CreatedBy { get; set; }
    }
}
