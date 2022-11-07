using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class TwinBlog : BaseEntity
    {
        public string Image { get; set; }
        public string Percent { get; set; }
        public string Desc { get; set; }
        public string Header { get; set; }
    }
}
