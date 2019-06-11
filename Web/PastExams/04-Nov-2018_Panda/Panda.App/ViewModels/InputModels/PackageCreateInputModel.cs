using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.InputModels
{
    public class PackageCreateInputModel
    {
        private const string DescriptionLengthErrorMsg = "Descrption length invalid! Should be between 5 and 20 symbols.";

        [RequiredSis]
        [StringLengthSis(5, 20, DescriptionLengthErrorMsg)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        [RequiredSis]
        public string RecipientName { get; set; }
    }
}
