namespace Torshia.Models
{
    using System;
    using Torshia.Models.Enums;

    public class TaskSector
    {
        public TaskSector()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string TaskId { get; set; }
        public Task Task { get; set; }
        public SectorType Sector { get; set; }
    }
}
