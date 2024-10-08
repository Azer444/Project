﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Slider : BaseEntity 
    {
        public string Image { get; set; }
        public string Selling { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        [NotMapped]
        [Required(ErrorMessage ="Can't be empty")]
        public IFormFile Photo { get; set; }
    }
}
