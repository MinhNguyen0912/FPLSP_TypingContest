using FPLSP_TypingContest.Server.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.TextTemplate
{
    public class TextTemplateCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public Guid CreatedBy { get; set; }
        [Required]
        public Guid LevelId { get; set; }
        [Required]
        public string LevelName { get; set; }
    }
}
