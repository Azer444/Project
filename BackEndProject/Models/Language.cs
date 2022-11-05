using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
