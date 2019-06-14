namespace Torshia.App.ViewModels
{
    public class ReportViewModel
    {
        public string Id { get; set; }
        public string TaskTitle { get; set; }
        public int TaskLevel { get; set; }
        public string Status { get; set; }
        public string TaskDueDate { get; set; }
        public string ReportedOn { get; set; }
        public string ReporterName { get; set; }
        public string Participants { get; set; }
        public string AffectedSectors { get; set; }
        public string TaskDescription { get; set; }
    }
}
