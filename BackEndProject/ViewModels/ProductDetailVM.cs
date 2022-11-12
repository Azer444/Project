using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class ProductDetailVM
    {
        public IEnumerable<ProductCategory> ShopProducts { get; set; }
        public IEnumerable<ProductCategory> ShopProductsById { get; set; }
    }
}
