using BackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewModels
{
    public class HeaderVM
    {
        public Dictionary<string, string> SettingDatas { get; set; }

        public IEnumerable<Currency> Currencies { get; set; }

        public IEnumerable<Language> Languages { get; set; }

    }
}
