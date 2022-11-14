using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.ShoeViewModels
{
    public class ShoeCreateVM
    {
        public int Id { get; set; }
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        public List<IFormFile> Photos { get; set; }
    }
}
