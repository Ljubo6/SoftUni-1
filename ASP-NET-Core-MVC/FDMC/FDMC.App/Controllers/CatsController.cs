namespace FDMC.App.Controllers
{
    using FDMC.App.Models;
    using FDMC.Domain;
    using FDMC.Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class CatsController : Controller
    {
        private FDMCcontext db;

        public CatsController(FDMCcontext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCatInputModel inputModel)
        {
            var cat = new Cat
            {
                Name = inputModel.Name,
                Age = inputModel.Age,
                Breed = inputModel.Breed,
                ImageUrl = inputModel.ImageUrl
            };

            this.db.Add(cat);
            this.db.SaveChanges();

            return this.Redirect("/");
        }

        [HttpGet("/Cats/{id}")]
        public IActionResult Details(string id)
        {
            var cat = this.db.Cats.SingleOrDefault(c => c.Id == id);
            var viewModel = new CatViewModel
            {
                Name = cat.Name,
                Age = cat.Age,
                Breed = cat.Breed,
                ImageUrl = cat.ImageUrl
            };

            return this.View(viewModel);
        }
    }
}