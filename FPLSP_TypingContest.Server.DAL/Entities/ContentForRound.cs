using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class ContentForRound : EntityBase
    {
        public Guid IdTextTemplate { get; set; }
        public Guid IdRound { get; set; }
        public string? Content { get; set; }

        public virtual TextTemplate TextTemplate { get; set; }
        public virtual Round Round { get; set; }
        public virtual ICollection<ScoreOfParticipant> ScoreOfParticipants { get; set; }

    }
}
