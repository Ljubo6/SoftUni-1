namespace Panda.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Panda.App.Models.Package;
    using Panda.Services;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IPackagesService packagesService;

        public HomeController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        public IActionResult Index()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                List<PackageHomeViewModel> userPackages = this.packagesService
                    .GetUserPackagesByUserName(this.User.Identity.Name)
                    .Select(package => new PackageHomeViewModel
                    {
                        Id = package.Id,
                        Description = package.Description,
                        Status = package.Status.Name
                    })
                    .ToList();

                return this.View(userPackages);
            }

            return this.View();
        }
    }
}
