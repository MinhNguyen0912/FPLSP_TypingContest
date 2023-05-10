using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel
{
    public class LevelCreateVM
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
