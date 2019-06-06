using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.App.ViewModels
{
    public class ActiveOrdersHomeViewModel
    {
        public ActiveOrdersHomeViewModel()
        {
            this.ActiveOrders = new List<ActiveOrderViewModel>();
        }
        public List<ActiveOrderViewModel> ActiveOrders { get; set; }

        public void Add(ActiveOrderViewModel activeOrderViewModel)
        {
            this.ActiveOrders.Add(activeOrderViewModel);
        }
    }
}
