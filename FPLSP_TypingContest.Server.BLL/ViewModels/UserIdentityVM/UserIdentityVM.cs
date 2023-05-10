using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.UserIdentityVM
{
    public class UserIdentityVM : IdentityUser
    {
        public Guid IdTrainingFacility { get; set; }
        public List<string> Roles { get; set; }
    }
}
