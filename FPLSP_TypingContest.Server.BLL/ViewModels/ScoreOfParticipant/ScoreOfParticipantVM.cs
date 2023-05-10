using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.ScoreOfParticipant
{
    public class ScoreOfParticipantVM
    {
        // Foreign Key
        public Guid IdParticipant { get; set; }
        public Guid IdContentForRound { get; set; }

        // Proprety
        public float Accuracy { get; set; }
        public float Speed { get; set; }

        // Base
        public Guid Id { get; set; }
        public int Status { get; set; }
    }
}
