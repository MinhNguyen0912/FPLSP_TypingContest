using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLSP_TypingContest.Server.BLL.ViewModels.Round
{
    public class RoundVM
    {
        public Guid Id { get; set; }
        public Guid IdContest { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int TimeLimit { get; set; }
        public int MaxAccess { get; set; }
        public int Availability { get; set; }
        public bool IsDisableBackspace { get; set; }
        public bool IsHavingSpecialChar { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public int Status { get; set; }
        public bool IsFinal { get; set; }
    }
}
