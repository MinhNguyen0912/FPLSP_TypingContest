using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Participant
{
    public class ParticipantVM
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string? Email { get; set; }
        //public float Accuracy { get; set; }
        //public float Speed { get; set; }
    }
}
