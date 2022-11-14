using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class TopBlog : BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
