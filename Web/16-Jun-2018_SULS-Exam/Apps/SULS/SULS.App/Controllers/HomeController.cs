namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;
    using SULS.App.ViewModels.Problems;
    using SULS.Services;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var allProblems = this.problemService.GetAllProblems().ToList();
                var viewModel = allProblems.Select(p => new HomePageProblemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count
                })
                    .ToList();
                

                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}