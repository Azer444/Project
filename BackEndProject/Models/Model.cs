using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }

        public List<ShopProduct> ShopProducts { get; set; }
    }
}
