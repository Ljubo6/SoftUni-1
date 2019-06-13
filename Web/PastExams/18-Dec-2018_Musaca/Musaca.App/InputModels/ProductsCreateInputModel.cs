using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.App.InputModels
{
    public class ProductsCreateInputModel
    {
        private const int nameMinLength = 3;
        private const int nameMaxLength = 10;
        private const string nameLengthErrorMessage = "Product name should be between 3 and 10 characters";

        private const string minPrice = "0.01";
        private const string maxPrice = "79228162514264337593543950335";
        private const string priceErrorMessage = "Product price should be at least 0.01";

        [RequiredSis]
        [StringLengthSis(nameMinLength, nameMaxLength, nameLengthErrorMessage)]
        public string Name { get; set; }


        [RequiredSis]
        [RangeSis(typeof(decimal), minPrice, maxPrice, priceErrorMessage)]
        public decimal Price { get; set; }
    }
}
