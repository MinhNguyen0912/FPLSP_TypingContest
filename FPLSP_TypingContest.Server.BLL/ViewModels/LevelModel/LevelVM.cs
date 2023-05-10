using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel
{
    public class LevelVM
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; } 

    }
}
