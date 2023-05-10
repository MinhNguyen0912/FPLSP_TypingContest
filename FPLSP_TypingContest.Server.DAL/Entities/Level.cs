using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class Level : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TextTemplate> TextTemplates { get; set; }
    }
}
