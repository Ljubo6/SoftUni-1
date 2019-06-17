namespace SULS.App.ViewModels.Problems
{
    using SULS.App.ViewModels.Submmissions;
    using System.Collections.Generic;

    public class ProblemsDetailsViewModel
    {
        public string Name { get; set; }
        public int MaxPoints { get; set; }
        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
