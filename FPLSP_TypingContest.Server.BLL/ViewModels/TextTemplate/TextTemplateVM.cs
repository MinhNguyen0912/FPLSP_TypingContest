using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate
{
    public class TextTemplateVM
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public virtual LevelVM? LevelVM { get; set; }
        public int Status { get; set; }
        public Guid IdLevel { get; set; }

    }
}
