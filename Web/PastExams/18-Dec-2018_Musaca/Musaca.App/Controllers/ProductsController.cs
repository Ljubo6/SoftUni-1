namespace Musaca.App.Controllers
{
    using Musaca.App.InputModels;
    using Musaca.App.ViewModels;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System.Linq;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProductsCreateInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            this.productService.AddNewProductToDb(inputModel.Name, inputModel.Price);
            return this.Redirect("/Home/Index");
        }

        [Authorize]
        public IActionResult All()
        {
            var allProducts = this.productService.GetAllProducts();
            var viewModel = allProducts
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();
            return this.View(viewModel);
        }
    }
}
