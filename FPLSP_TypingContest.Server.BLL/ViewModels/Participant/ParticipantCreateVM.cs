using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Participant
{
    public class ParticipantCreateVM
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public Guid CreateBy { get; set; }
        public string? Email { get; set; }
        public Guid IdRound { get; set; }
        public Guid IdUser { get; set; }
    }
}
