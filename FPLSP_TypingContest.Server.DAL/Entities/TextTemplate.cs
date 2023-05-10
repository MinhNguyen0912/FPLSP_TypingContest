using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class TextTemplate : EntityBase
    {
        public Guid IdLevel { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public virtual Level Level { get; set; }
        public virtual ICollection<ContentForRound> ContentForRounds { get; set; }
    }
}
