using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.TopImageModels
{
    public class TopImageUpdateVM
    {
        public List<IFormFile> Photos { get; set; }
    }
}
