using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.App.ViewModels.ViewModels
{
    public class DeliveredPackageViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string ShippingAddress { get; set; }
        public string RecipientName { get; set; }
    }
}
