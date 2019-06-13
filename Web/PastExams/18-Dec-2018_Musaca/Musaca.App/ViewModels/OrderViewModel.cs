namespace Musaca.App.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Products = new List<ProductViewModel>();
        }

        public ICollection<ProductViewModel> Products { get; set; }

        public decimal Price => this.Products.Sum(p => p.Price);
    }
}
