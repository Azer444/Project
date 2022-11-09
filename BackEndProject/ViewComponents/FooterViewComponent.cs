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
        private readonly LayoutService _layoutService;
        private readonly AppDbContext _context;
        public FooterViewComponent(LayoutService layoutService,AppDbContext context)
        {
            _layoutService = layoutService;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Category> categories = await _layoutService.GetDatasFromCategory();
            IEnumerable<Social> socials = await _context.Socials.ToListAsync();
            FooterVM model = new FooterVM
            {
                SettingDatas = setting,
                Categories = categories,
                Socials = socials

            };

            return await Task.FromResult(View(model));
        }
    }
}
