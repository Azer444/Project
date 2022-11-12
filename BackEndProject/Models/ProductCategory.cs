using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class ProductCategory : BaseEntity
    {
        public string Header { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }
        public string DetailDesc { get; set; }
        public bool MainImage { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }

    }
}
