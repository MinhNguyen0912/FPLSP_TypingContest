using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class Round : EntityBase
    {
        public Guid IdContest { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int MaxAccess { get; set; }
        public int Availability { get; set; }
        public bool IsDisableBackspace { get; set; }
        public bool IsHavingSpecialChar { get; set; }
        public TimeSpan TotalTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsFinal { get; set; }

        public virtual Contest Contest { get; set; }
        public virtual ICollection<ContentForRound> ContentForRounds { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }

    }
}
