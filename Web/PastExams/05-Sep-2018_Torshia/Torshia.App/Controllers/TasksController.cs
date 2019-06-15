namespace Torshia.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System.Linq;
    using Torshia.App.InputModels;
    using Torshia.App.ViewModels;
    using Torshia.Services;

    public class TasksController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IReportService reportService;

        public TasksController(ITaskService taskService, IReportService reportService)
        {
            this.taskService = taskService;
            this.reportService = reportService;
        }

        [Authorize("Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreteTaskInputModel inputModel)
        {
            this.taskService
                .CreateNewTask(inputModel.Title, inputModel.DueDate, inputModel.Description, inputModel.Participants, this.Request.FormData["checkbox"]);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string taskId)
        {
            var task = this.taskService.GetTaskById(taskId);
            var viewModel = new TaskViewModel
            {
                Title = task.Title,
                Level = task.AffectedSectors.Count,
                DueDate = task.DueDate.ToString("dd/MM/yyyy"),
                Participants = string.Join(", ", task.Participants.Select(p => p.User.Username)),
                AffectedSectors = string.Join(", ", task.AffectedSectors.Select(s => s.Sector.ToString())),
                Description = task.Description
            };

            return this.View(viewModel);
        }

        public IActionResult Report(string taskId)
        {
            this.taskService.ReportTaskbyId(taskId);
            this.reportService.CreateReportByTaskId(this.User.Id, taskId);
            return this.Redirect("/");
        }
    }
}
