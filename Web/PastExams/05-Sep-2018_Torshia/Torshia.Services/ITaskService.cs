namespace Torshia.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Torshia.Models;

    public interface ITaskService
    {
        bool CreateNewTask(string title, string dueDate, string description, string participants, IEnumerable<string> AffectedSectors);

        IQueryable<Task> GetAllTasks();

        Task GetTaskById(string id);

        bool ReportTaskbyId(string id);
    }
}
