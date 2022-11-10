using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name Can't be empty")]
        [StringLength(16,ErrorMessage = "The size of text max 16")]
        public string Name { get; set; }
    }
}
