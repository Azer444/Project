using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class ProductImage : BaseEntity
    {
        public bool IsMain { get; set; }
        public string Image { get; set; }
        public int ShopProductId { get; set; }
        public ShopProduct ShopProduct { get; set; }
    }
}
