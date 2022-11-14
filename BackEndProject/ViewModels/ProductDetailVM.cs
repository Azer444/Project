using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class ProductDetailVM
    {
        public IEnumerable<Product> ShopProducts { get; set; }
        public IEnumerable<Product> ShopProductsById { get; set; }
    }
}
