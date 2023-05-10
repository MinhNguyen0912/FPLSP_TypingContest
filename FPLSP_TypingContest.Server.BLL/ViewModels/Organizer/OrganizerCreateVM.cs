namespace FPLSP_TypingContest.Server.BLL.ViewModels.Organizer
{
    public class OrganizerCreateVM
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string? Email { get; set; }
        public Guid IdFacility { get; set; }
        public Guid CreateBy { get; set; }

    }
}
