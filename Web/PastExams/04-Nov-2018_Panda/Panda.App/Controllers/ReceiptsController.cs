namespace Panda.App.Controllers
{
    using Panda.App.ViewModels.ViewModels;
    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;
    using System.Collections.Generic;
    using System.Linq;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;
        private readonly IUserService userService;

        public ReceiptsController(IReceiptService receiptService, IUserService userService)
        {
            this.receiptService = receiptService;
            this.userService = userService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = this.userService.GetUserIdByUsername(this.User.Username);
            var allUserReceipts = this.receiptService.GetAllReceiptByUserId(userId);
            var viewModel = new List<ReceiptViewModel>();

            foreach (var receipt in allUserReceipts)
            {
                var receiptViewModel = new ReceiptViewModel
                {
                    Fee = $"{receipt.Fee:f2}",
                    Id = receipt.Id,
                    IssuedOn = receipt.IssuedOn.ToString("MM/dd/yyyy HH:mm"),
                    RecipientName = this.userService.GetUsernameById(receipt.RecipientId)
                };

                viewModel.Add(receiptViewModel);
            }

            return this.View(viewModel);
        }
    }
}
