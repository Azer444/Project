using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Blog : BaseEntity
    {
        public string Header { get; set; }
        public string Desc { get; set; }
        public string BlogInfo { get; set; }
        public string ByAdmin { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
    }
}
