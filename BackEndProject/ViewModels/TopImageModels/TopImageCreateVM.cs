using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.TopImageModels
{
    public class TopImageCreateVM
    {
        [Required(ErrorMessage = "Can't be empty")]
        public List<IFormFile> Photos { get; set; }
    }
}
