namespace FPLSP_TypingContest.Server.BLL.ViewModels.TranningFacility
{
    public class TrainingFacilityCreateVM
    {
        public Guid CreateBy { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
