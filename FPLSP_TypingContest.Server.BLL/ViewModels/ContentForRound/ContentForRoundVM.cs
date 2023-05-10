using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.ContentForRound
{
    public class ContentForRoundVM
    {
        // Proprety
        public Guid IdTextTemplate { get; set; }
        public Guid IdRound { get; set; }
        public string? Content { get; set; }

        // Base
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
