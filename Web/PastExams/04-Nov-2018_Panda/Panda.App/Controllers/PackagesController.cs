namespace Panda.App.Controllers
{
    using Panda.App.ViewModels.ViewModels;
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
        private readonly IReceiptService receiptService;

        public PackagesController(IUserService userService, IPackageService packageService, IReceiptService receiptService)
        {
            this.userService = userService;
            this.packageService = packageService;
            this.receiptService = receiptService;
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
            var newPackage = new Package
            {
                Description = inputModel.Description,
                ShippingAddress = inputModel.ShippingAddress,
                Weight = inputModel.Weight,
                RecipientId = this.userService.GetUserIdByUsername(inputModel.RecipientName),
                Status = Status.Pending
            };

            this.packageService.AddPackageToDb(newPackage);

            return this.Redirect("/Home/Index");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var userId = this.userService.GetUserIdByUsername(this.User.Username);
            var pendingPackages = this.packageService.GetPendingPackagesByUserId(userId);

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
            this.receiptService.GenerateReceiptForPackageId(id);
            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var userId = this.userService.GetUserIdByUsername(this.User.Username);
            var deliveredPackages = this.packageService.GetDeliveredPackagesByUserId(userId);
            var viewModel = deliveredPackages.Select(ModelMapper.ProjectTo<DeliveredPackageViewModel>).ToList();

            foreach (var package in viewModel)
            {
                package.RecipientName = this.User.Username;
            }

            return this.View(viewModel);
        }
    }
}
