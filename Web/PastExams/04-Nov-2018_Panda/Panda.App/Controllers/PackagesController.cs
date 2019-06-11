namespace Panda.App.Controllers
{
    using Panda.App.ViewModels.ViewModels;
    using Panda.App.ViewModels.InputModels;
    using Panda.Models;
    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using System.Linq;

    public class PackagesController : Controller
    {
        private readonly IUserService userService;
        private readonly IPackageService packageService;

        public PackagesController(IUserService userService, IPackageService packageService)
        {
            this.userService = userService;
            this.packageService = packageService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var allUsers = this.userService.GetAllUsers();
            var viewModel = allUsers.Select(ModelMapper.ProjectTo<CreatePackageRecepientViewModel>).ToList();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PackageCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            
            this.packageService.AddPackageToDb(inputModel.Description, inputModel.ShippingAddress, inputModel.Weight, inputModel.RecipientName);
            return this.Redirect("/Home/Index");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var pendingPackages = this.packageService.GetPackagesByStatusAndUserId(PackageStatus.Pending, this.User.Id);

            var viewModel = pendingPackages.Select(ModelMapper.ProjectTo<PendingPackageViewModel>).ToList();

            foreach (var package in viewModel)
            {
                package.RecipientName = this.User.Username;
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packageService.DeliverPackageById(id);
            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.packageService.GetPackagesByStatusAndUserId(PackageStatus.Delivered, this.User.Id);
            var deliveredPackagesViewModel = deliveredPackages.Select(ModelMapper.ProjectTo<DeliveredPackageViewModel>).ToList();

            foreach (var package in deliveredPackagesViewModel)
            {
                package.RecipientName = this.User.Username;
            }

            return this.View(deliveredPackagesViewModel);
        }
    }
}
