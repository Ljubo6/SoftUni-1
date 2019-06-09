using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.App.ViewModels.ViewModels
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }
        public string Fee { get; set; }
        public string IssuedOn { get; set; }
        public string RecipientName { get; set; }
    }
}
