using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class NavbarCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Coulmn { get; set; }    
    }
}
