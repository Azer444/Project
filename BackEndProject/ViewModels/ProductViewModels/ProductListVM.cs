using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.ProductViewModels
{
    public class ProductListVM 
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
    }
}
