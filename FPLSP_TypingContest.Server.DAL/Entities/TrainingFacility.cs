using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class TrainingFacility : EntityBase
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Organizer> Organizers { get; set; }
    }
}
