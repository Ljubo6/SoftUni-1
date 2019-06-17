using SIS.MvcFramework.Attributes.Validation;
using System;

namespace SULS.App.InputModels
{
    public class CreateSubmissionInputModel
    {
        private const int CodeLengthMinValue = 30;
        private const int CodeLengthMaxValue = 800;
        private const string CodeLengthErrorMsg = "Code length should be between 30 and 800 characters.";

        [RequiredSis]
        [StringLengthSis(CodeLengthMinValue, CodeLengthMaxValue, CodeLengthErrorMsg)]
        public string Code { get; set; }
    }
}
