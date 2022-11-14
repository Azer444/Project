﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels.InfoViewModels
{
    public class InfoCreateVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Color { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        public List<IFormFile> Photos { get; set; }
    }
}
