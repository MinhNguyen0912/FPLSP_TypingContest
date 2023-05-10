using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class ScoreOfParticipant : EntityBase
    {
        public Guid IdParticipant { get; set; }
        public Guid IdContentForRound { get; set; }
        public float Accuracy { get; set; }
        public float Speed { get; set; }

        public virtual ContentForRound ContentForRound { get; set; }
        public virtual Participant Participant { get; set; }

    }
}
