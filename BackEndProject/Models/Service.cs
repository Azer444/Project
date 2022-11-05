using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Service : BaseEntity
    {
        public string Image { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
    }
}
