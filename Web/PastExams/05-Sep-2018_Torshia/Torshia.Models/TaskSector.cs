namespace Torshia.Models
{
    using Torshia.Models.Enums;

    public class TaskSector
    {
        public string Id { get; set; }
        public string TaskId { get; set; }
        public Task Task { get; set; }
        public SectorType Sector { get; set; }
    }
}
