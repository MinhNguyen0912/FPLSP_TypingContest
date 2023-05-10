

namespace FPLSP_TypingContest.Server.BLL.ViewModels.User
{
    public class UserCreateVM
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string? Email { get; set; }
        public Guid IdFacility { get; set; }
        public Guid CreateBy { get; set; }
    }
}
