using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Shoes : BaseEntity
    {
        public string Image { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public IFormFile Photos { get; set; }
    }
}

