﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Setting : BaseEntity       
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
