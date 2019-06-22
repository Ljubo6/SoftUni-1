namespace FDMC.App.Controllers
{
    using FDMC.App.Models;
    using FDMC.Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        private FDMCcontext db;

        public HomeController(FDMCcontext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = this.db.Cats.Select(cat => new HomeCatViewModel
            {
                Id = cat.Id,
                Name = cat.Name
            })
            .ToList();

            return View(viewModel);
        }
    }
}