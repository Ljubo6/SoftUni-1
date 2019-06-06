using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Musaca.App.ViewModels
{
    public class ProductsAllViewModel 
    {
        public ProductsAllViewModel()
        {
            this.AllProducts = new List<ProductSingleViewModel>();
        }

        public List<ProductSingleViewModel> AllProducts { get; }

        public void Add(ProductSingleViewModel productSingleViewModel)
        {
            this.AllProducts.Add(productSingleViewModel);
        }
    }
}
