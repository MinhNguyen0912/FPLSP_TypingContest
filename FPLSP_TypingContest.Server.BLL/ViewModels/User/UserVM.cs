using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.User
{
    public class UserVM
    {
        public int Status { get; set; }
        public string? Email { get; set; }
        public string? address { get; set; }
        public Guid IdTrainingFacility { get; set; }
        public Guid Id { get; set; }
    }
}
