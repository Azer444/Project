using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Slider : BaseEntity 
    {
        public string Image { get; set; }
        public string Selling { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
