using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.User
{
    public class UserUpdateVM
    {
        public int Status { get; set; }
        public string? Email { get; set; }
        public Guid IdFacility { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
