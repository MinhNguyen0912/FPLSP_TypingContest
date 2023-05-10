using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.UserRole
{
    public class UserRoleCreateVM
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public Guid CreateBy { get; set; }
    }
}
