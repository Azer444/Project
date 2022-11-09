using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class ProductSlider : BaseEntity 
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
    }
}
