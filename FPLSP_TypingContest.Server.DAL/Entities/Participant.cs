using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class Participant : EntityBase
    {
        public Guid IdUser { get; set; }
        public Guid IdRound { get; set; }
        public string? Email { get; set; }

        public virtual Round Round { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ScoreOfParticipant> ScoreOfParticipants { get; set; }
        public virtual RatingOfRound RatingOfRound { get; set; }

    }
}
