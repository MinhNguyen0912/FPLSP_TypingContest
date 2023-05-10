using FPLSP_TypingContest.Server.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace FPLSP_TypingContest.Server.DAL.Entities
{
    public partial class UserRole : NoIdEntityBase
    {
        public Guid IdRole { get; set; }
        public Guid IdUser { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

    }
}
