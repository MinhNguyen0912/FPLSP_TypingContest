using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class Role : EntityBase
    {
        public string? Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
