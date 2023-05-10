using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.UserRole
{
    public class UserRoleUpdateVM
    {
        public int Status { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
