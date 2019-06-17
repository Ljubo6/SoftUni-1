using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.InputModels
{
    public class CreateProblemInputModel
    {
        private const int ProblemNameMinLength = 5;
        private const int ProblemNameMaxLength = 20;
        private const string ProblemNameErrorMsg = "Problem name must be between 5 and 20 characters";

        private const int PointsMinValue = 50;
        private const int PointsMaxValue = 300;
        private const string PointsErrorMsg = "Problem total points must be between 50 and 300 inclusive";

        [RequiredSis]
        [StringLengthSis(ProblemNameMinLength, ProblemNameMaxLength, ProblemNameErrorMsg)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(PointsMinValue, PointsMaxValue, PointsErrorMsg)]
        public int Points { get; set; }
    }
}
