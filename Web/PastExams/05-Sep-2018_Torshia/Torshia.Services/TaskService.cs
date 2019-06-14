namespace Torshia.Services
{
    using System;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Torshia.Data;
    using Torshia.Models;

    public class TaskService : ITaskService
    {
        private readonly TorshiaDbContext context;
        private readonly IUserService userService;

        public TaskService(TorshiaDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public bool CreateNewTask(string title, string dueDate, string description, string participants)
        {
            string[] participantsNames = participants.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var task = new Task
            {
                Title = title,
                DueDate = DateTime.ParseExact(dueDate, "yyyy-mm-dd", CultureInfo.InvariantCulture),
                Description = description
            };

            this.context.Add(task);
            this.context.SaveChanges();

            var participatingUsersId = participantsNames.Select(x => this.userService.GetUserByUsername(x).Id);

            foreach (var id in participatingUsersId)
            {
                task.Participants.Add(new UserTask
                {
                    TaskId = task.Id,
                    UserId = id
                });
            }

            this.context.Update(task);
            this.context.SaveChanges();
            return true;
        }

        public IQueryable<Task> GetAllTasks()
        {
            return this.context.Tasks;
        }

        public Task GetTaskById(string id)
        {
            return this.context.Tasks
                .Include(t => t.Participants)
                .ThenInclude(tu => tu.User)
                .SingleOrDefault(t => t.Id == id);
        }

        public bool ReportTaskbyId(string id)
        {
            this.GetTaskById(id).IsReported = true;
            return true;
        }
    }
}
