using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Login
{
    public class UserLoginVM
    {
        public Guid Id { get; set; }
        public List<string> Roles { get; set; }
    }
}
