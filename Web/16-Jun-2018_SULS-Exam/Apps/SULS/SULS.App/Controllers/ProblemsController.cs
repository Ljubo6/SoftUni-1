namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.InputModels;
    using SULS.App.ViewModels.Problems;
    using SULS.App.ViewModels.Submmissions;
    using SULS.Services;
    using System;
    using System.Linq;

    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private const int ProblemMaxPoints = 100;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProblemInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemService.AddNewProblemToDb(inputModel.Name, inputModel.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details (string id)
        {
            var problem = this.problemService.GetProblemById(id);
            var submissions = this.problemService.GetAllSubmissionsForProblem(id).ToList();

            var submissionViewModels = submissions.Select(s => new SubmissionViewModel
            {
                SubmissionId = s.Id,
                Username = s.User.Username,
                AchievedResult = (int)Math.Round(s.AchievedResult * 100m / problem.Points),
                MaxPoints = s.Problem.Points,
                CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy")
            })
            .ToList();

            var viewModel = new ProblemsDetailsViewModel
            {
                Name = problem.Name,
                MaxPoints = ProblemMaxPoints,
                Submissions = submissionViewModels
            };

            return this.View(viewModel);
        }
    }
}
