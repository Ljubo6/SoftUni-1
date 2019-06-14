namespace Torshia.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using System.Linq;
    using Torshia.App.ViewModels;
    using Torshia.Services;

    public class HomeController : Controller
    {
        private readonly ITaskService taskService;

        public HomeController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            var allTasks = this.taskService.GetAllTasks().ToList();
            var viewModel = allTasks.Select(t => new TaskViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Level = t.AffectedSectors.Count()
            })
                .ToList();

            if (this.IsLoggedIn())
            {
                return this.View(viewModel, "IndexLoggedIn");
            }
            return this.View();
        }
    }
}
