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
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        public HeaderViewComponent(LayoutService layoutService,AppDbContext context)
        {
            _layoutService = layoutService;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Language> languages = await _layoutService.GetDatasFromLanguage();
            IEnumerable<Currency> currencies = await _layoutService.GetDatasFromCurrency();
            HeaderVM model = new HeaderVM
            {
                Languages = languages,
                Currencies = currencies,
                SettingDatas = setting,
            };

            return await Task.FromResult(View(model));
        }
    }
}
