using FPLSP_TypingContest.Server.BLL.ViewModels.LevelModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate
{
    public class TextTemplateUpdateVM
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid LevelId { get; set; }
    }
}
