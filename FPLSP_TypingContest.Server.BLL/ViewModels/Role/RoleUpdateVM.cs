using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Role
{
    public class RoleUpdateVM
    {
        public int Status { get; set; }
        public string? Name { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
