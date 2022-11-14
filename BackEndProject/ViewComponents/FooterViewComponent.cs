using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.Services;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly LayoutService _layout;

        public FooterViewComponent(LayoutService layout)
        {
            _layout = layout;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> settings = await _layout.GetDatasFromSetting();

            IEnumerable<Social> socials = await _layout.GetDatasFromSocial();

            IEnumerable<Category> categories = await _layout.GetDatasFromCategory();

            FooterVM footerVM = new FooterVM
            {
                Socials = socials,
                Settings = settings,
                Categories = categories
            };

            return await Task.FromResult(View(footerVM));
        }
    }
    
}
