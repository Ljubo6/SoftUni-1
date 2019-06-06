namespace Musaca.App.Controllers
{
    using Musaca.App.ViewModels;
    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        //[Authorize]
        public ActionResult All()
        {
            var productsAllViewModel = new ProductsAllViewModel();
            var allDbProducts = this.productService.GetAllProducts();

            foreach (var product in allDbProducts)
            {
                var productSingleViewModel = ModelMapper.ProjectTo<ProductSingleViewModel>(product);
                productsAllViewModel.Add(productSingleViewModel);
            }

            return this.View(productsAllViewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(string name, decimal price, long barcode, string picture)
        {
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Barcode = barcode,
                Picture = picture
            };

            this.productService.AddProduct(product);

            return this.Redirect("/Products/All");
        }
    }
}
