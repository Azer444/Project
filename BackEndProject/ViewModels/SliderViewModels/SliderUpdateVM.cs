using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.SliderViewModels
{
    public class SliderUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Sale { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Title { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
