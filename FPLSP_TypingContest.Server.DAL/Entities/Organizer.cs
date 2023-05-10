using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class Organizer : EntityBase
    {
        public Guid IdTrainingFacility { get; set; }
        public string? Email { get; set; }

        public virtual TrainingFacility TrainingFacility { get; set; }
        public virtual ICollection<Contest> Contests { get; set; }

    }
}
