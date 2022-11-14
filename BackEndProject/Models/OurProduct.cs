using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class OurProduct : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
