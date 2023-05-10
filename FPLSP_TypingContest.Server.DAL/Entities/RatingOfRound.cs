using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public class RatingOfRound : NoIdEntityBase
    {
        public Guid IdParticipant { get; set; }
        public float Accuracy { get; set; }
        public float Speed { get; set; }

        public virtual Participant Participant { get; set; }
    }
}
