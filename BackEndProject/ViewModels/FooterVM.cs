using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class FooterVM
    {
        public Dictionary<string, string> SettingDatas { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
