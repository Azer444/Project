using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.InfoViewModels
{
    public class InfoUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Color { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
