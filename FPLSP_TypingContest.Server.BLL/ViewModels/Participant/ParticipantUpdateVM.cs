using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Participant
{
    public class ParticipantUpdateVM
    {
        public int Status { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid IdRound { get; set; }
        public Guid IdUser { get; set; }
    }
}
