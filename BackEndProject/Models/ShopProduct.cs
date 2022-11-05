using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class ShopProduct : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public List<ProductImage> ProductImages { get; set; }
    }
}
