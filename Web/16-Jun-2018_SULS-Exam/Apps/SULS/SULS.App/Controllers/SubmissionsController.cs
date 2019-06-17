namespace SULS.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using SULS.App.InputModels;
    using SULS.App.ViewModels.Problems;
    using SULS.Services;
    using System;
    using System.Linq;

    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        [Authorize]
        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetProblemById(id);
            var viewModel = new CreateSubmissionProblemViewModel
            {
                ProblemId = problem.Id,
                Name = problem.Name
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateSubmissionInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Submissions/Create");
            }

            var problemId = this.Request.FormData["ProblemId"].FirstOrDefault(); 
            this.submissionService.CreateNewSubmission(problemId, this.User.Id, inputModel.Code);
            return this.Redirect("/");
        }

        public IActionResult Delete(string id)
        {
            this.submissionService.DeleteSubmissionById(id);
            return this.Redirect("/");
        }
    }
}
